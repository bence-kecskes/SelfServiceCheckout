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
        protected SelfServiceCheckoutDbContext SelfServiceCheckoutDbContext { get; }
        protected DbSet<TEntity> DbSet { get; }
        public GenericRepository(SelfServiceCheckoutDbContext selfServiceCheckoutDbContext)
        {
            SelfServiceCheckoutDbContext = selfServiceCheckoutDbContext;
            DbSet = selfServiceCheckoutDbContext.Set<TEntity>();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await DbSet.ToListAsync();
    }
}
