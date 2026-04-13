namespace WebApplication1;
using WebApplication1.Models;
using WebApplication1.Enums;

public static class DataBase
{
    public static List<Room> Rooms { get; } = new()
    {
        new Room { Id = 1, Name = "Alfa", BuildingCode = 101, Floor = 1, Capacity = 10, HasProjector = true, IsActive = true },
        new Room { Id = 2, Name = "Beta", BuildingCode = 101, Floor = 2, Capacity = 20, HasProjector = true, IsActive = true },
        new Room { Id = 3, Name = "Gamma", BuildingCode = 102, Floor = 0, Capacity = 6, HasProjector = false, IsActive = true },
        new Room { Id = 4, Name = "Delta", BuildingCode = 102, Floor = 1, Capacity = 15, HasProjector = true, IsActive = false },
        new Room { Id = 5, Name = "Omega", BuildingCode = 103, Floor = 3, Capacity = 50, HasProjector = true, IsActive = true }
    };

    public static List<Reservation> Reservations { get; } = new()
    {
        new Reservation { Id = 1, RoomId = 1, OrganizerName = "Jan Kowalski", Date = new DateOnly(2026, 4, 14), StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(10, 30), Status = ReservationStatus.Confirmed },
        new Reservation { Id = 2, RoomId = 2, OrganizerName = "Anna Nowak", Date = new DateOnly(2026, 4, 14), StartTime = new TimeOnly(11, 0), EndTime = new TimeOnly(12, 0), Status = ReservationStatus.Planned },
        new Reservation { Id = 3, RoomId = 1, OrganizerName = "Piotr Zieliński", Date = new DateOnly(2026, 4, 15), StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(15, 30), Status = ReservationStatus.Cancelled },
        new Reservation { Id = 4, RoomId = 5, OrganizerName = "Maria Wiśniewska", Date = new DateOnly(2026, 4, 16), StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(9, 0), Status = ReservationStatus.Confirmed },
        new Reservation { Id = 5, RoomId = 3, OrganizerName = "Jan Kowalski", Date = new DateOnly(2026, 4, 16), StartTime = new TimeOnly(13, 0), EndTime = new TimeOnly(14, 0), Status = ReservationStatus.Planned }
    };

    public static int NextRoomId => Rooms.Max(r => r.Id) + 1;
    public static int NextReservationId => Reservations.Max(r => r.Id) + 1;
}