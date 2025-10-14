using MediatR;
using Web.Service.Cap7.Boundaries;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Mappers;
using Web.Service.Cap7.UseCases.GetSectorByIdUseCase.Boundaries;

namespace Web.Service.Cap7.UseCases.GetSectorByIdUseCase;

public class GetSectorById(
    ISectorRepository sectorRepository
) : IRequestHandler<GetSectorByIdInput, Output>
{
    private readonly ISectorRepository _sectorRepository = sectorRepository;

    public async Task<Output> Handle(GetSectorByIdInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var sector = await _sectorRepository.GetAsync(input.SectorId, input.UserId, cancellationToken);

        if (sector is null)
        {
            output.AddErrorMessage("Sector not found.");
            return output;
        }

        output.AddResult(sector.MapToDto());
        return output;
    }
}
