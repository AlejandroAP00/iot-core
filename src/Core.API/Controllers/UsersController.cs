using Core.Application.DTOs;
using Core.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly UserService _userService;

    public UsersController( ILogger<UsersController> logger, UserService userService)
    {
        _userService = userService;
        _logger =  logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto createUserData)
    {
        _logger.LogInformation("Datos recibidos {@User}", createUserData);
          var usercreatedUser = await _userService.CreateUser(
            id: Guid.NewGuid(),
            isAdmin: false,
            isVerified: false,
            firstName: createUserData.FirstName,
            lastName: createUserData.LastName,
            picture: "https://example.com/profile.jpg"
        );

        return Ok(usercreatedUser);
    }
}
