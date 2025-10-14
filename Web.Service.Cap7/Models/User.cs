using Web.Service.Cap7.Models.Enums;

namespace Web.Service.Cap7.Models;

public class User : Model
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public UserRoles Role { get; set; }
    public ICollection<Sector> Sectors { get; set; } = [];

    protected User() { }

    public User(
        string name,
        string email,
        byte[] passwordHash,
        byte[] passwordSalt,
        UserRoles role
    )
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        Role = role;
    }
}
