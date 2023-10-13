using MediatR;
using MovieAPI.Application.DTOs.Cinema;

namespace MovieAPI.Application.Features.Cinemas.Requests.Queries
{
    public class GetCinemaDetailQuery : IRequest<CinemaDto>
    {
        public int Id { get; set; }
    }
}