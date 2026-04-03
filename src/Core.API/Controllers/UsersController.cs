using Core.Application.DTOs;
using Core.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto createUserData)
    {
        await _userService.CreateUser(
            id: Guid.NewGuid(),
            isAdmin: false,
            isVerified: false,
            firstName: createUserData.firstName,
            lastName: createUserData.lastName,
            picture: "https://example.com/profile.jpg"
        );
        return Ok();
    }
}
