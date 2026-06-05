using FruitShop.Domain.Enums;

namespace FruitShop.Infrastructure.Catalog
{
    public sealed class FruitConfiguration
    {
        public string Name { get; set; } = string.Empty;

        public decimal BasePrice { get; set; }

        public PricingType PricingType { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal MinimumQuantity { get; set; }
    }
}
