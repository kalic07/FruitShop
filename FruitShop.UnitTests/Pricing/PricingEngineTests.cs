using FruitShop.Application.Services;
using FruitShop.Domain.Entities;
using FruitShop.Domain.Pricing;

namespace FruitShop.UnitTests.Pricing
{
    public class PricingEngineTests
    {
        [Fact]
        public void Calculate_ReturnsOrderTotal()
        {
            // Arrange
            var apple = new Fruit("Apple", 2m, new PerKilogramPricingStrategy());

            var banana = new Fruit("Banana", 0.30m, new PerItemPricingStrategy());

            var order = new Order();

            order.AddItem(new OrderItem(apple, 2));

            order.AddItem(new OrderItem(banana, 5));

            var engine = new PricingEngine();

            // Act
            var result = engine.CalculateTotal(order);

            // Assert
            Assert.Equal(5.5m, result);
        }
    }
}
