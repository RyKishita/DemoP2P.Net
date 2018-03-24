using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.PeerToPeer;

namespace RelationUnity
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length != 3) return;

            string pipeName = args[0];
            string peerNameClassifier = args[1];
            int portNo = int.Parse(args[2]);

#if DEBUG
            Console.WriteLine($"{nameof(pipeName)}={pipeName},{nameof(peerNameClassifier)}={peerNameClassifier},{nameof(portNo)}={portNo}");
#endif

            var cloud = Cloud.AllLinkLocal;
            var peerName = new PeerName(peerNameClassifier, PeerNameType.Secured);

            server = new NamedPipeServerStream(pipeName);
            try
            {
                await server.WaitForConnectionAsync();

                var peerNameResolver = new PeerNameResolver();
                peerNameResolver.ResolveProgressChanged += PeerNameResolver_ResolveProgressChanged;
                peerNameResolver.ResolveCompleted += PeerNameResolver_ResolveCompleted;

                peerNameResolver.ResolveAsync(peerName, cloud);

                var peerNameRegistration = new PeerNameRegistration(peerName, portNo, cloud);

                while (true)
                {
                    var buffer = new byte[4096];
                    int length = await server.ReadAsync(buffer, 0, 4096);

                    if (0 == length) continue;
#if DEBUG
                    Console.WriteLine($"{nameof(buffer)}[{length}]={BitConverter.ToString(buffer, 0, length).Replace("-", string.Empty)}");
#endif
                    // 終了コード
                    if (1 == length && buffer[0] == 0xFF) break;

                    peerNameRegistration.Data = buffer;
                    if (peerNameRegistration.IsRegistered())
                    {
                        peerNameRegistration.Update();
                    }
                    else
                    {
                        peerNameRegistration.Start();
                    }
                }

                peerNameResolver.ResolveProgressChanged -= PeerNameResolver_ResolveProgressChanged;
                peerNameResolver.ResolveCompleted -= PeerNameResolver_ResolveCompleted;
            }
            catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex);
#endif
            }
            finally
            {
#if DEBUG
                Console.WriteLine($"server.Close();");
#endif
                server.Close();
            }

#if DEBUG
            Console.ReadLine();
#endif
        }

        static NamedPipeServerStream server = null;

        private static void PeerNameResolver_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            server.Write(e.PeerNameRecord.Data, 0, e.PeerNameRecord.Data.Length);
            server.Flush();
        }

        private static void PeerNameResolver_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            foreach(var record in e.PeerNameRecordCollection)
            {
                server.Write(record.Data, 0, record.Data.Length);
                server.Flush();
            }
        }
    }
}
