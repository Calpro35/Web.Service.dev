using MediatR;
using Web.Service.Cap7.Boundaries;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Mappers;
using Web.Service.Cap7.UseCases.ActivateEquipmentUseCase.Boundaries;

namespace Web.Service.Cap7.UseCases.ActivateEquipmentUseCase;

public class ActivateEquipment(
    IEquipmentRepository equipmentRepository,
    IUnitOfWork unitOfWork    
) : IRequestHandler<ActivateEquipmentInput, Output>
{
    private readonly IEquipmentRepository _equipmentRepository = equipmentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Output> Handle(ActivateEquipmentInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var equipment = await _equipmentRepository.GetAsync(input.EquipmentId, cancellationToken);

        if (equipment is null)
        {
            output.AddErrorMessage($"unable to find equipment with id {input.EquipmentId}");
            return output;
        }

        if (equipment.IsActive)
        {
            output.AddErrorMessage($"equipment with id {input.EquipmentId} is already active");
            return output;
        }

        equipment.IsActive = true;
        _equipmentRepository.Update(equipment);
        await _unitOfWork.CommitAsync(cancellationToken);

        output.AddResult(equipment.MapToDto());
        return output;
    }
}
