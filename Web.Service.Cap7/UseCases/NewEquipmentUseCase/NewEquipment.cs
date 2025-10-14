using MediatR;
using Web.Service.Cap7.Boundaries;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Mappers;
using Web.Service.Cap7.UseCases.NewEquipmentUseCase.Boundaries;

namespace Web.Service.Cap7.UseCases.NewEquipmentUseCase;

public class NewEquipment(
    IEquipmentRepository equipmentRepository,
    ISectorRepository sectorRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<NewEquipmentInput, Output>
{
    private readonly IEquipmentRepository _equipmentRepository = equipmentRepository;
    private readonly ISectorRepository _sectorRepository = sectorRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Output> Handle(NewEquipmentInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var sector = await _sectorRepository.GetAsync(input.SectorId, cancellationToken);
        if (sector is null)
        {
            output.AddErrorMessage("Sector not found.");
            return output;
        }

        var equipment = input.MapToModel();
        await _equipmentRepository.CreateAsync(equipment, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return output;
    }
}
