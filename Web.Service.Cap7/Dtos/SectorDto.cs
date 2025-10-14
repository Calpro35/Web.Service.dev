using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.Dtos;

public sealed record SectorDto(
    int Id,
    string Name,
    string? Description,
    double ConsumptionLimit,
    IEnumerable<EquipmentsListDto> Equipments
);

public sealed record SimpleSectorDto(
    int Id,
    string Name
);
