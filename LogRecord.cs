using System;
using System.Text.Json;
using System.Text.Json.Serialization;
public record LogRecord
{
    private DateTime Timestamp { get; }
    private string ReserverName { get; }
    private string RoomName { get; }
    private string Situation { get; }

    public LogRecord(DateTime timestamp, string reserverName, string roomName, string situation)
    {
        Timestamp = timestamp;
        ReserverName = reserverName;
        RoomName = roomName;
        Situation = situation;
    }

    public DateTime GetTimestamp()
    {
        return Timestamp;
    }

    public string GetReserverName()
    {
        return ReserverName;
    }

    public string GetRoomNumber()
    {
        return RoomName;
    }

    public string GetSituation()
    {
        return Situation;
    }
}