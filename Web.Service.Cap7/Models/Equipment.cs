    namespace Web.Service.Cap7.Models;

public class Equipment : Model
{
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = false;
    public double ConsumptionPerHour { get; set; }
    public int MaxActiveHours { get; set; }
    public double ConsumptionTotal { get; set; }
    public DateTime LastActivedAt { get; set; }
    public int SectorId { get; set; }
    public Sector Sector { get; set; } = default!;

    protected Equipment() { }

    public Equipment(
        string name,
        double consumptionPerHour,
        int maxActiveHours,
        DateTime lastActivedAt,
        int sectorId
    )
    {
        Name = name;
        IsActive = false;
        ConsumptionTotal = 0;
        ConsumptionPerHour = consumptionPerHour;
        MaxActiveHours = maxActiveHours;
        LastActivedAt = lastActivedAt;
        SectorId = sectorId;
    }
}
