using FruitShop.Domain.Interfaces;

namespace FruitShop.Domain.Entities
{
    public sealed class Fruit
    {
        public string Name { get; }
        public decimal BasePrice { get; }
        public IPricingStrategy PricingStrategy { get; }

        public Fruit(string name, decimal basePrice, IPricingStrategy pricingStrategy)
        {
            Name = name;
            BasePrice = basePrice;
            PricingStrategy = pricingStrategy;
        }
    }
}
