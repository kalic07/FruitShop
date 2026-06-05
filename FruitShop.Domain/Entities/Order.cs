namespace FruitShop.Domain.Entities
{
    public sealed class Order
    {
        private readonly List<OrderItem> _items = new();

        public IReadOnlyCollection<OrderItem> Items => _items;

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }
    }
}
