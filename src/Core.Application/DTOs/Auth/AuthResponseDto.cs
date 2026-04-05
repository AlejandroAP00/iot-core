using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.DTOs;

public class AuthResponseDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
