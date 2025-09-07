using OrderApiSOLID.Factories;
using OrderApiSOLID.Models;
using OrderApiSOLID.Repositories;
using OrderApiSOLID.Services.Notifications;
using OrderApiSOLID.Services.Payment;
using OrderApiSOLID.Validators;

namespace OrderApiSOLID.Services
{
    public class OrderService
    {
        private readonly IOrderRepositoryFactory _orderRepoFactory;
        private readonly IOrderValidator _validator;
        private readonly IPaymentProcessorFactory _paymentProcessorFactory;
        private readonly INotification _notification;

        public OrderService(IOrderRepositoryFactory orderRepo,
                            IOrderValidator validator,
                            IPaymentProcessorFactory paymentProcessor,
                            INotification notification)
        {
            _orderRepoFactory = orderRepo;
            _validator = validator;
            _paymentProcessorFactory = paymentProcessor;
            _notification = notification;
        }

        public void PlaceOrder(Order order, string repoType, string paymentMethod)
        {
            _validator.Validate(order);

            var processor = _paymentProcessorFactory.GetProcessor(paymentMethod);
            processor.Process(order.TotalAmount);

            var repo = _orderRepoFactory.GetRepository(repoType);
            repo.Save(order);

            _notification.Send(order.CustomerEmail, "Your order has been placed successfully!");
        }
    }
}
