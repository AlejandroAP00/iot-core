using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsVerified { get; set; }

    public required Profile? Profile { get; set; }

    public Authentication? Authentication { get; set; }


}