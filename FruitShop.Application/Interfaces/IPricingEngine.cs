using FruitShop.Domain.Entities;

namespace FruitShop.Application.Interfaces
{
    public interface IPricingEngine
    {
        decimal CalculateTotal(Order order);
    }
}
