namespace Web.Service.Cap7.Dtos;

public sealed record UserDto(
    int Id,
    string Name,
    string Email,
    string Token
);
