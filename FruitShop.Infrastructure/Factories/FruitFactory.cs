using FruitShop.Application.Interfaces;
using FruitShop.Application.Pricing;
using FruitShop.Domain.Entities;
using FruitShop.Domain.Interfaces;


namespace FruitShop.Infrastructure.Factories
{
    public sealed class FruitFactory : IFruitFactory
    {
        private readonly IFruitCatalog _catalog;
        private readonly IPricingStrategyFactory _pricingFactory;

        public FruitFactory(
            IFruitCatalog catalog,
            IPricingStrategyFactory pricingFactory)
        {
            _catalog = catalog;
            _pricingFactory = pricingFactory;
        }

        public Fruit Create(string name)
        {
            var definition =
                _catalog.GetByName(name);

            return new Fruit(
                definition.Name,
                definition.BasePrice,
                _pricingFactory.Create(definition));
        }
    }
}
