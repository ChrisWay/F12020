using System.Runtime.InteropServices;

namespace F12020.UdpClient.Models
{
    [StructLayout(LayoutKind.Sequential, Size = PacketSize, Pack = 1)]
    public readonly struct PacketMotionData
    {
        public const int PacketSize = 1464;

        public readonly PacketHeader Header;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public readonly CarMotionData[] CarMotionData;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public readonly float[] SuspensionPoistion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public readonly float[] SuspensionVelocity;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public readonly float[] SuspensionAcceleration;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public readonly float[] WheelSpeed;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public readonly float[] WheelSlip;
        public readonly float LocalVelocityX;
        public readonly float LocalVelocityY;
        public readonly float LocalVelocityZ;
        public readonly float AngularVelocityX;
        public readonly float AngularVelocityY;
        public readonly float AngularVelocityZ;
        public readonly float AngularAccelerationX;
        public readonly float AngularAccelerationY;
        public readonly float AngularAccelerationZ;
        public readonly float FrontWheelAngle;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct CarMotionData
    {
        public readonly float WorldPositionX;
        public readonly float WorldPositionY;
        public readonly float WorldPositionZ;
        public readonly float WorldVelocityX;
        public readonly float WorldVeolcityY;
        public readonly float WorldVelocityZ;
        public readonly short WorldForwardDirX;
        public readonly short WorldForwardDirY;
        public readonly short WorldForwardDirZ;
        public readonly short WorldRightDirX;
        public readonly short WorldRightDirY;
        public readonly short WorldRightDirZ;
        public readonly float GForceLateral;
        public readonly float GForceLongitudinal;
        public readonly float GForceVertical;
        public readonly float Yaw;
        public readonly float Pitch;
        public readonly float Roll;
    }
}
