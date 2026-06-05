using FruitShop.Infrastructure.Catalog;

namespace FruitShop.UnitTests.Infrastructure
{
    public class JsonFruitCatalogTests
    {
        [Fact]
        public void Get_Should_Return_Fruit()
        {
            // Arrange
            var catalog = new JsonFruitCatalog();

            // Act

            var fruit = catalog.GetByName("Apple");

            // Assert

            Assert.Equal("Apple", fruit.Name);
            Assert.Equal(2m, fruit.BasePrice);
        }
    }
}
