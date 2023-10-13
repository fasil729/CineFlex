using AutoMapper;
using MovieAPI.Application.DTOs.Movie;
using MovieAPI.Application.Features.Movies.Requests.Queries;
using MovieAPI.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.Movies.Handlers.Queries
{
    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<MovieDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public GetMovieListQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieDto>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAll();
            var movieDtos = _mapper.Map<List<MovieDto>>(movies);

            return movieDtos;
        }
    }
}