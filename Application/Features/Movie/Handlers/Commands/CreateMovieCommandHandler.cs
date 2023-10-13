using AutoMapper;
using FluentValidation;
using Application.DTOs.Movie;
using Application.Features.Movies.Requests.Commands;
using Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Movie.Validators;
using Domain.Entities;

namespace Application.Features.Movies.Handlers.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public CreateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDTO> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMovieDTOValidator();
            var validationResult = await validator.ValidateAsync(request.createMovieDTO);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var movie = _mapper.Map<Movie>(request);
            await _movieRepository.Add(movie);

            var movieDTO = _mapper.Map<MovieDTO>(movie);
            return movieDTO;
        }
    }

}