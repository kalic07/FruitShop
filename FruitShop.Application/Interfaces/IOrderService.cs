using FruitShop.Domain.Entities;

namespace FruitShop.Application.Interfaces
{
    public interface IOrderService
    {
        decimal CalculateOrderTotal(Order request);
    }
}
