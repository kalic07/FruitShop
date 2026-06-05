using FruitShop.Application.Catalog;
using FruitShop.Application.Interfaces;
using FruitShop.Application.Pricing;
using FruitShop.Domain.Enums;
using FruitShop.Domain.Pricing;
using FruitShop.Infrastructure.Factories;

using Moq;

namespace FruitShop.UnitTests.Infrastructure
{
    public sealed class PricingStrategyFactoryTests
    {

        [Fact]
        public void Create_ShouldReturnFruit()
        {
            // Arrange
            var definition = new FruitDefinition
            {
                Name = "Apple",
                BasePrice = 2.00m,
                PricingType = PricingType.PerKg
            };

            var catalogMock = new Mock<IFruitCatalog>();

            catalogMock.Setup(x => x.GetByName("Apple")).Returns(definition);

            var strategyFactoryMock = new Mock<IPricingStrategyFactory>();

            strategyFactoryMock.Setup(x => x.Create(definition)).Returns(new PerKilogramPricingStrategy());

            var factory = new FruitFactory(catalogMock.Object, strategyFactoryMock.Object);

            // Act
            var result = factory.Create("Apple");

            // Assert
            Assert.Equal("Apple", result.Name);
            Assert.Equal(2.00m, result.BasePrice);
            Assert.IsType<PerKilogramPricingStrategy>(result.PricingStrategy);
        }


        [Fact]
        public void Create_ShouldReturnPerKgStrategy()
        {
            // Arrange

            var resolvers =
                new List<IPricingStrategyResolver>
                {
                new PerKilogramPricingResolver(),
                new PerItemPricingResolver(),
                new BulkDiscountPricingResolver()
                };

            var sut = new PricingStrategyFactory(resolvers);

            var definition =
                new FruitDefinition
                {
                    PricingType =
                        PricingType.PerKg
                };

            // Act

            var result = sut.Create(definition);

            // Assert

            Assert.IsType<PerKilogramPricingStrategy>(result);
        }
    }
}
