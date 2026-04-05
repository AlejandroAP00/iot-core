using Microsoft.AspNetCore.Mvc;
using Core.Application.DTOs;
using Core.Application.Services;

namespace Core.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly AuthenticationService _authenticationService;

    public AuthenticationController(ILogger<AuthenticationController> logger, AuthenticationService authenticationService)
    {
        _logger = logger;
        _authenticationService = authenticationService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var result = await _authenticationService.Login(dto);

        if (dto.UseCookies)
        {
            Response.Cookies.Append("accessToken", result.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(15)
            });

            Response.Cookies.Append("refreshToken", result.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            });

            return Ok(new { message = "Login exitoso con cookies" });
        }

        return Ok(result);
    }
}