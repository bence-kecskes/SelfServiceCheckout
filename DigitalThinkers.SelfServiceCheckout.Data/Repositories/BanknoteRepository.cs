using DigitalThinkers.SelfServiceCheckout.Data.Context;
using DigitalThinkers.SelfServiceCheckout.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.Repositories
{
    public class BanknoteRepository : GenericRepository<Banknote>
    {
        public BanknoteRepository(SelfServiceCheckoutDbContext dbContext) : base(dbContext) { }

    }
}
