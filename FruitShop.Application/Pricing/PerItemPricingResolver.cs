using FruitShop.Application.Catalog;
using FruitShop.Application.Interfaces;
using FruitShop.Domain.Enums;
using FruitShop.Domain.Interfaces;
using FruitShop.Domain.Pricing;

namespace FruitShop.Application.Pricing
{
    public class PerItemPricingResolver : IPricingStrategyResolver
    {

        public PricingType PricingType => PricingType.PerItem;

        public IPricingStrategy Create(FruitDefinition definition)
        {
            return new PerItemPricingStrategy();
        }
    }
}