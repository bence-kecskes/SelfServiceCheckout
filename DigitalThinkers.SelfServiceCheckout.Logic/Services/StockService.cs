﻿using AutoMapper;
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
        private IBanknoteRepository banknoteRepository;
        private ICurrencyRepository currencyRepository;
        public StockService(IMapper mapper, IBanknoteRepository banknoteRepository, ICurrencyRepository currencyRepository)
        {
            this.mapper = mapper;
            this.banknoteRepository = banknoteRepository;
            this.currencyRepository = currencyRepository;
        }

        public async Task<IEnumerable<Banknote>> GetBanknotesInLcyAsync()
        {
            var result = await banknoteRepository.GetAllAsync();
            return mapper.Map<IEnumerable<Banknote>>(result);
        }

        public async Task<IEnumerable<Banknote>> InsertBanknotesInLcyAsync(IEnumerable<Banknote> banknotes)
        {
            var mappedBanknotes = mapper.Map<IEnumerable<Data.Entities.Banknote>>(banknotes);
            var lcyId = await currencyRepository.GetLcyAsync();
            mappedBanknotes.ToList().ForEach(b => b.CurrencyId = lcyId.Id);
            banknoteRepository.AddOrUpdate(mappedBanknotes);
            var result = await banknoteRepository.GetAllAsync();
            return mapper.Map<IEnumerable<Banknote>>(result);
        }
    }
}
