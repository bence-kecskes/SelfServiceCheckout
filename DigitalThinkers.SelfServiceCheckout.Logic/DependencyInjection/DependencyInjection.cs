using AutoMapper;
using DigitalThinkers.SelfServiceCheckout.Logic.MapperProfiles;
using DigitalThinkers.SelfServiceCheckout.Logic.Services;
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
        public static IServiceCollection RegisterLogicServices(this IServiceCollection services)
        {
            services.AddScoped<StockService>();
            services.AddScoped<CheckoutService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new LogicMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}