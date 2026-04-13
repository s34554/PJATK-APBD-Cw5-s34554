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
}