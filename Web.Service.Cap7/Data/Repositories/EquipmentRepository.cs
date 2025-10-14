using Web.Service.Cap7.Data.Context;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.Data.Repositories;

public class EquipmentRepository(AppDbContext context) : Repository<Equipment>(context), IEquipmentRepository
{
}
