using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketExample.Utils;
namespace PacketExample.Net
{
    [Serializable]
    class Packet
    {
        public int Magic;
        public PacketType Type;
        public int Length;
        public byte[] Data;

        public Packet() { }

        public Packet(PacketType type, byte[] data)
        {
            Magic = Constants.Magic;
            Type = type;
            Length = data.Length;
            Data = data;
        }
    }
}
