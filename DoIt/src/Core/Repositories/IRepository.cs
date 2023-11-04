using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Core.Entities;

namespace DoIt.Core.Repositories;

public interface IRepository<T> where T : IEntity
{
    Task<T> GetByIdAsync(int id);

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
