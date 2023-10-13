using MediatR;
using Application.DTOs.Cinema;
using System.Collections.Generic;

namespace Application.Features.Cinemas.Requests.Queries
{
    public class GetCinemaListQuery : IRequest<List<CinemaDTO>>
    {
    }
}