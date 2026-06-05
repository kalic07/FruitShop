using FruitShop.Application.Catalog;
using FruitShop.Application.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FruitShop.Infrastructure.Catalog
{
    public sealed class JsonFruitCatalog : IFruitCatalog
    {

        private static readonly JsonSerializerOptions JsonOptions =
        new()
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }

        };

        private readonly Dictionary<string, FruitDefinition> _fruits;

        public JsonFruitCatalog()
        {

            // Arrange
            var projectDirectory =
                Directory.GetParent(AppContext.BaseDirectory)!
                    .Parent!
                    .Parent!
                    .Parent!;

            var jsonPath = Path.Combine(projectDirectory.FullName, "fruits.json");

            var json = File.ReadAllText(jsonPath);

            var fruits = JsonSerializer.Deserialize<List<FruitDefinition>>(json, JsonOptions)!;

            if (fruits is null)
            {
                throw new InvalidOperationException(
                    "Unable to load fruit catalog.");
            }

            _fruits = fruits.ToDictionary(
                x => x.Name,
                StringComparer.OrdinalIgnoreCase);
        }

        public FruitDefinition GetByName(string name)
        {
            if (!_fruits.TryGetValue(name, out var fruit))
            {
                throw new KeyNotFoundException(
                    $"Fruit '{name}' was not found.");
            }

            return fruit;
        }
    }
}
