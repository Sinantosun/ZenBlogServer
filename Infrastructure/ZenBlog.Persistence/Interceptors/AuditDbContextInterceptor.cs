﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ZenBlog.Domain.Entites.Common;

namespace ZenBlog.Persistence.Interceptors
{
    public class AuditDbContextInterceptor : SaveChangesInterceptor
    {
        private static readonly Dictionary<EntityState, Action<DbContext, BaseEntity>> Behaviors = new()
        {
            {EntityState.Added,AddedBehavior },
            {EntityState.Modified,ModifiedBehavior}
        };

        private static void AddedBehavior(DbContext context, BaseEntity baseEntity)
        {
            context.Entry(baseEntity).Property(t => t.UpdatedAt).IsModified = false;
            baseEntity.CreatedAt = DateTime.Now;
        }

        private static void ModifiedBehavior(DbContext context, BaseEntity baseEntity)
        {
            context.Entry(baseEntity).Property(t => t.CreatedAt).IsModified = false;
            baseEntity.UpdatedAt = DateTime.Now;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry.Entity is not BaseEntity baseEntity)
                {
                    continue;
                }
                if (entry.State is not EntityState.Added and not EntityState.Modified)
                {
                    continue;
                }

                Behaviors[entry.State](eventData.Context, baseEntity);

            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
