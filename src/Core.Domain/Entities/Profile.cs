using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Entities;
public class Profile
{

    public Guid Id { get; set; }

    public required String FirstName { get; set; }
    public required String LastName { get; set; }   
    public required String Picture { get; set;  }

    public required DateTime UpdatedAt { get; set; }

}
