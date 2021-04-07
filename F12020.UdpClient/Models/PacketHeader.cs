using System.Runtime.InteropServices;

namespace F12020.UdpClient.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record PacketHeader
    {
        public ushort PacketFormat;
        public byte GameMajorVersion;
        public byte GameMinorVersion;
        public byte PacketVersion;
        public PacketType PacketId;
        public ulong SessionUid;
        public float SessionTime;
        public uint FrameIdentifer;
        public byte PlayerCarIndex;
        public byte SecondaryPlayerCarIndex;

        //public int PacketSize
        //{
        //    get
        //    {
        //        switch (PacketId)
        //        {
        //            case PacketType.Motion:
        //                return PacketMotionData.PacketSize;
        //            case PacketType.Session:
        //                break;
        //            case PacketType.LapData:
        //                break;
        //            case PacketType.Event:
        //                break;
        //            case PacketType.Participants:
        //                break;
        //            case PacketType.CarSetups:
        //                break;
        //            case PacketType.CarTelemetry:
        //                break;
        //            case PacketType.CarStatus:
        //                break;
        //            case PacketType.FinalClassification:
        //                break;
        //            case PacketType.LobbyInfo:
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}
