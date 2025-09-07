using OrderApiSOLID.Models;

namespace OrderApiSOLID.Validators
{
    public class BasicOrderValidator : IOrderValidator
    {
        public void Validate(Order order)
        {
            if (!order.Items.Any())
                throw new Exception("Order must contain at least one item.");
        }
    }
}
