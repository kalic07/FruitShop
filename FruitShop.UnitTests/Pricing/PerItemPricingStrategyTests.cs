using FruitShop.Domain.Pricing;

namespace FruitShop.UnitTests.Pricing
{
    public class PerItemPricingStrategyTests
    {
        [Fact]
        public void CalculatePrice_ReturnsExpectedValue()
        {
            // Arrange
            var strategy = new PerItemPricingStrategy();

            // Act
            var result = strategy.CalculatePrice(0.30m, 5);

            // Assert
            Assert.Equal(1.50m, result);
        }

        [Fact]
        public void CalculatePrice_Should_Return_Total()
        {
            // Arrange
            var strategy = new PerItemPricingStrategy();

            // Act
            var result =
                strategy.CalculatePrice(
                    0.30m,
                    10);

            // Assert
            Assert.Equal(3.0m, result);
        }


        [Theory]
        [InlineData(0.30, 5, 1.50)]
        [InlineData(1.00, 10, 10.00)]
        [InlineData(2.50, 2, 5.00)]
        public void CalculatePrice_Should_Return_Correct_Total(decimal price, decimal quantity, decimal expected)
        {
            // Arrange
            var strategy = new PerItemPricingStrategy();

            // Act
            var result = strategy.CalculatePrice(price, quantity);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculatePrice_With_Zero_Quantity_Should_Return_Zero()
        {
            // Arrange
            var strategy = new PerItemPricingStrategy();

            // Act
            var result = strategy.CalculatePrice(5m, 0);

            // Assert
            Assert.Equal(0m, result);
        }
    }
}
