using MediatR;
using Web.Service.Cap7.Boundaries;
using Web.Service.Cap7.Models.Enums;

namespace Web.Service.Cap7.UseCases.NewUserUseCase.Boundaries;

public sealed record NewUserInput(
    string Name,
    string Email,
    string Password,
    string Confirmation,
    UserRoles Role
) : IRequest<Output>;
