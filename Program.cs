using PacketExample.Net;
using PacketExample.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketExample
{
    class Program
    {
        static void Main(string[] args)
        {

            // memory for the packet
            MemoryStream memory = new MemoryStream();

            // create a packet
            Packet packet = new Packet(PacketType.ConnectionRequest, Encoding.UTF8.GetBytes("Hi! Hacker."));

            // serialize the packet to the memorystream
            PacketSerializer serializer = new PacketSerializer();
            serializer.Serialize(memory, packet);

            // save a copy
            File.WriteAllBytes("TestPacket.bin", memory.ToArray());

            // reset the position of the stream
            memory.Seek(0L, SeekOrigin.Begin);

            // deserialize the packet
            Packet deserialized = serializer.Deserialize(memory);

            // print the packet data
            Console.WriteLine(Encoding.UTF8.GetString(deserialized.Data, 0, (int)deserialized.Length));
            Console.ReadLine();
        }
    }
}
