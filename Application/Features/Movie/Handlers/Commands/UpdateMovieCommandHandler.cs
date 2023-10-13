using AutoMapper;
using FluentValidation;
using MovieAPI.Application.DTOs.Movie;
using MovieAPI.Application.Exceptions;
using MovieAPI.Application.Features.Movies.Requests.Commands;
using MovieAPI.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.Movies.Handlers.Commands
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, MovieDto>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMovieCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var movie = await _movieRepository.GetById(request.Id);
            if (movie == null)
            {
                throw new NotFoundException("Movie", request.Id);
            }

            _mapper.Map(request, movie);
            await _movieRepository.Update(movie);

            var movieDto = _mapper.Map<MovieDto>(movie);
            return movieDto;
        }
    }

    
}