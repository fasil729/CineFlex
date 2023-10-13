using Application.DTOs.Cinema;
using FluentValidation;

namespace Application.DTOs.Cinema.Validators;


public class CreateCinemaDTOValidator : AbstractValidator<CreateCinemaDTO>
{
    public CreateCinemaDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(dto => dto.Location)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(200).WithMessage("Location cannot exceed 200 characters.");

        RuleFor(dto => dto.ContactInformation)
            .NotEmpty().WithMessage("Contact information is required.")
            .MaximumLength(100).WithMessage("Contact information cannot exceed 100 characters.");
    }
}



