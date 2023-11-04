using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Core.Entities;
using DoIt.Core.Repositories;
using DoIt.Infra.DbContexts;

namespace DoIt.Infra.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly DoItDbContext dbContext;
    
    public Repository(DoItDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task AddAsync(TEntity entity)
    {
        dbContext.Set<TEntity>().Add(entity);
        return dbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(TEntity entity)
    {
        dbContext.Set<TEntity>().Remove(entity);
        return dbContext.SaveChangesAsync();
    }

    public Task<TEntity?> GetByIdAsync(int id)
    {
        return dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public Task UpdateAsync(TEntity entity)
    {
        dbContext.Set<TEntity>().Update(entity);
        return dbContext.SaveChangesAsync();
    }
}
