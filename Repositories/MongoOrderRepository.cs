using OrderApiSOLID.Models;

namespace OrderApiSOLID.Repositories
{
    public class MongoOrderRepository : IOrderRepository
    {
        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Order order) => Console.WriteLine("Saved in MongoDB");
    }
}
