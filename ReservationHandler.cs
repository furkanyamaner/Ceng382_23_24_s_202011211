using System;
using System.Collections.Generic;
public class ReservationHandler
{
    private IReservationRepository reservationRepository;
    private LogHandler logHandler;
    private RoomHandler roomHandler;
    


    public ReservationHandler( IReservationRepository reservationrepository,LogHandler loghandler)
    {
        reservationRepository= reservationrepository;
        logHandler=loghandler;
    }
    
    public void AddReservation(Reservation reservation)
    {
        reservationRepository.AddReservation(reservation);
        
    }

    public void DeleteReservation(Reservation reservation)
    {
        reservationRepository.DeleteReservation(reservation);
    }
    public List<Reservation> GetAllReservations()
    {
        return reservationRepository.GetAllReservations();
    }
    public RoomData GetRooms()
    {
        return roomHandler.GetRooms();
        
    }
    public void SaveRooms(List<Room> rooms)
    {
        roomHandler.SaveRooms(rooms);
    }
    
    public List<Reservation>[,] GetReservations()
    {
        return reservationRepository.GetReservations();
    }
}