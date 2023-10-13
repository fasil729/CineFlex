using MediatR;
using Application.Responses;

namespace Application.Features.Movies.Requests.Commands
{
    public class DeleteMovieCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}