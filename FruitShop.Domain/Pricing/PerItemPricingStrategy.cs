using FruitShop.Domain.Interfaces;

namespace FruitShop.Domain.Pricing
{
    public sealed class PerItemPricingStrategy : IPricingStrategy
    {
        public decimal CalculatePrice(decimal basePrice, decimal quantity)
        {
            return basePrice * quantity;
        }
    }
}
