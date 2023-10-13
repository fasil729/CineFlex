using MediatR;
using MovieAPI.Application.Responses;

namespace MovieAPI.Application.Features.Cinemas.Requests.Commands
{
    public class DeleteCinemaCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}