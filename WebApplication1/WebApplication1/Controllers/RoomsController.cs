using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
      [HttpGet]
      public string GetNames()
      {
            throw new NotImplementedException();
      }
}