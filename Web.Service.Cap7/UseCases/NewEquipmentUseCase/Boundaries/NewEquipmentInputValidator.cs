using FluentValidation;

namespace Web.Service.Cap7.UseCases.NewEquipmentUseCase.Boundaries;

public class NewEquipmentInputValidator : AbstractValidator<NewEquipmentInput>
{
	public NewEquipmentInputValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Name is required.");

		RuleFor(x => x.ConsumptionPerHour)
			.NotEmpty()
			.WithMessage("Consumption per hour is required.")
			.GreaterThan(0);

		RuleFor(x => x.MaxActiveHours)
			.NotEmpty()
			.WithMessage("Max active hours is required.");

        RuleFor(x => x.LastActivedAt)
            .NotEmpty()
            .WithMessage("Last activated at is required.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Last activated at cannot be in the future.");

        RuleFor(x => x.SectorId)
			.NotEmpty()
            .WithMessage("Sector ID is required.")
            .GreaterThan(0)
            .WithMessage("Sector ID must be greater than 0.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.")
            .GreaterThan(0)
            .WithMessage("User ID must be greater than 0.");
    }
}
