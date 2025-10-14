using MediatR;
using Web.Service.Cap7.Boundaries;

namespace Web.Service.Cap7.UseCases.DeactivateEquipmentUseCase.Boundaries;

public sealed record DeactivateEquipmentInput(
    int EquipmentId    
) : IRequest<Output>;
