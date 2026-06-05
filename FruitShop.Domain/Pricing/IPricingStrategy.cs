namespace FruitShop.Domain.Interfaces
{
    public interface IPricingStrategy
    {
        decimal CalculatePrice(decimal basePrice, decimal quantity);
    }
}
