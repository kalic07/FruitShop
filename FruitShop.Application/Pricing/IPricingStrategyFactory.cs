using FruitShop.Application.Catalog;
using FruitShop.Domain.Interfaces;

namespace FruitShop.Application.Pricing
{
    public interface IPricingStrategyFactory
    {
        IPricingStrategy Create(FruitDefinition definition);
    }
}
