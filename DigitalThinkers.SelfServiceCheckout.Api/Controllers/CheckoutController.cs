using DigitalThinkers.SelfServiceCheckout.Logic.Models;
using DigitalThinkers.SelfServiceCheckout.Logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalThinkers.SelfServiceCheckout.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class CheckoutController : ControllerBase
    {
        private CheckoutService checkoutService;
        public CheckoutController(CheckoutService checkoutService)
        {
            this.checkoutService = checkoutService;
        }
        [HttpPost]
        public async Task<IEnumerable<Banknote>> PostAsync([FromBody] InsertedBanknotes insertedBanknotes)
        {
            var result = checkoutService.Checkout(insertedBanknotes);
            return await result;
        }
    }
}
