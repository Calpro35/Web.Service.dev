using MediatR;
using Web.Service.Cap7.Boundaries;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Mappers;
using Web.Service.Cap7.UseCases.DeactivateEquipmentUseCase.Boundaries;

namespace Web.Service.Cap7.UseCases.DeactivateEquipmentUseCase;

public class DeactivateEquipment(
    IEquipmentRepository equipmentRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeactivateEquipmentInput, Output>
{
    private readonly IEquipmentRepository _equipmentRepository = equipmentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Output> Handle(DeactivateEquipmentInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var equipment = await _equipmentRepository.GetAsync(input.EquipmentId, cancellationToken);

        if (equipment is null)
        {
            output.AddErrorMessage("Equipment not found.");
            return output;
        }

        if (!equipment.IsActive)
        {
            output.AddErrorMessage("Equipment is already deactivated.");
            return output;
        }

        var uptime = DateTime.UtcNow - equipment.LastActivedAt;
        equipment.IsActive = false;
        equipment.ConsumptionTotal += equipment.ConsumptionPerHour * uptime.TotalHours;
        equipment.LastActivedAt = DateTime.UtcNow;
        _equipmentRepository.Update(equipment);
        await _unitOfWork.CommitAsync(cancellationToken);

        output.AddResult(equipment.MapToDto());
        return output;
    }
}
