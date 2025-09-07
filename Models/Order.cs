namespace OrderApiSOLID.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public decimal TotalAmount => Items.Sum(i => i.Price * i.Quantity);
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
