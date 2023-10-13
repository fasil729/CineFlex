using MediatR;
using Application.Responses;

namespace Application.Features.Cinemas.Requests.Commands
{
    public class DeleteCinemaCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}