using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProps.BLL.Contract.DTOs.Order;
using MovieProps.BLL.Contract.Services;

namespace MovieProps.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("createOrder")]
        public async Task<IActionResult> CreateOrder(OrderDataIn dataIn)
        {
            return Ok(await _orderService.CreateOrder(dataIn));
        }

        [HttpGet("getMyOrders")]
        public async Task<IActionResult> GetMyOrders()
        {
            return Ok(await _orderService.GetMyOrders());
        }
    }
}
