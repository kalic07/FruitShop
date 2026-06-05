using FruitShop.Domain.Interfaces;

namespace FruitShop.Domain.Pricing
{
    public sealed class BulkDiscountPricingStrategy : IPricingStrategy
    {
        private readonly decimal _discountPercentage;
        private readonly decimal _minimumQuantity;

        public BulkDiscountPricingStrategy(decimal discountPercentage,
            decimal minimumQuantity)
        {
            _discountPercentage = discountPercentage;
            _minimumQuantity = minimumQuantity;
        }

        public decimal CalculatePrice(decimal basePrice, decimal quantity)
        {
            var total = basePrice * quantity;

            if (quantity > _minimumQuantity)
            {
                total *= (1 - _discountPercentage);
            }

            return total;
        }
    }
}
