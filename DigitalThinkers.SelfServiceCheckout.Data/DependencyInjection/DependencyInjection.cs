using DigitalThinkers.SelfServiceCheckout.Data.Context;
using DigitalThinkers.SelfServiceCheckout.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.DependencyInjection.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<SelfServiceCheckoutDbContext>(options => options.UseSqlServer(ConnectionString));
            services.AddScoped<IBanknoteRepository, BanknoteRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            return services;
        }
    }
}
