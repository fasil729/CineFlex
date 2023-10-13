using Application.DTOs.Movie;
using FluentValidation;

namespace Application.DTOs.Movie.Validators;
public class UpdateMovieDTOValidator : AbstractValidator<UpdateMovieDTO>
{
    public UpdateMovieDTOValidator()
    {
        RuleFor(dto => dto.MovieId)
            .NotEmpty().WithMessage("MovieId must be provided.");

    }
}