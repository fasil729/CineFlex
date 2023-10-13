using MediatR;
using Application.DTOs.Movie;
using System.Collections.Generic;

namespace Application.Features.Movies.Requests.Queries
{
    public class SearchMovieQuery : IRequest<List<MovieDTO>>
    {
        public string SearchTerm { get; set; }
    }
}