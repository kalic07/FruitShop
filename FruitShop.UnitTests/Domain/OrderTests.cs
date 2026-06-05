using FruitShop.Domain.Entities;
using FruitShop.Domain.Pricing;

namespace FruitShop.UnitTests.Domain;

public class OrderTests
{
    [Fact]
    public void AddItem_Should_Add_Item()
    {
        // Arrange
        var order = new Order();

        var fruit = new Fruit(
            "Apple",
            2m,
            new PerKilogramPricingStrategy());

        // Act
        order.AddItem(
            new OrderItem(fruit, 2));

        // Assert
        Assert.Single(order.Items);
    }
}