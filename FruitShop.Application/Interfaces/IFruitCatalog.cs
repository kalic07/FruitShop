using FruitShop.Application.Catalog;

namespace FruitShop.Application.Interfaces
{
    public interface IFruitCatalog
    {
        FruitDefinition GetByName(string name);
    }
}
