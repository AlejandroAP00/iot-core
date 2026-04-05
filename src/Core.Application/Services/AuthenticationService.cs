using Core.Application.DTOs;
using Core.Application.Interfaces;
using Core.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Core.Application.Services;

public class AuthenticationService
{
    private readonly ILogger<AuthenticationService> _logger;
    private readonly IUserRepository _userRepo;
    private readonly IAuthenticationRepository _authRepo;
    private readonly ITokenService _tokenService;

    public AuthenticationService(IUserRepository userRepository, IAuthenticationRepository authRepository, ITokenService tokenService, ILogger<AuthenticationService> logger)
    {
        _userRepo = userRepository;
        _authRepo = authRepository;
        _tokenService = tokenService;

        _logger = logger;
    }



    /// <summary>
    ///  Authenticates a user with the provided credentials and generates authentication tokens
    /// </summary>
    /// <param name="login">An object containing the user's login credentials, including email and password. Cannot be null.</param>
    /// <returns>An AuthResponseDto containing the generated access and refresh tokens for the authenticated user.</returns>
    /// <exception cref="Exception">Thrown if the user does not exist, the password is incorrect, or the user record cannot be found.</exception>ResponseDto> Login(LoginDto login)
    public async Task<AuthResponseDto> Login(LoginDto login)
    {
        var auth = await _authRepo.GetAuthenticationByUserEmail(login.Email);

        if (auth == null)
            throw new Exception("El usuario no existe");

        var isValidPassword = login.Password == auth.Password; 

        if (!isValidPassword)
            throw new Exception("El password es incorrecto");


        var user = await _userRepo.GetUserById(auth.UserId);

        if (user == null) throw new Exception(string.Format("El usuario con id {0} no existe", auth.UserId));

        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        return new AuthResponseDto()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}
