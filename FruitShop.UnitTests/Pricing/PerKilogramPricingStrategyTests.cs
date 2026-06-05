using FruitShop.Domain.Pricing;

namespace FruitShop.UnitTests.Pricing
{
    public class PerKilogramPricingStrategyTests
    {
        [Fact]
        public void CalculatePrice_Should_Return_Total()
        {
            // Arrange
            var strategy = new PerKilogramPricingStrategy();

            // Act
            var result = strategy.CalculatePrice(2m, 3m);

            // Assert
            Assert.Equal(6m, result);
        }
    }
}
