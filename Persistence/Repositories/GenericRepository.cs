using Application.Contracts;
using Persistence;
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
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;  
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();    

        }

        public async Task<T> GetDetail(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);

        }

        public async Task<IReadOnlyList<T>> GetList()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified; 
            await _dbContext.SaveChangesAsync();    
        }
    }
}