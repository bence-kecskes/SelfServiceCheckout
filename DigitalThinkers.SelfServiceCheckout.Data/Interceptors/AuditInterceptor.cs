using DigitalThinkers.SelfServiceCheckout.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        private AuditInterceptor() { }

        public static AuditInterceptor Instance { get; } = new();
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            SetTimeStamps(eventData);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            SetTimeStamps(eventData);
            return result;
        }
        private static void SetTimeStamps(DbContextEventData eventData)
        {
            var now = DateTime.Now;
            foreach (var entityEntry in eventData.Context.ChangeTracker.Entries<EntityBase>())
            {
                if (entityEntry.State == EntityState.Added)
                    entityEntry.Entity.Created = now;
                if (entityEntry.State is EntityState.Added or EntityState.Modified)
                    entityEntry.Entity.Modified = now;
            }
        }
    }
}
