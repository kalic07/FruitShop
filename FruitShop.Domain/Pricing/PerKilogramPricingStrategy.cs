using FruitShop.Domain.Interfaces;

namespace FruitShop.Domain.Pricing
{
    public sealed class PerKilogramPricingStrategy : IPricingStrategy
    {
        public decimal CalculatePrice(decimal basePrice, decimal quantity)
        {
            return basePrice * quantity;
        }
    }
}
