using MediatR;
using MovieAPI.Application.Responses;

namespace MovieAPI.Application.Features.Movies.Requests.Commands
{
    public class DeleteMovieCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}