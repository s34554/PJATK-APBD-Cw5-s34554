using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enums;
using WebApplication1.Models;

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

    [HttpPost]
    public IActionResult AddReservation([FromBody] Reservation reservation)
    {
        var room = DataBase.Rooms.FirstOrDefault(r => r.Id == reservation.RoomId);
        if (room == null) return BadRequest("Room does not exist");
        reservation.Id = DataBase.NextReservationId;
        DataBase.Reservations.Add(reservation);
        return CreatedAtAction(nameof(GetById), new {id = reservation.Id}, reservation);
    }

    [HttpPut("{id:int}")]
    public IActionResult AlterReservation(int id)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteReservation(int id)
    {
        var reservation = DataBase.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null) return NotFound("No reservation with this Id");
        DataBase.Reservations.Remove(reservation);
        return NoContent();
    }
}