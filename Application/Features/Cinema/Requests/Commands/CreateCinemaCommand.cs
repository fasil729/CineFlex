using MediatR;
using Application.DTOs.Cinema;
using Application.Responses;

namespace Application.Features.Cinemas.Requests.Commands
{
    public class CreateCinemaCommand : IRequest<BaseCommandResponse>

    {
        public CreateCinemaDTO createCinemaDTO {get; set;}
    }
}