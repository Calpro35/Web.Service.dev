using Web.Service.Cap7.Models;
using Web.Service.Cap7.Models.Enums;

namespace Web.Service.Cap7.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = [];
        public byte[] PasswordSalt { get; set; } = [];
        public UserRoles Role { get; set; }
        public ICollection<Sector> Sectors { get; set; } = [];
    }
}
