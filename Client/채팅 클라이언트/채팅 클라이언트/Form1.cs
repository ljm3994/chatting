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
using System.IO;
namespace 채팅_클라이언트
{
    public partial class Form1 : Form
    {
        private Socket m_client = null;
        static string IpAdress = "127.0.0.1";

        public string IpAdress1
        {
            set { IpAdress = value; }
        }
        static int Port = 3000;

        public int Port1
        {
            set { Port = value; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void 채팅서버접속ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            채팅서버접속Menu.Enabled = false;
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);        //클라이언트 소켓 설정 (ip v4에 대한 추소, 양방향 통신, Tcp방식)

            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(IpAdress), Port);

            args.Completed += new EventHandler<SocketAsyncEventArgs>(ConnectEvent);

            client.ConnectAsync(args);
        }
        void ConnectEvent(Object ob, SocketAsyncEventArgs e)
        {
            m_client = (Socket)ob;

            if(m_client.Connected)
            {
                PacketData Packet = new PacketData();
                SocketAsyncEventArgs recvargs = new SocketAsyncEventArgs();
                recvargs.UserToken = Packet;
                recvargs.SetBuffer(Packet.GetBuf(), 0, 4);
                recvargs.Completed += new EventHandler<SocketAsyncEventArgs>(RecivEvent);
                m_client.ReceiveAsync(recvargs);

                DisplayMsg("접속 완료", "System : ");
            }
            else
            {
                m_client = null;
                DisplayMsg("접속 실패", "System : ");
            }
        }
        void RecivEvent(object sender, SocketAsyncEventArgs e)
        {
            Socket client = (Socket)sender;
            PacketData Packet = (PacketData)e.UserToken;
            Packet.SetLength(e.Buffer);
            if(Packet.DataLenght1 >= 1024)
            {

            }
            Packet.Init();
            if(m_client.Connected)
            {
                client.Receive(Packet.Data1, (int)Packet.DataLenght1, 0);
                DisplayMsg(Encoding.Unicode.GetString(Packet.Data1), "받은 메시지 : ");
                client.ReceiveAsync(e);
            }
            else
            {
                DisplayMsg("접속 실패", "System : ");
                m_client = null;
            }

        }
        void DisplayMsg(String Message, String Chat)
        {
            StringBuilder buffer = new StringBuilder();
            Chat += Message;
            buffer.Append(Chat);

            this.Invoke(new Action(
                        delegate()
                        {
                            MsgList.Items.Add(Chat);
                        }));

        }
        private void btn_send_Click(object sender, EventArgs e)
        {
            if (m_client != null)
            {
                PacketData Packet = new PacketData();
      
                Packet.Data1 = Encoding.Unicode.GetBytes(MsgText.Text);
                MsgText.Text = "";
                Packet.DataLenght1 = Packet.Data1.Length;

                SocketAsyncEventArgs sendargs = new SocketAsyncEventArgs();
                sendargs.SetBuffer(BitConverter.GetBytes(Packet.DataLenght1), 0, 4);            //보낼 메시지 버버의 길이 설정
                sendargs.Completed += new EventHandler<SocketAsyncEventArgs>(SendEvent);           // 이벤트 연결
                sendargs.UserToken = Packet;

                m_client.SendAsync(sendargs);
            }     
        }
        void SendEvent(Object send, SocketAsyncEventArgs e)
        {
            Socket client = (Socket)send;
            PacketData packet = (PacketData)e.UserToken;
            client.Send(packet.Data1);
            DisplayMsg(Encoding.Unicode.GetString(packet.Data1), "보낸 메시지 : ");
        }

        private void 접속포트변경ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PortChange port = new PortChange();
            port.ShowDialog();
        }

        private void 파일전송SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = null;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
            }
            else
            {
                return;
            }
            PacketData packet = new PacketData();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            FileInfo fi = new FileInfo(fileName);

            string buf = string.Format("파일 이름 : {0}, 크기 {1}", fi.Name, fi.Length);
            DisplayMsg(buf, "보내는 파일 : ");
            packet.Data1 = Encoding.Unicode.GetBytes(fi.FullName);
            packet.DataLenght1 = packet.Data1.Length;
           // 파일 크기를 가져옴
            int fileLength = (int)fi.Length;

            SocketAsyncEventArgs sendargs = new SocketAsyncEventArgs();
            sendargs.SetBuffer(BitConverter.GetBytes(fileLength), 0, 4);            //보낼 메시지 버버의 길이 설정
            sendargs.Completed += new EventHandler<SocketAsyncEventArgs>(FileSendEvent);           // 이벤트 연결
            sendargs.UserToken = packet;

            m_client.SendAsync(sendargs);
        }
        private void FileSendEvent(Object send, SocketAsyncEventArgs e)
        {
            Socket client = (Socket)send;
            PacketData packet = (PacketData)e.UserToken;
            string pre = "F";
            string post = "E";
            byte[] prebuffer = Encoding.Unicode.GetBytes(pre);
            byte[] postbuffer = Encoding.Unicode.GetBytes(post);
            m_client.SendFile(Encoding.Unicode.GetString(packet.Data1), prebuffer, postbuffer, TransmitFileOptions.UseDefaultWorkerThread);
        }
        private static void AsynchronousFileSendCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;

            client.EndSendFile(ar);
        }
    }
}
