using System.Runtime.InteropServices;

namespace F12020.UdpClient.Models
{
    [StructLayout(LayoutKind.Explicit, Size = PacketSize)]
    public readonly struct PacketEventData
    {
        public const int PacketSize = 35;

        [FieldOffset(0)]
        public readonly PacketHeader Header;

        [FieldOffset(24)]
        private readonly byte Code1;
        [FieldOffset(25)]
        private readonly byte Code2;
        [FieldOffset(26)]
        private readonly byte Code3;
        [FieldOffset(27)]
        private readonly byte Code4;

        public string EventCode
        {
            get => System.Text.Encoding.ASCII.GetString(new byte[] { Code1, Code2, Code3, Code4 });
        }

        [FieldOffset(28)]
        public readonly FastestLap FastestLap;

        [FieldOffset(28)]
        public readonly Retirement Retirement;

        [FieldOffset(28)]
        public readonly TeamMateInPits TeamMateInPits;

        [FieldOffset(28)]
        public readonly RaceWinner RaceWinner;

        [FieldOffset(28)]
        public readonly Penalty Penalty;

        [FieldOffset(28)]
        public readonly SpeedTrap SpeedTrap;
    }

    [StructLayout(LayoutKind.Sequential, Size = 5, Pack = 1)]
    public readonly struct FastestLap
    {
        public readonly byte VehicleIndex;
        public readonly float LapTime;
    }

    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 1)]
    public readonly struct Retirement
    {
        public readonly byte VehicleIndex;
    }

    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 1)]
    public readonly struct TeamMateInPits
    {
        public readonly byte VehicleIndex;
    }

    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 1)]
    public readonly struct RaceWinner
    {
        public readonly byte VehicleIndex;
    }

    [StructLayout(LayoutKind.Sequential, Size = 7, Pack = 1)]
    public readonly struct Penalty
    {
        //TODO Create Enum
        public readonly byte PenaltyType;
        //TODO Create Enum
        public readonly byte InfringmentType;
        public readonly byte VehicleIndex;
        public readonly byte OtherVehicleIndex;
        public readonly byte Time;
        public readonly byte LapNumber;
        public readonly byte PlacesGained;
    }

    [StructLayout(LayoutKind.Sequential, Size = 5, Pack = 1)]
    public readonly struct SpeedTrap
    {
        public readonly byte VehicleIndex;
        public readonly float Speed;
    }

}
