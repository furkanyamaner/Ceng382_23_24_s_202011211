using System.Collections.Generic;

public class ReservationRepository : IReservationRepository
{
   private List<Reservation>[,] reservations;

    public ReservationRepository(int rows, int columns)
    {
        reservations = new List<Reservation>[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                reservations[i, j] = new List<Reservation>();
            }
        }
    }
    public List<Reservation>[,] GetReservations()
    {
        return reservations;
    }

    public void SetReservations(List<Reservation>[,] value)
    {
        reservations = value;
    }

    public void AddReservation(Reservation reservation)
    {

         if (reservation.GetRoom().GetCapacity() >= 1)
        {
            int Day = reservation.GetDate().DayOfWeek - DayOfWeek.Monday;
            int Hour = reservation.GetTime().Hour;
            if(Hour<=9 || Hour>=21){
                    Console.WriteLine("Not available");
            }
            else{
                reservations[Day, Hour].Add(reservation);
                reservation.GetRoom().Capacity=reservation.GetRoom().GetCapacity()-1;
                Console.WriteLine("added");
            }
            
        }
        else
        {
            Console.WriteLine("Room is full. Choose another.");
        }
         reservation.GetRoom().Capacity=0;
    }

    public void DeleteReservation(Reservation reservation)
    {
        int Day = reservation.GetDate().DayOfWeek - DayOfWeek.Monday;
        int Hour = reservation.GetTime().Hour;

    
    if (reservations[Day, Hour].Contains(reservation))
    {
        reservations[Day, Hour].Remove(reservation);
        reservation.GetRoom().Capacity=reservation.GetRoom().GetCapacity()+1;
         Console.WriteLine($"removed   {reservation.GetDate().ToString("dddd, dd/MM/yyyy")} - {reservation.GetTime().ToString("HH:mm")}");
    }
    else
    {
        Console.WriteLine("Not found.");
    }
    }

     public List<Reservation> GetAllReservations()
    {
        List<Reservation> allReservations = new List<Reservation>();

        foreach (var slot in reservations)
        {
            allReservations.AddRange(slot);
        }

        return allReservations;
    }
}