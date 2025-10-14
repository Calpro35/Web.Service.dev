using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.ViewModels
{
    public class EquipmentViewModel
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public double ConsumptionPerHour { get; set; }
        public int MaxActiveHours { get; set; }
        public double ConsumptionTotal { get; set; }
        public DateTime LastActivedAt { get; set; }
        public int SectorId { get; set; }
        public SectorViewModel Sector { get; set; } = default!;
    }
}
