using MediatR;
using MovieAPI.Application.DTOs.Movie;

namespace MovieAPI.Application.Features.Movies.Requests.Queries
{
    public class GetMovieDetailQuery : IRequest<MovieDto>
    {
        public int Id { get; set; }
    }
}