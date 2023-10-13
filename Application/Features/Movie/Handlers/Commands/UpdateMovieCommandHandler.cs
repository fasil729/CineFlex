using AutoMapper;
using FluentValidation;
using Application.DTOs.Movie;
using Application.Exceptions;
using Application.Features.Movies.Requests.Commands;
using Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Movie.Validators;

namespace Application.Features.Movies.Handlers.Commands
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, MovieDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDTO> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMovieDTOValidator();
            var validationResult = await validator.ValidateAsync(request.updateMovieDTO);

            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            var movie = await _movieRepository.GetDetail(request.updateMovieDTO.MovieId);
            if (movie == null)
            {
                throw new NotFoundException("Movie", request.updateMovieDTO.MovieId);
            }

            _mapper.Map(request, movie);
            await _movieRepository.Update(movie);

            var movieDTO = _mapper.Map<MovieDTO>(movie);
            return movieDTO;
        }
    }

    
}