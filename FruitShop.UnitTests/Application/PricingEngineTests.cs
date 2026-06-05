using FruitShop.Application.Services;
using FruitShop.Domain.Entities;
using FruitShop.Domain.Pricing;

namespace FruitShop.UnitTests.Application
{
    public class PricingEngineTests
    {
        [Fact]
        public void CalculateTotal_Should_Return_Order_Total()
        {
            // Arrange
            var order = new Order();

            order.AddItem(
                new OrderItem(
                    new Fruit(
                        "Apple",
                        2m,
                        new PerKilogramPricingStrategy()),
                    2));

            order.AddItem(
                new OrderItem(
                    new Fruit(
                        "Banana",
                        0.30m,
                        new PerItemPricingStrategy()),
                    10));

            var engine = new PricingEngine();

            // Act
            var total = engine.CalculateTotal(order);

            // Assert
            Assert.Equal(7m, total);
        }
    }
}
