using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.WebSockets;
using System.Threading;

namespace WebSocketTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Listen();
            
        }

        private static void Listen()
        {
            
            string uriPrefix = "http://*:9528/";

            var listener = new HttpListener();
            listener.Prefixes.Add(uriPrefix);
            listener.Start();

            Console.WriteLine("启动监听 " + uriPrefix + " 成功");
            
            while (true)
            {
                try
                {
                    var context = listener.GetContext();

                    var t = context.AcceptWebSocketAsync(null);

                    t.Wait();

                    var ws = t.Result.WebSocket;

                    Thread thread = new Thread(Receive);
                    thread.Start(ws);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private static void Receive(object o)
        {
            WebSocket ws = (WebSocket)o;

            byte[] b;

            try
            {
                while(true)
                {
                    b = new byte[2];

                    var ab = new ArraySegment<byte>(b);

                    var t = ws.ReceiveAsync(ab, CancellationToken.None);

                    t.Wait();

                    ws.SendAsync(ab, WebSocketMessageType.Binary, true, CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                ws.Dispose();
            }
            
        }
    }
}
