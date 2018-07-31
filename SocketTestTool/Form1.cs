using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketTestTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private int sendCount;

        private bool willStop;
        private bool isRunning;

        private object obj = new object();

        private Queue<Socket> queue = new Queue<Socket>();


        private void btnTest_Click(object sender, EventArgs e)
        {

            if (isRunning)
            {
                WriteMsg("请停止后再开始");
                return;
            }

            isRunning = true;
            willStop = false;

            sendCount = 0;


            Thread thread = new Thread(Test);
            thread.Start();
            
        }

        private void Count()
        {
            int lastCount = 0;
            int temp;

            while (true)
            {
                if (willStop)
                {
                    break;
                }

                Thread.Sleep(1000);

                lock (obj)
                {
                    temp = sendCount;
                }


                string s = "已发送：" + (temp - lastCount);

                BeginInvoke(new Action<string>(WriteMsg), new object[] { s });

                lastCount = temp;
            }
        }

        private void Test()
        {
            
            IPAddress ip = IPAddress.Parse("127.0.0.1");

            Socket s;

            int connCount = int.Parse(txtConnCount.Text);

            Invoke(new Action<string>(WriteMsg), new object[] { "建立连接 ……" });

            for (int i = 0; i < connCount; i++)
            {
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                s.Connect(new IPEndPoint(ip, 9527));

                queue.Enqueue(s);

                Invoke(new Action<string>(WriteMsg), new object[] { "已建立 " + (i + 1) + " 个连接" });
            }

            Invoke(new Action<string>(WriteMsg), new object[] { "建立连接完成" });

            int threadCount = int.Parse(txtThreadCount.Text);

            for (int i=0; i<threadCount; i++)
            {
                Thread thread = new Thread(Send);
                thread.Start();
            }

            Thread thread2 = new Thread(Count);
            thread2.Start();
        }
        
        private void Send()
        {

            Socket s;

            byte[] b = Encoding.ASCII.GetBytes(txtSendInfo.Text);

            while (true)
            {

                s = null;

                lock (queue)
                {
                    if (queue.Count > 0)
                    {
                        s = queue.Dequeue();
                    }
                }

                if (this.willStop)
                {
                    if (s == null)
                        break;

                    s.Dispose();

                    continue;
                }


                if (s == null)
                {
                    Thread.Sleep(5);
                    continue;
                }


                s.Send(b);

                s.Receive(b);


                lock (obj)
                {
                    sendCount++;
                }

                lock(queue)
                {
                    queue.Enqueue(s);
                }

            }

        }

        private void WriteMsg(string msg)
        {
            txtMsg.AppendText(DateTime.Now.ToString("HH:mm:ss.fff") + " " + msg + "\r\n");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                WriteMsg("请开始后再停止");
                return;
            }

            Thread thread = new Thread(Stop);
            thread.Start();
        }

        private void Stop()
        {
            this.willStop = true;

            while (true)
            {
                Thread.Sleep(1000);

                lock (queue)
                {
                    if (queue.Count == 0)
                    {
                        BeginInvoke(new Action<string>(WriteMsg), new object[] { "已停止" });
                        break;
                    }
                }
            }

            isRunning = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMsg.Clear();
        }

    }
}
