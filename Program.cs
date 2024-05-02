using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;
/*
Single Responsibility Principle: A class should have only one reason to change, meaning it should have only one responsibility. This principle helps to make the code more understandable, maintainable, and reusable.
Dependency Injection: Dependency Injection states that a class should receive its dependencies from external sources rather than creating them itself. This promotes flexibility in the code and reduces dependencies between classes.

Additionally, the code violated the Dependency Injection Principle because dependencies between classes were tightly coupled and not injected from external sources. For example, the ReservationHandler class had direct dependencies on the Reservation and Room classes, which hindered the ability to inject dependencies from outside.

Understanding why it's important not to comply with these principles is crucial in the context of web applications. Web applications tend to be large and complex. Failing to adhere to the Single Responsibility Principle may lead to each class having many different responsibilities, increasing code complexity. Similarly, not adhering to the Dependency Injection Principle can make testing and maintaining the code more challenging because class dependencies are tightly coupled, making it difficult to make changes.
*/

/*
The given UML diagram complicates the code and makes it less flexible. It leads to the creation of numerous objects within the codebase and fails to manage dependencies between classes properly. Additionally, each class in the diagram seems to have multiple responsibilities, which is against the principle of Single Responsibility.

This situation could make the code harder to understand and maintain. Therefore, the code needs to be restructured to adhere to these principles. Restructuring the code involves reducing dependencies between classes and ensuring that each class has only one responsibility. This way, the code becomes more readable, easier to maintain, and more flexible.

*/

public class RoomData
{
    [JsonPropertyName("Room")]
    public Room[]? Rooms { get; set; }

    public Room? GetRoomById(string roomId)
    {
        return Rooms?.FirstOrDefault(room => room.GetRoomId() == roomId);
    }
}


class Program
{
    static void generateReservation(int year,int mounth,int day,int hour,string str,Reservation reservation,Room room1){
        DateTime desiredDate = new DateTime(year, mounth, day, hour, 0, 0);
            DateTime ToDay = DateTime.Today;
           

            if (desiredDate < ToDay && desiredDate.Hour<ToDay.Hour)
            {
                Console.WriteLine("date invalid.");
            }
            else{
                 TimeSpan fark = desiredDate - ToDay;
              if (fark.TotalDays > 7)
                 {
                  Console.WriteLine($"Enter Between 1-7");
               }
              else
              {
                  
                reservation.SetDate(desiredDate);
                reservation.SetTime(desiredDate);
                reservation.SetReserverName(str);
                reservation.SetRoom(room1);
                
                
                Console.WriteLine(reservation.GetTime());
              }
                 
            }
    }
    static void Main(string[] args)
    {
        
       
        string jsonFilePath = "Data.json";
        RoomHandler _roomHandler = new RoomHandler(jsonFilePath);
       
        RoomData roomData = _roomHandler.GetRooms();
        
        
        string logFilePath = "LogData.json";
        try
        {
            if (File.Exists(logFilePath))
            {
                File.WriteAllText(logFilePath, string.Empty);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error {ex.Message}");
        }
        ILogger fileLogger = new FileLogger(logFilePath);
        LogHandler _logHandler = new LogHandler(fileLogger);
       

        ReservationRepository reservationrepo = new ReservationRepository(7,21);
        ReservationHandler reservationhandler = new ReservationHandler(reservationrepo,_logHandler);
        

        ReservationService reservationService = new ReservationService(reservationhandler);
        
        

        if (roomData?.Rooms != null)
        {
            Room room1 = roomData.Rooms[0]; 
            Reservation reservation1 = new Reservation();
            generateReservation(2024,4,8,12,"Ahmet",reservation1,room1);
            if (reservation1 == null)
            {
                Console.WriteLine("Error");
            }
            else
            {
                reservationService.AddReservation(reservation1);
                
                LogRecord logRecord1 = new LogRecord(reservation1.GetDate(), reservation1.GetReserverName(),reservation1.GetRoom().GetRoomName(), "Add");
        
                _logHandler.AddLog(logRecord1);
                
            }
                

            Room room2 = roomData.Rooms[0]; 
            Reservation reservation2 = new Reservation();
            generateReservation(2024,4,8,13,"Mehmet",reservation2,room2);
            if (reservation2 == null)
            {
               Console.WriteLine("Error");
            }
            else
            {
                reservationService.AddReservation(reservation2);
                
                LogRecord logRecord2 = new LogRecord(reservation2.GetDate(), reservation2.GetReserverName(),reservation2.GetRoom().GetRoomName(), "Add");
        
                _logHandler.AddLog(logRecord2);

            
            }

            Room room3 = roomData.Rooms[1]; 
           
            Reservation reservation3 = new Reservation();
            generateReservation(2024,4,8,14,"Osman",reservation3,room3);
            if (reservation3 == null)
            {
                Console.WriteLine("Error");            
            }
            else
            {
                reservationService.AddReservation(reservation3);
                
                LogRecord logRecord3 = new LogRecord(reservation3.GetDate(), reservation3.GetReserverName(),reservation3.GetRoom().GetRoomName(), "Add");
        
                _logHandler.AddLog(logRecord3);
            }
               
        }
      
        
    }

/*

public class RoomHandler
{
    private string filePath;

    public RoomHandler(string filePath)
    {
        this.filePath = filePath;
    }

    public List<Room> GetRooms()
    {
        string jsonString = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
        };
        RoomData? roomData = JsonSerializer.Deserialize<RoomData>(jsonString, options);

        return roomData?.Rooms?.ToList();
    }

    public Room? GetRoomById(string roomId)
    {
        List<Room> rooms = GetRooms();
        return rooms?.FirstOrDefault(room => room.GetRoomId() == roomId);
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

Bu kısım çalışmıyor. Can Hocaya danışılacak.
*/


}