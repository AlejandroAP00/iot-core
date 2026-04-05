using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Core.Application.DTOs;

public class ProfileDto
{
    required public String FirstName;
    required public String LastName;
    required public String Picture;
}
