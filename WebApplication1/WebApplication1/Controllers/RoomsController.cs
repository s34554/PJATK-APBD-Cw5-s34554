using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

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