using MediatR;
using Application.DTOs.Cinema;

namespace Application.Features.Cinemas.Requests.Queries
{
    public class GetCinemaDetailQuery : IRequest<CinemaDTO>
    {
        public int Id { get; set; }
    }
}