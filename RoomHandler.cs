
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class RoomHandler
{
    private string filePath;

    public RoomHandler(string filePath)
    {
        this.filePath = filePath;
    }

    public RoomData GetRooms()
    {
        string jsonString = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
        };
        RoomData? roomData = JsonSerializer.Deserialize<RoomData>(jsonString, options);

        return roomData;
    }

   
    public void SaveRooms(List<Room> rooms)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(rooms);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("Saved");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error {ex.Message}");
        }
    }
}