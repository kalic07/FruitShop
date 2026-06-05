using FruitShop.Application.Interfaces;
using FruitShop.Domain.Interfaces;
using FruitShop.Infrastructure.Catalog;
using FruitShop.Infrastructure.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace FruitShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection
        AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IFruitFactory, FruitFactory>();

            services.AddSingleton<IFruitCatalog>(
                _ => new JsonFruitCatalog());

            return services;

        }
    }
}
