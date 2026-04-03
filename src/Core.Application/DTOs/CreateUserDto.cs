using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Core.Application.DTOs;
public class CreateUserDto
{

    [Required]
    public string firstName { get; set; } = string.Empty;

    [Required]
    public string lastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string email { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string phoneNumber { get; set; } = string.Empty;

    [Required]
    [PasswordPropertyText]
    public string password { get; set; } = string.Empty;

}
