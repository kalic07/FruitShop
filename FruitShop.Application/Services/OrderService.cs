using FruitShop.Application.Interfaces;
using FruitShop.Application.Validators;
using FruitShop.Domain.Entities;
using FruitShop.Domain.Interfaces;

namespace FruitShop.Application.Services
{
    public sealed class OrderService : IOrderService
    {
        private readonly CreateOrderValidator _validator;
        private readonly IFruitFactory _fruitFactory;
        private readonly IPricingEngine _pricingEngine;

        public OrderService(
            IFruitFactory fruitFactory,
            IPricingEngine pricingEngine,
            CreateOrderValidator validator)
        {
            _fruitFactory = fruitFactory;
            _pricingEngine = pricingEngine;
            _validator = validator;
        }

        public decimal CalculateOrderTotal(Order request)
        {
            _validator.Validate(request);

            var order = new Order();

            foreach (var item in request.Items)
            {
                var fruit = _fruitFactory.Create(item.Fruit.Name);

                order.AddItem(new OrderItem(fruit, item.Quantity));
            }

            return _pricingEngine.CalculateTotal(order);
        }
    }
}
