using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Net.PeerToPeer;

namespace PeerToPipe
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 4)
                {
#if DEBUG
                    Console.WriteLine("invalid arguments");
                    Console.ReadLine();
#endif
                    return;
                }

                string pipeName = args[0];
                string connectionTarget = args[1];
                string portNoStr = args[2];
                string param3 = args[3];
#if DEBUG
                Console.WriteLine($"{nameof(pipeName)}={pipeName},{nameof(connectionTarget)}={connectionTarget},{nameof(portNoStr)}={portNoStr},{nameof(param3)}={param3}");
#endif

                int portNo = int.Parse(portNoStr);
                PeerName peerName = null;
                Cloud cloud = null;

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

                using (var namedPipePipeToPeer = new NamedPipeClientStream(".", pipeName + "PipeToPeer"))
                {
                    namedPipePipeToPeer.Connect();
#if DEBUG
                    Console.WriteLine("connect named pipe 'PipeToPeer'");
#endif
                    using (var namedPipePeerToPipe = new NamedPipeClientStream(".", pipeName + "PeerToPipe"))
                    {
                        namedPipePeerToPipe.Connect();
#if DEBUG
                        Console.WriteLine("connect named pipe 'PeerToPipe'");
#endif
                        var peerNameResolver = new PeerNameResolver();

                        while (namedPipePipeToPeer.IsConnected && namedPipePeerToPipe.IsConnected)
                        {
                            int result = namedPipePipeToPeer.ReadByte();
                            if (result < 0) break;
#if DEBUG
                            Console.WriteLine("read");
#endif
                            // 読み込み実行
                            if (result == 0xFF)
                            {
#if DEBUG
                                Console.WriteLine("resolve start");
#endif
                                foreach (var record in peerNameResolver.Resolve(peerName, cloud))
                                {
                                    namedPipePeerToPipe.Write(record.Data, 0, record.Data.Length);
                                    namedPipePeerToPipe.Flush();
                                    namedPipePeerToPipe.WaitForPipeDrain();
#if DEBUG
                                    var buffer = record.Data;
                                    var length = record.Data.Length;
                                    Console.WriteLine($"{nameof(buffer)}[{length}]={BitConverter.ToString(buffer, 0, length).Replace("-", string.Empty)}");
#endif
                                }

                                namedPipePeerToPipe.WriteByte(0xFF);//終端
                                namedPipePeerToPipe.Flush();
                                namedPipePeerToPipe.WaitForPipeDrain();

#if DEBUG
                                Console.WriteLine("resolve end");
#endif
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex);
                Console.ReadLine();
#endif
            }
#if DEBUG
            Console.WriteLine("end");
#endif
        }
    }
}
