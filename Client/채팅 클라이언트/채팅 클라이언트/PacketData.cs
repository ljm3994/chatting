using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 채팅_클라이언트
{
    class PacketData
    {
        private long DataLenght;

        public long DataLenght1
        {
            get { return DataLenght; }
            set { DataLenght = value; }
        }
        private byte[] Data;

        public byte[] Data1
        {
            get { return Data; }
            set { Data = value; }
        }
        public void Init()
        {
            Data = new byte[DataLenght];
        }
        public byte[] GetBuf()
        {
            return new byte[4];
        }
        public void SetLength(byte[] Data)
        {
            if (Data.Length < 4)
                return;
            DataLenght = BitConverter.ToInt32(Data, 0);
        }
    }
}
