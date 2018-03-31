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
        const int buffersize = 4096;

        static async Task Main(string[] args)
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

                using (var sendNamedPipe = new NamedPipeClientStream(".", pipeName + "i"))//, PipeDirection.InOut, PipeOptions.Asynchronous))
                {
                    await sendNamedPipe.ConnectAsync();

                    using (var receiveNamedPipe = new NamedPipeServerStream(pipeName + "o"))//, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, buffersize, buffersize))
                    {
                        await receiveNamedPipe.WaitForConnectionAsync();

                        var peerNameResolver = new PeerNameResolver();

                        using (var timer = new System.Timers.Timer(1000))
                        {
                            timer.Elapsed += (sender, e) =>
                            {
                                timer.Stop();
                                peerNameResolver.ResolveAsync(peerName, cloud, Guid.NewGuid());
#if DEBUG
                                Console.WriteLine("ResolveAsync");
#endif
                            };
                            void resolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
                            {
                                sendNamedPipe.Write(e.PeerNameRecord.Data, 0, e.PeerNameRecord.Data.Length);
                                sendNamedPipe.Flush();
#if DEBUG
                                //var buffer = e.PeerNameRecord.Data;
                                //var length = e.PeerNameRecord.Data.Length;
                                //Console.WriteLine($"{nameof(resolveProgressChanged)} {nameof(buffer)}[{length}]={BitConverter.ToString(buffer, 0, length).Replace("-", string.Empty)}");
                                Console.WriteLine(nameof(resolveProgressChanged));
#endif
                            }

                            void resolveCompleted(object sender, ResolveCompletedEventArgs e)
                            {
                                foreach (var record in e.PeerNameRecordCollection)
                                {
                                    sendNamedPipe.Write(record.Data, 0, record.Data.Length);
                                    sendNamedPipe.Flush();
                                }
#if DEBUG
                                Console.WriteLine($"{nameof(resolveCompleted)} count={e.PeerNameRecordCollection.Count}");
#endif
                                timer.Start();
                            }

                            peerNameResolver.ResolveProgressChanged += resolveProgressChanged;
                            peerNameResolver.ResolveCompleted += resolveCompleted;

                            timer.Start();

                            try
                            {
                                var peerNameRegistration = new PeerNameRegistration(peerName, portNo, cloud);

                                while (true)
                                {
                                    var buffer = new byte[buffersize];
                                    int length = await receiveNamedPipe.ReadAsync(buffer, 0, buffer.Length);

                                    if (0 == length)
                                    {
                                        ;
                                    }
                                    else if (1 == length)
                                    {
                                        // 終了コード
                                        if (buffer[0] == 0xFF) break;
                                    }
                                    else
                                    {
#if DEBUG
                                        //Console.WriteLine($"Read {nameof(buffer)}[{length}]={BitConverter.ToString(buffer, 0, length).Replace("-", string.Empty)}");
                                        Console.WriteLine("Read");
#endif
                                        var bufferSend = new byte[length];
                                        Buffer.BlockCopy(buffer, 0, bufferSend, 0, length);
                                        peerNameRegistration.Data = bufferSend;
                                        if (peerNameRegistration.IsRegistered())
                                        {
                                            peerNameRegistration.Update();
                                        }
                                        else
                                        {
                                            peerNameRegistration.Start();
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                timer.Stop();
                                peerNameResolver.ResolveProgressChanged -= resolveProgressChanged;
                                peerNameResolver.ResolveCompleted -= resolveCompleted;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex);
#endif
            }
#if DEBUG
            Console.WriteLine($"end");
            Console.ReadLine();
#endif
        }
    }
}
