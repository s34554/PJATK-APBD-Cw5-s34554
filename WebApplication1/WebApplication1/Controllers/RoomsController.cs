using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
      [HttpGet]
      public IActionResult GetRooms([FromQuery] int? minCapacity, [FromQuery] bool? hasProjector, bool? activeOnly)
      {
            var rooms = DataBase.Rooms.AsEnumerable();
            if(minCapacity != null) rooms = rooms.Where(r => r.Capacity >= minCapacity);
            if (hasProjector != null) rooms = rooms.Where(r => r.HasProjector == hasProjector);
            if (activeOnly == true) rooms = rooms.Where(r => r.IsActive);
            return Ok(rooms);
      }
      [HttpGet("{id:int}")]
      public IActionResult GetById(int id)
      {
            var room = DataBase.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null) return NotFound("No room with this Id");
            return Ok(room);
      }

      [HttpGet("building/{buildingCode:int}")]
      public IActionResult GetByBuildingCode(int buildingCode)
      {
            var rooms = DataBase.Rooms.Where(r => r.BuildingCode == buildingCode);
            if (!rooms.Any()) return NotFound("No rooms in with this building code");
            return Ok(rooms);
      }

      [HttpPost]
      public IActionResult AddRoom([FromBody] Room room)
      {
            DataBase.Rooms.Add(room);
            return CreatedAtAction(nameof(GetById),new {id = room.Id}, room);
      }
      
      [HttpPut("{id:int}")]
      public IActionResult AlterRoom(int id, [FromBody] Room room)
      {
            var existing = DataBase.Rooms.FirstOrDefault(r => r.Id == id);
            if (existing == null) return NotFound("No room with this Id");

            existing.Name = room.Name;
            existing.BuildingCode = room.BuildingCode;
            existing.Floor = room.Floor;
            existing.Capacity = room.Capacity;
            existing.HasProjector = room.HasProjector;
            existing.IsActive = room.IsActive;
            return Ok(existing);
      }
      
      [HttpDelete("{id:int}")]
      public IActionResult DeleteRoom(int id)
      {
            var room = DataBase.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null) return NotFound("No room with this Id");
            var hasReservations = DataBase.Reservations.Any(r => r.RoomId == id && r.Date >= DateOnly.FromDateTime(DateTime.Today));
            if (hasReservations) return Conflict("Room has current or future reservations");
            DataBase.Rooms.Remove(room);
            return NoContent();
      }
}