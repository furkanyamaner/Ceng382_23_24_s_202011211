using System.Collections.Generic;

public interface IReservationRepository
{
    List<Reservation>[,] GetReservations();
    
    void AddReservation(Reservation reservation);
    void DeleteReservation(Reservation reservation);
    void SetReservations(List<Reservation>[,] value);
    List<Reservation> GetAllReservations();
}