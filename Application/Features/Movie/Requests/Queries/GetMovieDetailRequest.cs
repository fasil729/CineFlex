using MediatR;
using Application.DTOs.Movie;

namespace Application.Features.Movies.Requests.Queries
{
    public class GetMovieDetailQuery : IRequest<MovieDTO>
    {
        public int Id { get; set; }
    }
}