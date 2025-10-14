using MediatR;
using Web.Service.Cap7.Boundaries;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Mappers;
using Web.Service.Cap7.UseCases.LoginUserUseCase.Boundaries;

namespace Web.Service.Cap7.UseCases.LoginUserUseCase;

public class LoginUser(
    IUserRepository userRepository,
    IPasswordService passwordService,
    JwtTokenProvider jwtTokenProvider
) : IRequestHandler<LoginUserInput, Output>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordService _passwordService = passwordService;
    private readonly JwtTokenProvider _jwtTokenProvider = jwtTokenProvider;

    public async Task<Output> Handle(LoginUserInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var user = await _userRepository.GetByEmailAsync(input.Email, cancellationToken);

        if (user is null)
        {
            output.AddErrorMessage("Invalid login attempt.");
            return output;
        }

        var isPasswordValid = _passwordService.VerifyPasswordHash(
            input.Password,
            user.PasswordHash,
            user.PasswordSalt
        );

        if (!isPasswordValid)
        {
            output.AddErrorMessage("Invalid login attempt.");
            return output;
        }

        var token = _jwtTokenProvider.GenerateToken(user.Id, user.Email);

        output.AddResult(user.MapToDto(token));
        return output;
    }
}
