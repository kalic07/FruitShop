using FruitShop.Domain.Entities;
using FruitShop.Domain.Pricing;

namespace FruitShop.UnitTests.Domain
{
    public class FruitTests
    {
        [Fact]
        public void Constructor_Should_Set_All_Properties()
        {
            // Arrange
            const string name = "Apple";
            const decimal basePrice = 2.00m;

            var pricingStrategy = new PerKilogramPricingStrategy();

            // Act
            var fruit = new Fruit(
                name,
                basePrice,
                pricingStrategy);

            // Assert
            Assert.Equal(name, fruit.Name);
            Assert.Equal(basePrice, fruit.BasePrice);
            Assert.Same(pricingStrategy, fruit.PricingStrategy);
        }



        [Fact]
        public void Constructor_Should_Create_Valid_Fruit()
        {
            // Arrange
            var strategy = new PerItemPricingStrategy();

            // Act
            var fruit = new Fruit(
                "Banana",
                0.30m,
                strategy);

            // Assert
            Assert.NotNull(fruit);
            Assert.Equal("Banana", fruit.Name);
            Assert.Equal(0.30m, fruit.BasePrice);
        }
    }
}
