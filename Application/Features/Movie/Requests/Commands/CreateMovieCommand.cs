using MediatR;
using MovieAPI.Application.DTOs.Movie;

namespace MovieAPI.Application.Features.Movies.Requests.Commands
{
    public class CreateMovieCommand : IRequest<MovieDto>
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
    }
}