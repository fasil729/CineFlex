using MediatR;
using Application.DTOs.Cinema;
using Application.Responses;

namespace Application.Features.Cinemas.Requests.Commands
{
    public class UpdateCinemaCommand : IRequest<BaseCommandResponse>
    {
        public UpdateCinemaDTO updateCinemaDTO {get; set;}
    }
}