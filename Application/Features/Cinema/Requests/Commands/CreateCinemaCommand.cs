using MediatR;
using MovieAPI.Application.DTOs.Cinema;

namespace MovieAPI.Application.Features.Cinemas.Requests.Commands
{
    public class CreateCinemaCommand : IRequest<CinemaDto>
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}