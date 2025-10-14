using MediatR;
using Web.Service.Cap7.Boundaries;

namespace Web.Service.Cap7.UseCases.NewSectorUseCase.Boundaries;

public sealed record NewSectorInput(
    string Name,
    string? Description,
    double ConsumptionLimit,
    int UserId
) : IRequest<Output>;
