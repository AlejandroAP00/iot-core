using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Login(int id)
    {
        return Ok(new { Id = id, Name = "Test" });
    }
}