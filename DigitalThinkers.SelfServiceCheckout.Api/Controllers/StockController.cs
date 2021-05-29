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
    [Route("api/[controller]")]
    [ApiController]
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
            return await stockService.GetBanknotesInLcyAsync();
        }

    }
}
