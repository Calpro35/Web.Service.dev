using MediatR;
using Web.Service.Cap7.Boundaries;

namespace Web.Service.Cap7.UseCases.NewEquipmentUseCase.Boundaries;

public sealed record NewEquipmentInput(
    string Name,
    double ConsumptionPerHour,
    int MaxActiveHours,
    DateTime LastActivedAt,
    int SectorId,
    int UserId
) : IRequest<Output>;
