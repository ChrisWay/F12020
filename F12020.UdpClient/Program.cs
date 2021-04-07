using F12020.UdpClient.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace F12020.UdpClient
{
    class Program
    {
        const int port = 10000;

        static readonly Dictionary<PacketType, Type> TypeMapping = new()
        {
            { PacketType.Motion, typeof(PacketMotionData) },
            { PacketType.Event, typeof(PacketEventData) }
        };

        static void Main(string[] args)
        {
            var ip = new IPEndPoint(IPAddress.Loopback, port);
            var listener = new System.Net.Sockets.UdpClient(ip);

            Console.WriteLine("Started Listening");

            while (true)
            {
                var result =  listener.Receive(ref ip);

                 var GetPacketType(result.AsMemory(0, 24));

                //var span = result.AsSpan(0, 24).ToArray();
                var gcHandle = GCHandle.Alloc(span, GCHandleType.Pinned);
                var header = Marshal.PtrToStructure<PacketHeader>(gcHandle.AddrOfPinnedObject());
                gcHandle.Free();

                Console.WriteLine(header.PacketId.ToString());

                switch (header.PacketId)
                {
                    case PacketType.Motion:
                        var gcHandle2 = GCHandle.Alloc(result, GCHandleType.Pinned);
                        var packet = Marshal.PtrToStructure<PacketMotionData>(gcHandle2.AddrOfPinnedObject());
                        gcHandle2.Free();

                        Console.WriteLine($"Wheel Slip RL: {packet.WheelSpeed[0]}");
                        break;
                    case PacketType.Session:
                        break;
                    case PacketType.LapData:
                        break;
                    case PacketType.Event:
                        var gcHandle3 = GCHandle.Alloc(result, GCHandleType.Pinned);
                        var packet2 = Marshal.PtrToStructure<PacketEventData>(gcHandle3.AddrOfPinnedObject());
                        gcHandle3.Free();

                        Console.WriteLine($"Event Code: {packet2.EventCode}");
                        break;
                    case PacketType.Participants:
                        break;
                    case PacketType.CarSetups:
                        break;
                    case PacketType.CarTelemetry:
                        break;
                    case PacketType.CarStatus:
                        break;
                    case PacketType.FinalClassification:
                        break;
                    case PacketType.LobbyInfo:
                        break;
                    default:
                        break;
                }
               

                //Console.WriteLine($" {Encoding.ASCII.GetString(result, 0, result.Length)}");
            }
        }

        static PacketType GetPacketType(ReadOnlyMemory<byte> headerData)
        {
            if(headerData.Length != 24)
            {
                throw new ArgumentOutOfRangeException(nameof(headerData), "Header data should be 24 bytes in length");
            }

            var gcHandle = GCHandle.Alloc(headerData, GCHandleType.Pinned);
            var header = Marshal.PtrToStructure<PacketHeader>(gcHandle.AddrOfPinnedObject());
        }


    }
}
