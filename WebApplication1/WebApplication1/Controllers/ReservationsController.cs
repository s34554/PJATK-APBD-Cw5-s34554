using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enums;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetReservations([FromQuery] DateOnly? date, [FromQuery] ReservationStatus? status, [FromQuery] int? roomId)
    {
        var reservations = DataBase.Reservations.AsEnumerable();

        if (date != null)
            reservations = reservations.Where(r => r.Date == date);
        if (status != null)
            reservations = reservations.Where(r => r.Status == status);
        if (roomId != null)
            reservations = reservations.Where(r => r.RoomId == roomId);

        return Ok(reservations);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var reservation = DataBase.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null) return NotFound("No reservation with this Id");
        return Ok(reservation);
    }
}