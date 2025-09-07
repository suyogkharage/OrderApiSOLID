using OrderApiSOLID.Services.Payment;

namespace OrderApiSOLID.Factories
{
    public class PaymentProcessorFactory : IPaymentProcessorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentProcessorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IPaymentProcessor GetProcessor(string method) =>
         method switch
         {
             "CreditCard" => _serviceProvider.GetRequiredService<CreditCardProcessor>(),
             "PayPal" => _serviceProvider.GetRequiredService<PayPalProcessor>(),
             _ => throw new ArgumentException("Unknown payment method")
         };
    }
}
