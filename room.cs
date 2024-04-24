using System.Text.Json.Serialization;

public record Room
{
    private string? roomId;
    private string? roomName;
    private int capacity;

    [JsonPropertyName("roomId")]
    public string? RoomId
    {
        get => roomId;
        set => roomId = value;
    }

    [JsonPropertyName("roomName")]
    public string? RoomName
    {
        get => roomName;
        set => roomName = value;
    }

    [JsonPropertyName("capacity")]
    public int Capacity
    {
        get => capacity;
        set => capacity = value;
    }

    public string GetRoomId()
    {
        return roomId ?? "";
    }
    public string GetRoomName()
    {
        return roomName ?? "";
    }
    public int GetCapacity()
    {
        return capacity;
    }


}