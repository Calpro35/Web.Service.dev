using MediatR;
using Web.Service.Cap7.Boundaries;

namespace Web.Service.Cap7.UseCases.ActivateEquipmentUseCase.Boundaries;

public sealed record ActivateEquipmentInput(
    int EquipmentId,
    int UserId
) : IRequest<Output>;
