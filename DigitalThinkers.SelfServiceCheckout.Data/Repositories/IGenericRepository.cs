using DigitalThinkers.SelfServiceCheckout.Data.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);
        void AddRangeAsync(IEnumerable<TEntity> entities);
        Task<int> SaveChangesAsync();
    }
}
