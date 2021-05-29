using DigitalThinkers.SelfServiceCheckout.Data.Context;
using DigitalThinkers.SelfServiceCheckout.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private SelfServiceCheckoutDbContext selfServiceCheckoutDbContext;
        protected DbSet<TEntity> DbSet { get; }
        public GenericRepository(SelfServiceCheckoutDbContext selfServiceCheckoutDbContext)
        {
            this.selfServiceCheckoutDbContext = selfServiceCheckoutDbContext;
            DbSet = selfServiceCheckoutDbContext.Set<TEntity>();
        }
        public virtual void Delete(int id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await DbSet.ToListAsync();
        public virtual async Task<EntityEntry<TEntity>> AddAsync(TEntity entity) => await DbSet.AddAsync(entity);
        public virtual async void AddRangeAsync(IEnumerable<TEntity> entities) => await DbSet.AddRangeAsync(entities);
        public virtual async Task<int> SaveChangesAsync() => await selfServiceCheckoutDbContext.SaveChangesAsync();

    }
}
