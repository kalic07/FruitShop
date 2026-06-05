using FruitShop.Domain.Enums;

namespace FruitShop.Application.Catalog
{
    public sealed class FruitDefinition
    {
        public string Name { get; set; } = string.Empty;

        public decimal BasePrice { get; set; }

        public PricingType PricingType { get; set; }

        public decimal? DiscountThreshold { get; set; }

        public decimal? DiscountPercentage { get; set; }
    }
}
