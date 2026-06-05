using FruitShop.Domain.Entities;
using FruitShop.Domain.Pricing;

namespace FruitShop.UnitTests.Domain;

public class OrderItemTests
{
    [Fact]
    public void Constructor_Should_Create_OrderItem()
    {
        // Arrange
        var fruit = new Fruit("Apple", 2m, new PerKilogramPricingStrategy());

        // Act
        var item = new OrderItem(fruit, 3);

        // Assert
        Assert.Equal(3, item.Quantity);
        Assert.Equal(fruit, item.Fruit);
    }
}