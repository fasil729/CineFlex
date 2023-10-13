using AutoMapper;
using FluentValidation;
using MovieAPI.Application.DTOs.Movie;
using MovieAPI.Application.Features.Movies.Requests.Commands;
using MovieAPI.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.Movies.Handlers.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieDto>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public CreateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMovieCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var movie = _mapper.Map<Movie>(request);
            await _movieRepository.Create(movie);

            var movieDto = _mapper.Map<MovieDto>(movie);
            return movieDto;
        }
    }

}