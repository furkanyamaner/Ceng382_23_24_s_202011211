using System;
using System.IO;
using System.Text.Json;

public class Room
{
    public string RoomId { get; set; }
    public string RoomName { get; set; }
    public int Capacity { get; set; }
}

public class Reservation
{
    public DateTime Time { get; set; }
    public DateTime Date { get; set; }
    public string ReserverName { get; set; }
    public Room Room { get; set; }
}

public class ReservationHandler
{
    private Reservation[,] reservations;

    public ReservationHandler(int daysOfWeek, int numberOfRooms)
    {
        reservations = new Reservation[daysOfWeek, numberOfRooms];
    }

    public void AddReservation(Reservation reservation, int dayIndex, int roomIndex)
    {
        if (reservations[dayIndex, roomIndex] == null)
        {
            reservations[dayIndex, roomIndex] = reservation;
            Console.WriteLine("Reservation added successfully.");
        }
        else
        {
            Console.WriteLine("The slot is already reserved.");
        }
    }

    public void DeleteReservation(int dayIndex, int roomIndex)
    {
        if (reservations[dayIndex, roomIndex] != null)
        {
            reservations[dayIndex, roomIndex] = null;
            Console.WriteLine("Reservation deleted successfully.");
        }
        else
        {
            Console.WriteLine("No reservation found in the selected slot.");
        }
    }

    public void DisplayWeeklySchedule()
    {
        string[] daysOfWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        for (int i = 0; i < reservations.GetLength(0); i++)
        {
            Console.WriteLine(daysOfWeek[i] + ":");

            for (int roomBlock = 0; roomBlock < reservations.GetLength(1); roomBlock += 4)
            {
                for (int j = roomBlock; j < roomBlock + 4 && j < reservations.GetLength(1); j++)
                {
                    if (reservations[i, j] != null)
                        Console.Write($"Room {reservations[i, j].Room.RoomName} - {reservations[i, j].ReserverName} ({reservations[i, j].Time.ToString("hh:mm tt")})\t");
                    else
                        Console.Write($"Room {j + 1}: Empty\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Room[] rooms = LoadRoomsFromJson("Data.json");

        ReservationHandler reservationHandler = new ReservationHandler(7, rooms.Length);

        AddReservations(reservationHandler, rooms);

        reservationHandler.DisplayWeeklySchedule();
    }

    static Room[] LoadRoomsFromJson(string filePath)
    {
        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            var data = JsonDocument.Parse(json);
            var roomArray = data.RootElement.GetProperty("Room").ToString();
            return JsonSerializer.Deserialize<Room[]>(roomArray);
        }
    }

    static void AddReservations(ReservationHandler handler, Room[] rooms)
    {
        DateTime currentTime = DateTime.Now;

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < rooms.Length; j++)
            {
                Reservation reservation = new Reservation
                {
                    Time = currentTime.AddHours(j + 9),
                    Date = DateTime.Today.AddDays(i),
                    ReserverName = "Furkan Yamaner",
                    Room = rooms[j]
                };

                handler.AddReservation(reservation, i, j);
                
            }
        }
    }
}
