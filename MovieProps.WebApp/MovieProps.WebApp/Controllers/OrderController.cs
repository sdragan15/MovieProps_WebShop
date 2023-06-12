using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProps.BLL.Contract.DTOs.Order;
using MovieProps.BLL.Contract.Services;

namespace MovieProps.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("getAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderService.GetAllOrders());
        }

        [HttpGet("getOrderedItemsByUserEmail")]
        public async Task<IActionResult> GetOrderedItemsByUserEmail()
        {
            return Ok(await _orderService.GetOrderedItemsByUserEmail());
        }

        [HttpPost("CancelOrder/{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            return Ok(await _orderService.CancelOrder(id));
        }
    }
}
