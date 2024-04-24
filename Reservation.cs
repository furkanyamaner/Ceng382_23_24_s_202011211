public record Reservation
{
  private DateTime Time;
    private DateTime Date;
    private string? ReserverName;
    private Room? Room;

    

    public DateTime GetTime()
    {
        return Time;
    }

    public void SetTime(DateTime time)
    {
        Time = time;
    }

    public DateTime GetDate()
    {
        return Date;
    }

    public void SetDate(DateTime date)
    {
        Date = date;
    }

    public string GetReserverName()
    {
        return ReserverName;
    }

    public void SetReserverName(string reserverName)
    {
        ReserverName = reserverName;
    }

    public Room GetRoom()
    {
        return Room;
    }

    public void SetRoom(Room room)
    {
        Room = room;
    }
}