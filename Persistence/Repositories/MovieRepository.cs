using Application.Contracts;
using Domain;
using Domain.Entities;
using Persistence;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }
    }
}