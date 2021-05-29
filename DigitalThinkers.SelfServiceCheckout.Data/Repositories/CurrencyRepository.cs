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
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(SelfServiceCheckoutDbContext selfServiceCheckoutDbContext)
            : base(selfServiceCheckoutDbContext) { }
        public async Task<Currency> GetLcyAsync() => await DbSet.FirstOrDefaultAsync(c => c.IsLocalCurrency);
    }
}
