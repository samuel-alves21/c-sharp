using System.IO.Compression;

Room room = new Room(3);

Console.Write(room.Seats);

room.RoomSoldOutEvent += OnRoomSoldOut;

room.ReserveSeat();
room.ReserveSeat();
room.ReserveSeat();
room.ReserveSeat();
room.ReserveSeat();

static void OnRoomSoldOut(object sender, EventArgs e)
{
  Console.WriteLine("Room sold out!");
}

class Room(int seats)
{
  public int Seats { get; set; } = seats;

  private int reservedSeats = 0;

  public void ReserveSeat()
  {
    reservedSeats++;

    if (reservedSeats >= Seats)
    {
      OnRoomSoldOut(EventArgs.Empty);
    }
    else
    {
      Console.WriteLine("Seat reserved successfully!");
    }
  }

  public event EventHandler RoomSoldOutEvent;

  protected virtual void OnRoomSoldOut(EventArgs e)
  {
    RoomSoldOutEvent?.Invoke(this, e);
  }
}