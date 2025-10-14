using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.ViewModels
{
    public class SectorViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double ConsumptionLimit { get; set; }
        public int UserId { get; set; }
        public UserViewModel UserViewModel { get; set; } = default!;
        public ICollection<Equipment> Equipments { get; set; } = [];
    }
}
