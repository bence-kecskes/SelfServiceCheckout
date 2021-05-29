using DigitalThinkers.SelfServiceCheckout.Data.Entities;
using DigitalThinkers.SelfServiceCheckout.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.Context
{
    public class SelfServiceCheckoutDbContext : DbContext
    {
        public SelfServiceCheckoutDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Banknote> Banknotes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(AuditInterceptor.Instance);
        }
    }
}
