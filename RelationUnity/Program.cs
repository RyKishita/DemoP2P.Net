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
            if (args.Length != 4) return;

            string pipeName = args[0];
            string connectionTarget = args[1];
            string portNoStr = args[2];
            string param3 = args[3];

#if DEBUG
            Console.WriteLine($"{nameof(pipeName)}={pipeName},{nameof(connectionTarget)}={connectionTarget},{nameof(portNoStr)}={portNoStr},{nameof(param3)}={param3}");
#endif

            int portNo;
            PeerName peerName;
            Cloud cloud;
            try
            {
                portNo = int.Parse(portNoStr);

                switch (connectionTarget.ToLower())
                {
                    case "global":
                        cloud = Cloud.Global;
                        peerName = PeerName.CreateFromPeerHostName(param3);
                        break;
                    case "local":
                        cloud = Cloud.AllLinkLocal;
                        peerName = new PeerName(param3, PeerNameType.Secured);
                        break;
                    default:
                        throw new ArgumentException("invalid argument", "param 1");
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex);
#endif
                return;
            }

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
