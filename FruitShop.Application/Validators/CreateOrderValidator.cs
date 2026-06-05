using FruitShop.Domain.Entities;

namespace FruitShop.Application.Validators
{
    public sealed class CreateOrderValidator
    {
        public void Validate(Order order)
        {
            if (order.Items.Count == 0)
                throw new Exception("Order cannot be empty");

            foreach (var item in order.Items)
            {
                if (item.Quantity <= 0)
                    throw new Exception(
                        "Quantity must be greater than 0");
            }
        }
    }
}
