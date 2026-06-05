using FruitShop.Application.Interfaces;
using FruitShop.Application.Pricing;
using FruitShop.Application.Services;
using FruitShop.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace FruitShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPricingEngine, PricingEngine>();

            services.AddSingleton<IPricingStrategyResolver, PerItemPricingResolver>();

            services.AddSingleton<IPricingStrategyResolver, PerKilogramPricingResolver>();

            services.AddSingleton<IPricingStrategyResolver, BulkDiscountPricingResolver>();

            services.AddSingleton<IPricingStrategyFactory, PricingStrategyFactory>();

            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<CreateOrderValidator>();

            return services;
        }
    }
}
