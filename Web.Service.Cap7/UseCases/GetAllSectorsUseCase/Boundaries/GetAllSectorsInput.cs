using MediatR;
using Web.Service.Cap7.Boundaries;

namespace Web.Service.Cap7.UseCases.GetAllSectorsUseCase.Boundaries;

public sealed record GetAllSectorsInput(
    int UserId    
) : IRequest<Output>;
