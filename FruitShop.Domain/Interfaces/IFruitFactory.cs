using FruitShop.Domain.Entities;

namespace FruitShop.Domain.Interfaces
{
    public interface IFruitFactory
    {
        Fruit Create(string fruit);
    }
}
