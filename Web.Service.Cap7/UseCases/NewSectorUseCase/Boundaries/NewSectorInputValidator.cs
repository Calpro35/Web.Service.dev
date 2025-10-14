using FluentValidation;

namespace Web.Service.Cap7.UseCases.NewSectorUseCase.Boundaries;

public class NewSectorInputValidator : AbstractValidator<NewSectorInput>
{
    public NewSectorInputValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.ConsumptionLimit)
            .GreaterThan(0)
            .WithMessage("Consumption limit must be greater than zero.");
    }
}
