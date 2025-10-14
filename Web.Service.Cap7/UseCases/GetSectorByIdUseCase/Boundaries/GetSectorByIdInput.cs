using MediatR;
using Web.Service.Cap7.Boundaries;

namespace Web.Service.Cap7.UseCases.GetSectorByIdUseCase.Boundaries;

public sealed record GetSectorByIdInput(
    int SectorId,
    int UserId
) : IRequest<Output>;
