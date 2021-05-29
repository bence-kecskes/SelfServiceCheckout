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
        public BanknoteRepository(SelfServiceCheckoutDbContext selfServiceCheckoutDbContext)
            : base(selfServiceCheckoutDbContext) { }

        public override async Task<IEnumerable<Banknote>> GetAllAsync()
            => await DbSet.Where(b => b.Currency.IsLocalCurrency).ToListAsync();

        public void AddOrUpdate(IEnumerable<Banknote> banknotes)
        {
            List<Banknote> existingBanknotes = DbSet.ToList();
            foreach (var banknote in banknotes)
            {
                var existing = existingBanknotes.FirstOrDefault(e => e.ValueInTCY == banknote.ValueInTCY && e.CurrencyId == banknote.CurrencyId);
                if (existing == null)
                {
                    DbSet.Add(banknote);
                }
                else
                {
                    existing.Amount += banknote.Amount;
                    DbSet.Update(existing);
                }
            }
            SelfServiceCheckoutDbContext.SaveChanges();
        }
    }
}
