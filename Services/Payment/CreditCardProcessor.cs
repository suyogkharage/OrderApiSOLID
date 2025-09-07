namespace OrderApiSOLID.Services.Payment
{
    public class CreditCardProcessor : IPaymentProcessor
    {
        public void Process(decimal amount) => Console.WriteLine($"Paid {amount} using Credit Card");
    }
}
