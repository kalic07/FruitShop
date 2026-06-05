namespace FruitShop.Domain.Entities
{
    public sealed class OrderItem
    {

        public Fruit Fruit { get; }
        public decimal Quantity { get; }

        public OrderItem(Fruit fruit, decimal quantity)
        {
            Fruit = fruit;
            Quantity = quantity;
        }
    }
}
