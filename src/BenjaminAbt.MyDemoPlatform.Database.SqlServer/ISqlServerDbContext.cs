using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer;

public interface ISqlServerDbContext : IDisposable
{
    DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

    EntityEntry<TEntity> Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
    EntityEntry<TEntity> Attach<TEntity>(TEntity entry) where TEntity : BaseEntity;
    EntityEntry<TEntity> Entry<TEntity>(TEntity entry) where TEntity : BaseEntity;

    Task<DbSaveChangesResult> SaveChangesAsync(CancellationToken cancellationToken = default,
        bool updateChangeTrackerStates = true);
}
