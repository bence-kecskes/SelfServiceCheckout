using DigitalThinkers.SelfServiceCheckout.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.Repositories
{
    public interface IBanknoteRepository : IGenericRepository<Banknote>
    {
        void AddOrUpdate(IEnumerable<Banknote> banknotes);
        void RemoveChange(IEnumerable<Banknote> banknotes);
    }
}
