namespace Web.Service.Cap7.Models;

public class Sector : Model
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double ConsumptionLimit { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public ICollection<Equipment> Equipments { get; set; } = [];

    protected Sector() { }

    public Sector(
        string name,
        string? description,
        double consumptionLimit,
        int userId
    )
    {
        Name = name;
        Description = description;
        ConsumptionLimit = consumptionLimit;
        UserId = userId;
    }
}
