using MediatR;
using MovieAPI.Application.DTOs.Cinema;

namespace MovieAPI.Application.Features.Cinemas.Requests.Commands
{
    public class UpdateCinemaCommand : IRequest<CinemaDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}