namespace Core.Domain.Entities;

public class Authentication 
{
    public Guid Id { get; set; }
    public required String Email { get; set; }
    public required String Password { get; set; }
    public required String PhoneNumber { get; set; }

    public required Guid UserId { get; set; }

    public  String? SecretKey { get; set; }

}