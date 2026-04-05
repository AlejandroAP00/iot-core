using Core.Application.DTOs;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.DTOs;

public class UserDto
{

    required public Guid Id { get; set; }
    required public bool IsAdmin { get; set; } 
    required public bool IsVerified { get; set; }
    required public ProfileDto profile { get; set; }


    public static UserDto fromEntity(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            IsAdmin = user.IsAdmin,
            IsVerified = user.IsVerified,
            profile = new ProfileDto
            {
                FirstName = user.Profile?.FirstName ?? string.Empty,
                LastName = user.Profile?.LastName ?? string.Empty,
                Picture = user.Profile?.Picture ?? string.Empty
            }
        };
    }

}
