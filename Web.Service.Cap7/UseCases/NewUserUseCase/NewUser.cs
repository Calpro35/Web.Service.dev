using MediatR;
using Web.Service.Cap7.Boundaries;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Mappers;
using Web.Service.Cap7.UseCases.NewUserUseCase.Boundaries;

namespace Web.Service.Cap7.UseCases.NewUserUseCase;

public class NewUser(
    IUserRepository userRepository,
    IPasswordService passwordService,
    IUnitOfWork unitOfWork
) : IRequestHandler<NewUserInput, Output>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordService _passwordService = passwordService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Output> Handle(NewUserInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var existingUser = await _userRepository.GetByEmailAsync(input.Email, cancellationToken);

        if (existingUser is not null)
        {
            output.AddErrorMessage("Email already exists.");
            return output;
        }

        var (passwordHash, passwordSalt) = _passwordService.CreatePasswordHash(input.Password);

        var user = input.MapToModel(passwordHash, passwordSalt);

        await _userRepository.CreateAsync(user, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return output;
    }
}
