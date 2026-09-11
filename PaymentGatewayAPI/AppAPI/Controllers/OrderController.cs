using DAL.EF;
using DAL.EF.Table;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        PaymentDbContext _context;
        public OrderController(PaymentDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetOrder()
        {
            var order = _context.Orders.ToList();
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
