using Web.Service.Cap7.Dtos;
using Web.Service.Cap7.Models;
using Web.Service.Cap7.Requests;
using Web.Service.Cap7.UseCases.LoginUserUseCase.Boundaries;
using Web.Service.Cap7.UseCases.NewUserUseCase.Boundaries;

namespace Web.Service.Cap7.Mappers;

public static class UserMapper
{
    public static User MapToModel(this NewUserInput input, byte[] passwordHash, byte[] passwordSalt)
    {
        return new User(
            input.Name,
            input.Email,
            passwordHash,
            passwordSalt,
            input.Role
        );
    }

    public static NewUserInput MapToInput(this NewUserRequest request)
    {
        return new NewUserInput(
            request.Name,
            request.Email,
            request.Password,
            request.Confirmation,
            request.Role
        );
    }

    public static LoginUserInput MapToInput(this LoginUserRequest request)
    {
        return new LoginUserInput(
            request.Email,
            request.Password
        );
    }

    public static UserDto MapToDto(this User user, string token)
    {
        return new UserDto(
            user.Id,
            user.Name,
            user.Email,
            token
        );
    }
}
