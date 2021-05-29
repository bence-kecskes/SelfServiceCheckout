using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.Context
{
    public class SelfServiceCheckoutDbContext : DbContext
    {
        public SelfServiceCheckoutDbContext(DbContextOptions options) : base(options) { }

    }
}
