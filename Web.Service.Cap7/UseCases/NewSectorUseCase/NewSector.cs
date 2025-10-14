using MediatR;
using Web.Service.Cap7.Boundaries;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Mappers;
using Web.Service.Cap7.UseCases.NewSectorUseCase.Boundaries;

namespace Web.Service.Cap7.UseCases.NewSectorUseCase;

public class NewSector(
    ISectorRepository sectorRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<NewSectorInput, Output>
{
    private readonly ISectorRepository _sectorRepository = sectorRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Output> Handle(NewSectorInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var sector = input.MapToModel();

        await _sectorRepository.CreateAsync(sector, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return output;
    }
}
