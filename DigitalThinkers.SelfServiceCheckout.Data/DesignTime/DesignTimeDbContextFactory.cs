using DigitalThinkers.SelfServiceCheckout.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.DesignTime
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SelfServiceCheckoutDbContext>
    {
        public SelfServiceCheckoutDbContext CreateDbContext(string[] args)
        {
            return new SelfServiceCheckoutDbContext(
                SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(),
                "Server=(localdb)\\mssqllocaldb;Database=SelfServiceCheckoutDB;Trusted_Connection=True").Options
                );
        }
    }
}
