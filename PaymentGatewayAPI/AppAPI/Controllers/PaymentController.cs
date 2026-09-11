using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePayment(PaymentRequestDto request)
        {
            var result = await _paymentService.CreatePayment(request.OrderId);

            return Ok(result);
        }
    }
}