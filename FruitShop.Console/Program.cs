using FruitShop.Application;
using FruitShop.Application.Interfaces;
using FruitShop.Domain.Entities;
using FruitShop.Domain.Interfaces;
using FruitShop.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();


services.AddApplication();
services.AddInfrastructure();


var provider = services.BuildServiceProvider();


var fruitFactory =
    provider.GetRequiredService<IFruitFactory>();

var pricingEngine =
    provider.GetRequiredService<IPricingEngine>();

var order = new Order();

order.AddItem(
    new OrderItem(
        fruitFactory.Create("Apple"),
        2.5m));

order.AddItem(
    new OrderItem(
        fruitFactory.Create("Banana"),
        10));

order.AddItem(
    new OrderItem(
        fruitFactory.Create("Cherry"),
        3));

var total =
    pricingEngine.CalculateTotal(order);

Console.WriteLine($"Total: ${total}");