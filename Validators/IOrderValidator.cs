using OrderApiSOLID.Models;

namespace OrderApiSOLID.Validators
{
    public interface IOrderValidator
    {
        void Validate(Order order);
    }
}
