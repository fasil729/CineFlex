using AutoMapper;
using Application.DTOs.Movie;
using Application.Features.Movies.Requests.Queries;
using Application.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Queries
{
    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<MovieDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public GetMovieListQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieDTO>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetList();
            var movieDTOs = _mapper.Map<List<MovieDTO>>(movies);

            return movieDTOs;
        }
    }
}