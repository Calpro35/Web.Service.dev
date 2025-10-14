using Web.Service.Cap7.Dtos;
using Web.Service.Cap7.Models;
using Web.Service.Cap7.Requests;
using Web.Service.Cap7.UseCases.NewSectorUseCase.Boundaries;

namespace Web.Service.Cap7.Mappers;

public static class SectorMapper
{
    public static Sector MapToModel(this NewSectorInput input)
    {
        return new Sector(
            input.Name,
            input.Description,
            input.ConsumptionLimit,
            input.UserId
        );
    }

    public static NewSectorInput MapToInput(this NewSectorRequest request, int userId)
    {
        return new NewSectorInput(
            request.Name,
            request.Description,
            request.ConsumptionLimit,
            userId
        );
    }

    public static SectorDto MapToDto(this Sector sector)
    {
        return new SectorDto(
            sector.Id,
            sector.Name,
            sector.Description,
            sector.ConsumptionLimit,
            sector.Equipments.Select(e => e.MapToDto()).ToList()
        );
    }

    public static SimpleSectorDto MapToSimpleDto(this Sector sector)
    {
        return new SimpleSectorDto(
            sector.Id,
            sector.Name
        );
    }

    public static IEnumerable<SectorDto> MapToDto(this IEnumerable<Sector> sectors)
    {
        return sectors.Select(sector => sector.MapToDto());
    }
}
