using MediatR;
using Application.DTOs.Movie;

namespace Application.Features.Movies.Requests.Commands
{
    public class CreateMovieCommand : IRequest<MovieDTO>
    {
      public CreateMovieDTO createMovieDTO {set; get;}
    }
}