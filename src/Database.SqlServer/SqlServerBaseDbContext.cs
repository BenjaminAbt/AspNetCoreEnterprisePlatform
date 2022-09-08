// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer;


public abstract class SqlServerBaseDbContext : DbContext, ISqlServerDbContext
{

    public SqlServerBaseDbContext(DbContextOptions options) : base(options) { } // Required for dependency injection

    public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
    => base.Set<TEntity>();

    public EntityEntry<TEntity> Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
        => base.Remove(entity);

    public new EntityEntry<TEntity> Attach<TEntity>(TEntity entry) where TEntity : BaseEntity
        => base.Attach(entry);

    public new EntityEntry<TEntity> Entry<TEntity>(TEntity entry) where TEntity : BaseEntity
        => base.Entry(entry);

    public async Task<DbSaveChangesResult> SaveChangesAsync(CancellationToken cancellationToken, bool updateChangeTrackerStates)
         => new DbSaveChangesResult(
             await SaveChangesAsync(updateChangeTrackerStates, cancellationToken)
             .ConfigureAwait(false));
}
