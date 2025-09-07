using OrderApiSOLID.Services.Payment;

namespace OrderApiSOLID.Factories
{
    public interface IPaymentProcessorFactory
    {
        IPaymentProcessor GetProcessor(string method);
    }
}
