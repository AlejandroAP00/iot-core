using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Application.DTOs;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public String Email { get; set; } = String.Empty;

    [Required]
    public String Password { get; set; } = String.Empty;

    public bool UseCookies { get; set; } = false;


}
