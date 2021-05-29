using DigitalThinkers.SelfServiceCheckout.Logic.Models;
using DigitalThinkers.SelfServiceCheckout.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalThinkers.SelfServiceCheckout.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class StockController : ControllerBase
    {
        private StockService stockService;
        public StockController(StockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpGet]
        public async Task<IEnumerable<Banknote>> GetAsync()
        {
            var result = await stockService.GetBanknotesInLcyAsync();
            return result;
        }
        [HttpPost]
        public async Task<IEnumerable<Banknote>> PostAsync([FromBody] IEnumerable<Banknote> banknotes)
        {
            var result = await stockService.InsertBanknotesInLcyAsync(banknotes);
            return result;
        }

    }
}
