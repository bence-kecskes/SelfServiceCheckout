using AutoMapper;
using DigitalThinkers.SelfServiceCheckout.Data.Repositories;
using DigitalThinkers.SelfServiceCheckout.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = DigitalThinkers.SelfServiceCheckout.Data.Entities;

namespace DigitalThinkers.SelfServiceCheckout.Logic.Services
{
    public class CheckoutService
    {
        private readonly IMapper mapper;
        private readonly IBanknoteRepository banknoteRepository;
        public CheckoutService(IMapper mapper, IBanknoteRepository banknoteRepository)
        {
            this.mapper = mapper;
            this.banknoteRepository = banknoteRepository;
        }
        public async Task<IEnumerable<Banknote>> Checkout(InsertedBanknotes insertedBanknotes)
        {
            if (!insertedBanknotes.Price.HasValue) throw new InvalidOperationException();
            var totalInsertedMoney = insertedBanknotes.Inserted.ToList().Sum(b => b.ValueInTCY * b.Amount);
            if (totalInsertedMoney < insertedBanknotes.Price) throw new InvalidOperationException("Not enough money inserted.");

            var change = await GetBackChange(totalInsertedMoney, insertedBanknotes.Price.Value);
            if (!change.isChangeable) throw new InvalidOperationException("Cannot get change");
            banknoteRepository.RemoveChange(change.change);

            var result = mapper.Map<IEnumerable<Banknote>>(change.change);
            return result;
        }

        private async Task<(bool isChangeable, IEnumerable<Entities.Banknote> change)> GetBackChange(int totalInsertedMoney, int price)
        {
            var rounding = price % 5;
            price += (rounding >= 3 ? 5 - rounding : -rounding);
            var remains = totalInsertedMoney - price;
            var availableBanknotes = await banknoteRepository.GetAllAsync();
            List<Entities.Banknote> result = new List<Entities.Banknote>();
            foreach (var availableBanknote in availableBanknotes.Where(a => a.ValueInTCY <= remains).OrderByDescending(a => a.ValueInTCY))
            {
                int wholePart = remains / availableBanknote.ValueInTCY;
                wholePart = Math.Min(wholePart, availableBanknote.Amount);
                if (wholePart > 0)
                {
                    remains -= wholePart*availableBanknote.ValueInTCY;
                    result.Add(new Entities.Banknote()
                    {
                            Id = availableBanknote.Id,
                            ValueInTCY = availableBanknote.ValueInTCY,
                            Amount = wholePart
                    });
                }

            }
            return (remains == 0, result);
        }
    }
}
