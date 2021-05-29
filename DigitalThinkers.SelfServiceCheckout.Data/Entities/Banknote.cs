using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.Entities
{
    public class Banknote : EntityBase<Banknote>
    {
        public int ValueInTCY { get; set; }
        public int Amount { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public override void Configure(EntityTypeBuilder<Banknote> builder)
        {
            builder.HasOne(b => b.Currency)
                   .WithMany(c => c.Banknotes)
                   .HasForeignKey(b => b.CurrencyId)
                   .HasForeignKey(c => c.CurrencyId);
        }
    }
}
