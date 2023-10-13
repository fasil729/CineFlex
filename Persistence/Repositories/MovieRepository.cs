using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly MovieApiDbContext _dbContext;

        public GenericRepository(MovieApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Movie>> SearchMovies(string searchTerm, int? releaseYear)
{
    searchTerm = searchTerm.ToLowerInvariant();

    var results = _movies.Where(m =>
        m.Title.ToLowerInvariant().Contains(searchTerm) ||
        m.Genre.ToLowerInvariant().Contains(searchTerm) ||
        (releaseYear.HasValue && m.ReleaseYear == releaseYear.Value)
    ).ToList();

    return await Task.FromResult(results);
}
    }