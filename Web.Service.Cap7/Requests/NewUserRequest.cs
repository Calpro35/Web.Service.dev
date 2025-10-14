using Web.Service.Cap7.Models.Enums;

namespace Web.Service.Cap7.Requests;

public sealed record NewUserRequest(
    string Name,
    string Email,
    string Password,
    string Confirmation,
    UserRoles Role
);
