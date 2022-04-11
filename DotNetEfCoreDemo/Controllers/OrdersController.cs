using DotNetEfCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetEfCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersService _ordersService;

        public OrdersController(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] string search, int skip = 0, int take = 5)
        {
            return Ok(await _ordersService.SearchOrders(search, skip, take));
        }

        [HttpGet("sorted")]
        public async Task<IActionResult> GetSortedOrders([FromQuery] string search, int skip = 0, int take = 5)
        {
            return Ok(await _ordersService.SearchOrdersOrdered(search, skip, take));
        }
    }
}
