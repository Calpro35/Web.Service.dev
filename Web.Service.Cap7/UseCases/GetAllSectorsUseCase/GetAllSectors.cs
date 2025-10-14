using MediatR;
using Web.Service.Cap7.Boundaries;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Mappers;
using Web.Service.Cap7.UseCases.GetAllSectorsUseCase.Boundaries;

namespace Web.Service.Cap7.UseCases.GetAllSectorsUseCase;

public class GetAllSectors(
    ISectorRepository sectorRepository    
) : IRequestHandler<GetAllSectorsInput, Output>
{
    private readonly ISectorRepository _sectorRepository = sectorRepository;

    public async Task<Output> Handle(GetAllSectorsInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var sectors = await _sectorRepository.GetAllAsync(input.UserId, cancellationToken);

        if (sectors is null || !sectors.Any())
        {
            output.AddErrorMessage("No sectors found for the user.");
            return output;
        }

        output.AddResult(sectors.MapToDto());
        return output;
    }
}
