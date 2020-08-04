using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace 채팅_서버
{
    class Program
    {
        Socket sever = null;
        private List<StringBuilder> m_Display = null; 
        private List<Socket> m_client = new List<Socket>();
        static void Main(string[] args)
        {
            new Program();
        }
        public Program()
        {
            initilaze();
        }
        void initilaze()
        {
            m_Display = new List<StringBuilder>();
            sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sever.Bind(new IPEndPoint(IPAddress.Any, 3000));
            sever.Listen(20);
            SocketAsyncEventArgs sockasync = new SocketAsyncEventArgs();
            SocketAsyncEventArgs sockasync1 = new SocketAsyncEventArgs();
            sockasync.Completed += new EventHandler<SocketAsyncEventArgs>(SocketAccept);

            sever.AcceptAsync(sockasync);

            Connect();
        }
        void SocketAccept(Object acceptclient, SocketAsyncEventArgs e)                     //클라이언트 소켓 접속을 받는 부분
        {
            Socket client = e.AcceptSocket;

            PacketData packet = new PacketData();
            PacketData packet1 = new PacketData();

            SocketAsyncEventArgs async = new SocketAsyncEventArgs();

            async.UserToken = packet;
            async.SetBuffer(packet.GetBuf(), 0, 4);

            async.Completed += new EventHandler<SocketAsyncEventArgs>(ReciveEvent);         //접속한 클라이언트 마다 recv이벤트 연결 해줌
            client.ReceiveAsync(async);
            m_client.Add(client);

            Console.WriteLine("유저 접속 완료");

            Socket sever = (Socket)acceptclient;
            e.AcceptSocket = null;
            sever.AcceptAsync(e);                                                 // 서버 소켓은 다시 연결을 받기 위해 대기함
        }
        void ReciveEvent(object send, SocketAsyncEventArgs e)                    //클라이언트로 부터 메시지가 전송돼었을떄의 이벤트 처리
            // send : 메시지를 보낸 클라이언트의 소켓 , e : 메시지 데이터
        {
            Socket Client = (Socket)send;
            PacketData Packet = (PacketData)e.UserToken;
            Packet.SetLength(e.Buffer);
            if(Packet.DataLenght1 >= 1024)
            {
                // 데이터를 받을 버퍼 생성
                byte[] buffer = new byte[4];
                byte[] finame = new byte[4];
                // 클라이언트로부터 파일 크기를 받음
                Client.Receive(buffer);
                Client.Receive(finame);
                // 받은 데이터를 정수로 변환하고 변수에 저장
                int fileLength = BitConverter.ToInt32(buffer, 0);
                // 버퍼 크기 새로 지정
                buffer = new byte[1024];
                // 현재까지 받은 파일 크기 변수
                int totalLength = 0;
                    // 파일을 만듦
                    FileStream fileStr = new FileStream(Encoding.Unicode.GetString(finame), FileMode.Create, FileAccess.Write);
                    // 받을 데이터를 파일에 쓰기 위해 BinaryWriter 객체 생성
                    BinaryWriter writer = new BinaryWriter(fileStr);
                    // 파일 수신 작업
                    while (totalLength < fileLength)
                    {
                        int receiveLength = Client.Receive(buffer);
                        writer.Write(buffer, 0, receiveLength);
                        // 현재까지 받은 파일 크기를 더함
                        totalLength += receiveLength;
                    }
                    writer.Close();
                    return;
            }
            Packet.Init();
            if(Client.Connected)
            {
                Client.Receive(Packet.Data1, Packet.DataLenght1, 0);
                for (int i = 0; i < m_client.Count; i++)
                {
                    if(m_client[i] != Client)
                    {
                        SocketAsyncEventArgs sendargs = new SocketAsyncEventArgs();
                        sendargs.SetBuffer(BitConverter.GetBytes(Packet.DataLenght1), 0, 4);
                        sendargs.Completed += new EventHandler<SocketAsyncEventArgs>(SendEvent);
                        sendargs.UserToken = Packet;

                        m_client[i].SendAsync(sendargs);
                    }          
                }
                Packet = null;
                Client.ReceiveAsync(e);
            }
            else
            {
                Console.WriteLine("접속 종료");
            }
        }
        void SendEvent(Object send, SocketAsyncEventArgs e)
        {
            Socket client = (Socket)send;
            PacketData packet = (PacketData)e.UserToken;
            client.Send(packet.Data1);
        }
        void Connect()
        {
            while(true)
            {
                for (int i = 0; i < m_client.Count; i++ )
                {
                    if (m_client[i].Connected == false)
                    {
                        Console.WriteLine("접속 종료");
                        m_client.Remove(m_client[i]);
                    }
                }
            }
        }
    } 
}
