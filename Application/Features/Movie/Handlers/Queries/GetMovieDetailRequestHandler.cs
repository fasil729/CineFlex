using AutoMapper;
using MovieAPI.Application.DTOs.Movie;
using MovieAPI.Application.Exceptions;
using MovieAPI.Application.Features.Movies.Requests.Queries;
using MovieAPI.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.Movies.Handlers.Queries
{
    public class GetMovieDetailQueryHandler : IRequestHandler<GetMovieDetailQuery, MovieDto>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public GetMovieDetailQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle(GetMovieDetailQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetById(request.Id);
            if (movie == null)
            {
                throw new NotFoundException("Movie", request.Id);
            }

            var movieDto = _mapper.Map<MovieDto>(movie);

            return movieDto;
        }
    }
}