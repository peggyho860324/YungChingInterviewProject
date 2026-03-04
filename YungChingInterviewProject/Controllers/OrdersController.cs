using Microsoft.AspNetCore.Mvc;
using YungChingInterviewProject.DTOs.Order;
using YungChingInterviewProject.Services;

namespace YungChingInterviewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderManagementService _service;

        public OrdersController(OrderManagementService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]QueryOrderRequest reuqest)
        {
            var result = await _service.QueryOrderAsync(reuqest);
            return Ok(result);
        }
    }
}
