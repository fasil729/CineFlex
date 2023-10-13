using AutoMapper;
using Application.DTOs.Movie;
using Application.Exceptions;
using Application.Features.Movies.Requests.Queries;
using Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Queries
{
    public class GetMovieDetailQueryHandler : IRequestHandler<GetMovieDetailQuery, MovieDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public GetMovieDetailQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDTO> Handle(GetMovieDetailQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetDetail(request.Id);
            if (movie == null)
            {
                throw new NotFoundException("Movie", request.Id);
            }

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return movieDTO;
        }
    }
}