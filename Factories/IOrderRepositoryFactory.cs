using OrderApiSOLID.Repositories;

namespace OrderApiSOLID.Factories
{
    public interface IOrderRepositoryFactory
    {
        IOrderRepository GetRepository(string type);
    }
}
