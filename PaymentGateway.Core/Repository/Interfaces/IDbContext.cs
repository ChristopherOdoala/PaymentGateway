using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static PaymentGateway.Core.Models.BaseEntity;

namespace PaymentGateway.Core.Repository.Interfaces
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : AuditedEntity;
        void SetAsAdded<TEntity>(TEntity entity) where TEntity : AuditedEntity;
        void SetAsModified<TEntity>(TEntity entity) where TEntity : AuditedEntity;
        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : AuditedEntity;
        void SetAsDetached<TEntity>(TEntity entity) where TEntity : AuditedEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void BeginTransaction();
        int Commit();
        void Rollback();
        Task<int> CommitAsync();

    }
}
