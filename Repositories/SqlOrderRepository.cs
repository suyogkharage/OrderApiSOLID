using OrderApiSOLID.Models;

namespace OrderApiSOLID.Repositories
{
    public class SqlOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            // Save order to SQL database (EF Core code here)
            Console.WriteLine("Order saved to SQL DB");
        }

        public Order GetById(int id) => new Order { Id = id, CustomerEmail = "test@domain.com" };
    }
}
