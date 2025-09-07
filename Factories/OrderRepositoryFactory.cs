using OrderApiSOLID.Repositories;

namespace OrderApiSOLID.Factories
{
    public class OrderRepositoryFactory : IOrderRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public OrderRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IOrderRepository GetRepository(string type)
        {
            return type.ToLower() switch
            {
                "sql" => _serviceProvider.GetService<SqlOrderRepository>()!,
                "mongo" => _serviceProvider.GetService<MongoOrderRepository>()!,
                _ => throw new ArgumentException("Invalid repository type")
            };
        }
    }
}
