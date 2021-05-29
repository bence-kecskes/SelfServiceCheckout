using DigitalThinkers.SelfServiceCheckout.Data.Context;
using DigitalThinkers.SelfServiceCheckout.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.Repositories
{
    public class BanknoteRepository : GenericRepository<Banknote>, IBanknoterepository
    {
        public BanknoteRepository(SelfServiceCheckoutDbContext dbContext) : base(dbContext) { }

        public override async Task<IEnumerable<Banknote>> GetAllAsync()
        {
            return await DbSet.Where(b => b.Currency.IsLocalCurrency).ToListAsync();
        }
    }
}
