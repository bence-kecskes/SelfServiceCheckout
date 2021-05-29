using DigitalThinkers.SelfServiceCheckout.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Data.Repositories
{
    public interface ICurrencyRepository : IGenericRepository<Currency>
    {
        Task<Currency> GetLcyAsync();
    }
}
