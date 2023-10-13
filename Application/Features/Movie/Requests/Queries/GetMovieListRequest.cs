using MediatR;
using Application.DTOs.Movie;
using System.Collections.Generic;

namespace Application.Features.Movies.Requests.Queries
{
    public class GetMovieListQuery : IRequest<List<MovieDTO>>
    {
    }
}