﻿using Domain.Abstractions;

namespace Infrastructure.Repositories;


internal abstract class Repository<T>
where T : Entity
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Add(T entity)
    {
        DbContext.Add(entity);
    }

    public void Update(T entity)
    {
        DbContext.Update(entity);
    }

    public void Delete(T entity)
    {
        DbContext.Remove(entity);
    }
}
