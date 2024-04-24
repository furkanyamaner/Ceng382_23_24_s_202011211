using System;
using System.IO;
using System.Collections.Generic;


public class ReservationService()
{
    
    private ReservationHandler reservationHandler;

    public ReservationService(ReservationHandler handler) : this()
    {
        reservationHandler = handler;
    
        
    }
    
     public void AddReservation(Reservation reservation)
    {
        reservationHandler.AddReservation(reservation);
        
        
    }
    public void DeleteReservation(Reservation reservation)
    {
        reservationHandler.DeleteReservation(reservation);
    }
     public void DisplayWeeklySchedule()
    {
       DateTime today = DateTime.Today;
    DayOfWeek todayOfWeek = today.DayOfWeek;
    string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    Console.WriteLine("schedule:");

    for (int i = 0; i < daysOfWeek.Length; i++)
    {
        if (i == (int)todayOfWeek-1)
        {
            Console.Write($"{daysOfWeek[i]} (Today)".PadLeft(10) + " - ");
        }
        else if((int)todayOfWeek-1>i)
        {
            Console.Write(daysOfWeek[i].PadLeft(10)+"(next week)" + " - ");
        }
        else{
             Console.Write(daysOfWeek[i].PadRight(15) + " - ");
        }
    }

    Console.WriteLine();
    Console.WriteLine(new string('-', 15 * 7));

    for (int hour = 9; hour < reservationHandler.GetReservations().GetLength(1); hour++)
    {
        if (hour < 10)
        {
            Console.Write($"0{hour}:00" + " - ");
        }
        else
        {
            Console.Write($"{hour}:00" + " - ");
        }

        for (int day = 0; day < reservationHandler.GetReservations().GetLength(0); day++)
        {
            var resList = reservationHandler.GetReservations()[day, hour];
            if (resList != null && resList.Count > 0)
            {
                foreach (var res in resList)
                {
                    Console.Write($"{res.GetReserverName()}-{res.GetRoom().GetRoomName()}".PadRight(15) + " - ");
                }
            }
            else
            {
                Console.Write("".PadRight(15) + " - ");
            }
        }
        Console.WriteLine();
    }
    }
    
}