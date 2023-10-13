using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        // Task<List<Movie> Search(int id);
    }
}