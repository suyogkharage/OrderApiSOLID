using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApiSOLID.Models;
using OrderApiSOLID.Services;

namespace OrderApiSOLID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] Order order)
        {
            _orderService.PlaceOrder(order, "MONGO", "CreditCard");
            return Ok("Order placed successfully.");
        }
    }
}
