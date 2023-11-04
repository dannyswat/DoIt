using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Core.Entities;
using DoIt.Core.Repositories;

namespace DoIt.Core.Models;

public abstract class CRUDModel<TEntity, TRepository> 
    where TEntity : IAggregateRoot
    where TRepository : IRepository<TEntity>
{
    protected TRepository Repository { get; }

    public CRUDModel(TRepository repository)
    {
        Repository = repository;
    }

    public async Task<TEntity?> GetById(int id)
    {
        return await Repository.GetByIdAsync(id);
    }

    public async Task Add(TEntity entity)
    {
        if (entity.Id != default)
        {
            throw new ArgumentException("Id must be default");
        }

        await Validate(entity);

        await Repository.AddAsync(entity);
    }

    public async Task Update(TEntity entity)
    {
        if (entity.Id == default)
        {
            throw new ArgumentException("Id must not be default");
        }

        TEntity? currentEntity = await GetById(entity.Id);

        if (currentEntity == null)
        {
            throw new ArgumentException("Entity not found");
        }

        await Compare(currentEntity, entity);

        await Validate(entity);

        await Repository.UpdateAsync(entity);
    }

    public async Task<TEntity> Delete(int id)
    {
        if (id == default)
        {
            throw new ArgumentException("Id must not be default");
        }

        TEntity? currentEntity = await GetById(id);

        if (currentEntity == null)
        {
            throw new ArgumentException("Entity not found");
        }

        await Deleting(currentEntity);

        await Repository.DeleteAsync(currentEntity);

        await Deleted(currentEntity);

        return currentEntity;
    }

/// <summary>
/// Please override this method and call the base method first.
/// </summary>
/// <param name="currentEntity">Entity from database</param>
/// <param name="newEntity">Entity updated</param>
/// <exception cref="ArgumentException"></exception>
/// <returns></returns>
    public virtual Task Compare(TEntity currentEntity, TEntity newEntity)
    {
        if (!currentEntity.RowVersion.SequenceEqual(newEntity.RowVersion))
        {
            throw new ArgumentException("The record has been modified by another user.");
        }

        return Task.CompletedTask;
    }

/// <summary>
/// Validate the entity before adding or updating. Please override this method.
/// </summary>
/// <param name="entity"></param>
/// <returns></returns>
    public virtual Task Validate(TEntity entity)
    {
        return Task.CompletedTask;
    }

    public virtual Task Adding(TEntity entity)
    {
        return Task.CompletedTask;
    }

    public virtual Task Added(TEntity entity)
    {
        return Task.CompletedTask;
    }

    public virtual Task Updating(TEntity entity)
    {
        return Task.CompletedTask;
    }

    public virtual Task Updated(TEntity entity)
    {
        return Task.CompletedTask;
    }

    public virtual Task Deleting(TEntity entity)
    {
        return Task.CompletedTask;
    }

    public virtual Task Deleted(TEntity entity)
    {
        return Task.CompletedTask;
    }
}
