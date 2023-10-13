using MediatR;
using MovieAPI.Application.DTOs.Movie;
using System.Collections.Generic;

namespace MovieAPI.Application.Features.Movies.Requests.Queries
{
    public class SearchMovieQuery : IRequest<List<MovieDto>>
    {
        public string SearchTerm { get; set; }
    }
}