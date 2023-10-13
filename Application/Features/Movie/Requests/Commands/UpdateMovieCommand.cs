using MediatR;
using Application.DTOs.Movie;

namespace Application.Features.Movies.Requests.Commands
{
    public class UpdateMovieCommand : IRequest<MovieDTO>
    {
       public UpdateMovieDTO updateMovieDTO {set; get;}
    }
}