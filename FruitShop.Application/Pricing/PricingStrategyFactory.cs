using FruitShop.Application.Catalog;
using FruitShop.Application.Interfaces;
using FruitShop.Domain.Enums;
using FruitShop.Domain.Interfaces;

namespace FruitShop.Application.Pricing
{

    public sealed class PricingStrategyFactory : IPricingStrategyFactory
    {
        private readonly IReadOnlyDictionary<PricingType, IPricingStrategyResolver> _resolvers;

        public PricingStrategyFactory(IEnumerable<IPricingStrategyResolver> resolvers)
        {
            _resolvers = resolvers.ToDictionary(x => x.PricingType);
        }

        public IPricingStrategy Create(FruitDefinition definition)
        {
            return _resolvers[definition.PricingType].Create(definition);
        }

    }
}
