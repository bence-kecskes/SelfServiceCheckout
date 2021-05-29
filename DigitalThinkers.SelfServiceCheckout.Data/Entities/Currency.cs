using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.Entities
{
    public class Currency : EntityBase<Currency>
    {
        public string ISOCode { get; set; }
        public decimal RatioToLCY { get; set; }
        public bool IsLocalCurrency { get; set; }
        public IEnumerable<Banknote> Banknotes { get; set; }

        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.Property(c => c.ISOCode).HasMaxLength(3).IsRequired();
            builder.Property(c => c.RatioToLCY).HasPrecision(8, 4).IsRequired();
        }
    }
}
