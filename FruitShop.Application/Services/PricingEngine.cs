using FruitShop.Application.Interfaces;
using FruitShop.Domain.Entities;

namespace FruitShop.Application.Services
{
    public class PricingEngine : IPricingEngine
    {
        public decimal CalculateTotal(Order order)
        {
            return order.Items.Sum(line => line.Fruit.PricingStrategy.CalculatePrice(line.Fruit.BasePrice, line.Quantity));
        }
    }
}
