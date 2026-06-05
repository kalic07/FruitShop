using FruitShop.Domain.Pricing;

namespace FruitShop.UnitTests.Pricing
{
    public class BulkDiscountPricingStrategyTests
    {

        [Fact]
        public void Should_Apply_Discount()
        {
            // Arrange
            var strategy = new BulkDiscountPricingStrategy(0.10m, 2m);

            // Act
            var result = strategy.CalculatePrice(5m, 3m);

            // Assert

            Assert.Equal(13.5m, result);
        }

        [Fact]
        public void Should_Not_Apply_Discount()
        {
            // Arrange
            var strategy = new BulkDiscountPricingStrategy(0.10m, 2m);

            // Act
            var result = strategy.CalculatePrice(5m, 1m);

            // Assert
            Assert.Equal(5m, result);
        }


        [Fact]
        public void CalculatePrice_When_Below_Threshold_Should_Not_Discount()
        {
            // Arrange
            var strategy = new BulkDiscountPricingStrategy(0.10m, 2);

            // Act
            var result = strategy.CalculatePrice(5m, 1.5m);

            // Assert
            Assert.Equal(7.5m, result);
        }

        [Fact]
        public void CalculatePrice_When_Equal_To_Threshold_Should_Not_Discount()
        {
            // Arrange
            var strategy = new BulkDiscountPricingStrategy(0.10m, 2);

            // Act
            var result = strategy.CalculatePrice(5m, 2m);

            // Assert
            Assert.Equal(10m, result);
        }

        [Fact]
        public void CalculatePrice_When_Above_Threshold_Should_Discount()
        {
            // Arrange
            var strategy = new BulkDiscountPricingStrategy(0.10m, 2);

            // Act
            var result = strategy.CalculatePrice(5m, 3m);

            // Assert
            Assert.Equal(13.5m, result);
        }

        [Theory]
        [InlineData(5, 3, 0.10, 13.5)]
        [InlineData(10, 5, 0.20, 40)]
        [InlineData(20, 10, 0.50, 100)]
        public void CalculatePrice_Should_Apply_Discount_Correctly(decimal price, decimal quantity, decimal discount, decimal expected)
        {
            // Arrange
            var strategy = new BulkDiscountPricingStrategy(discount, 2);

            // Act
            var result = strategy.CalculatePrice(price, quantity);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}

