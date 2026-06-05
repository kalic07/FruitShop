using FruitShop.Application.Catalog;
using FruitShop.Domain.Enums;
using FruitShop.Domain.Interfaces;

namespace FruitShop.Application.Interfaces
{
    public interface IPricingStrategyResolver
    {
        PricingType PricingType { get; }
        IPricingStrategy Create(FruitDefinition definition);
    }
}
