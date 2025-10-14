namespace Web.Service.Cap7.Requests;

public sealed record LoginUserRequest(
    string Email,
    string Password
);
