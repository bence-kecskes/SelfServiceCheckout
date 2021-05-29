using AutoMapper;
using DigitalThinkers.SelfServiceCheckout.Data.Repositories;
using DigitalThinkers.SelfServiceCheckout.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Logic.Services
{
    public class StockService
    {
        private IMapper mapper;
        private IBanknoterepository banknoterepository;
        public StockService(IMapper mapper, IBanknoterepository banknoterepository)
        {
            this.mapper = mapper;
            this.banknoterepository = banknoterepository;
        }

        public async Task<IEnumerable<Banknote>> GetBanknotesInLcyAsync()
        {
            var result = await banknoterepository.GetAllAsync();
            return mapper.Map<IEnumerable<Banknote>>(result);
        }

    }
}
