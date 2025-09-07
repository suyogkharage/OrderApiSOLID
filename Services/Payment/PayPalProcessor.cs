namespace OrderApiSOLID.Services.Payment
{
    public class PayPalProcessor : IPaymentProcessor
    {
        public void Process(decimal amount) => Console.WriteLine($"Paid {amount} using PayPal");
    }
}
