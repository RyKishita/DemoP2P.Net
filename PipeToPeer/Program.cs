using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Net.PeerToPeer;

namespace PipeToPeer
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

                using (var namedPipeRead = new NamedPipeClientStream(".", pipeName, PipeDirection.In, PipeOptions.Asynchronous))
                {
                    namedPipeRead.Connect();
#if DEBUG
                    Console.WriteLine("connect named pipe");
#endif
                    var peerNameRegistration = new PeerNameRegistration(peerName, portNo, cloud);
                    try
                    {
                        while (namedPipeRead.IsConnected)
                        {
                            var readBuffer = new byte[4096];
                            int length = namedPipeRead.Read(readBuffer, 0, readBuffer.Length);
#if DEBUG
                            //Console.WriteLine($"read {nameof(buffer)}[{length}]={BitConverter.ToString(buffer, 0, length).Replace("-", string.Empty)}");
                            Console.WriteLine("read");
#endif
                            if (0 == length)
                            {
                                ;
                            }
                            else
                            {
#if DEBUG
                                Console.WriteLine("regist start");
#endif
                                var registBuffer = new byte[length];
                                Buffer.BlockCopy(readBuffer, 0, registBuffer, 0, length);
                                peerNameRegistration.Data = registBuffer;
                                if (peerNameRegistration.IsRegistered())
                                {
                                    peerNameRegistration.Update();
                                }
                                else
                                {
                                    peerNameRegistration.Start();
                                }
#if DEBUG
                                Console.WriteLine("regist end");
#endif
                            }
                        }
                    }
                    finally
                    {
                        peerNameRegistration.Stop();
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
