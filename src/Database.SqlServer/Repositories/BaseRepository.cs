// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer.Repositories;

public abstract class BaseRepository<T> where T : BaseEntity
{
    protected readonly ISqlServerDbContext DbContext;

    protected readonly DbSet<T> EntitySet;

    public BaseRepository(ISqlServerDbContext dbContext)
    {
        DbContext = dbContext;
        EntitySet = DbContext.Set<T>();
    }

    public ValueTask<EntityEntry<T>> Add(T entity)
    {
        return EntitySet.AddAsync(entity);
    }

    public T Attach(T entity)
    {
        DbContext.Attach(entity);
        return entity;
    }

    public T Delete(T entity)
    {
        DbContext.Delete(entity);
        return entity;
    }
}
