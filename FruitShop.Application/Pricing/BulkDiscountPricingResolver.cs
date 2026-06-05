using FruitShop.Application.Catalog;
using FruitShop.Application.Interfaces;
using FruitShop.Domain.Enums;
using FruitShop.Domain.Interfaces;
using FruitShop.Domain.Pricing;

namespace FruitShop.Application.Pricing
{
    public sealed class BulkDiscountPricingResolver : IPricingStrategyResolver
    {
        public PricingType PricingType => PricingType.BulkDiscount;

        public IPricingStrategy Create(FruitDefinition definition)
        {
            return new BulkDiscountPricingStrategy(definition.DiscountPercentage!.Value, definition.DiscountThreshold!.Value);
        }
    }
}
