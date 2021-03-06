namespace F12020.UdpClient.Models
{
    public enum PacketType : byte
    {
        Motion = 0,
        Session = 1,
        LapData = 2,
        Event = 3,
        Participants = 4,
        CarSetups = 5,
        CarTelemetry = 6,
        CarStatus = 7,
        FinalClassification = 8,
        LobbyInfo = 9
    }
}
