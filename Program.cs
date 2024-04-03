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
            // Bir blokta 4 oda bulunur
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
        Room[] rooms;
        using (StreamReader r = new StreamReader("Data.json"))
        {
            string json = r.ReadToEnd();
            var data = JsonDocument.Parse(json);
            var roomArray = data.RootElement.GetProperty("Room").ToString();
            rooms = JsonSerializer.Deserialize<Room[]>(roomArray);
        }

        ReservationHandler reservationHandler = new ReservationHandler(7, rooms.Length);

        while (true)
        {
            Console.WriteLine("1. Add Reservation");
            Console.WriteLine("2. Delete Reservation");
            Console.WriteLine("3. Display Weekly Schedule");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddReservation(reservationHandler, rooms);
                    break;
                case "2":
                    DeleteReservation(reservationHandler);
                    break;
                case "3":
                    reservationHandler.DisplayWeeklySchedule();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

    static void AddReservation(ReservationHandler handler, Room[] rooms)
{
    Console.WriteLine("Enter reservation details:");

    // Kullanıcıdan rezervasyon bilgilerini al
    Console.Write("Reserver name: ");
    string reserverName = Console.ReadLine();

    Console.Write("Reservation day index (0-6): ");
    int dayIndex = int.Parse(Console.ReadLine());

    Console.Write("Reservation room index (0-{0}): ", rooms.Length - 1);
    int roomIndex = int.Parse(Console.ReadLine());

    Console.Write("Reservation time (HH:mm): ");
    DateTime time = DateTime.ParseExact(Console.ReadLine(), "HH:mm", null);

    // Reservation ve Room nesnelerini oluştur
    Reservation reservation = new Reservation
    {
        Time = time,
        Date = DateTime.Today.AddDays(dayIndex),
        ReserverName = reserverName,
        Room = rooms[roomIndex]
    };

    // ReservationHandler'a rezervasyonu ekle
    handler.AddReservation(reservation, dayIndex, roomIndex);
}

static void DeleteReservation(ReservationHandler handler)
{
    Console.WriteLine("Enter the day and room to delete reservation:");

    // Kullanıcıdan silinecek rezervasyonun gün ve oda bilgilerini al
    Console.Write("Reservation day index (0-6): ");
    int dayIndex = int.Parse(Console.ReadLine());

    Console.Write("Reservation room index: ");
    int roomIndex = int.Parse(Console.ReadLine());

    // ReservationHandler'dan rezervasyonu sil
    handler.DeleteReservation(dayIndex, roomIndex);
}


    
}
