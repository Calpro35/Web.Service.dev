using MediatR;
using Web.Service.Cap7.Boundaries;

namespace Web.Service.Cap7.UseCases.LoginUserUseCase.Boundaries;

public sealed record LoginUserInput(
    string Email,
    string Password
) : IRequest<Output>;
