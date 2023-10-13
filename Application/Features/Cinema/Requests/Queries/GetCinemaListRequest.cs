using MediatR;
using MovieAPI.Application.DTOs.Cinema;
using System.Collections.Generic;

namespace MovieAPI.Application.Features.Cinemas.Requests.Queries
{
    public class GetCinemaListQuery : IRequest<List<CinemaDto>>
    {
    }
}