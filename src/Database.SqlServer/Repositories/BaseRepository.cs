// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Entities;

namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer.Repositories;

public abstract class BaseRepository<T> where T : BaseEntity
{
    protected readonly ISqlServerDbContext DbContext;

    public BaseRepository(ISqlServerDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public T Add(T entity)
    {
        DbContext.Set<T>().Add(entity);
        return entity;
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
