using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

using System.Threading;

namespace SocketTest
{
    class Program
    {

        private static int myProt = 9527;   //端口
        static Socket serverSocket;

        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myProt));  //绑定IP地址：端口
            serverSocket.Listen(20000);    //设定最多20000个排队连接请求
            Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());
            //通过Clientsoket发送数据
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start();

        }

        private static void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();

                Thread receiveThread = new Thread(Receive);
                receiveThread.Start(clientSocket);
            }
        }

        private static void Receive(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;

            byte[] b = new byte[2];

            while (true)
            {
                try
                {
                    //通过clientSocket接收数据
                    int receiveNumber = myClientSocket.Receive(b);
                    myClientSocket.Send(b);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    break;
                }
            }
        }


    }
}
