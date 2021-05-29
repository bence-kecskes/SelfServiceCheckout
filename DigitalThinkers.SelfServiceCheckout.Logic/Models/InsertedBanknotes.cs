using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Logic.Models
{
    public class InsertedBanknotes
    {
        public IEnumerable<Banknote> Inserted { get; set; }
        public int? Price { get; set; }
    }
}
