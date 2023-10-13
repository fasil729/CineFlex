using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ICinemaRepository : IGenericRepository<Cinema>
    {
        // Task<T> GetCinimaShowTime<T>(int CinemaId);
    }
}