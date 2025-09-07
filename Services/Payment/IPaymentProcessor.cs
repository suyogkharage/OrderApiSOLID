namespace OrderApiSOLID.Services.Payment
{
    public interface IPaymentProcessor
    {
        void Process(decimal amount);
    }
}
