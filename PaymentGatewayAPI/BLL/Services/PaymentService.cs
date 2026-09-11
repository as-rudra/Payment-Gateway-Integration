using BLL.DTOs;
using DAL.EF;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentDbContext _db;
        private readonly IPaymentGatewayService _paymentGatewayService;
        public PaymentService(PaymentDbContext db, IPaymentGatewayService paymentGatewayService)
        {
            _db = db;
            _paymentGatewayService = paymentGatewayService;
        }

        public async Task<object> CreatePayment(int orderId)
        {
            var order = _db.Orders.Find(orderId);

            if (order == null)
            {
                return new
                {
                    Success = false,
                    Message = "Order not found."
                };
            }

            var transactionId = "ORDER_" + order.Id + "_" + DateTime.Now.Ticks;

            var gatewayRequest = new PaymentGatewayRequestDto
            {
                TotalAmount = order.TotalAmount,
                TransactionId = transactionId,
                CustomerName = order.CustomerName,
                CustomerEmail = "customer@example.com",
                CustomerPhone = "01700000000",

                SuccessUrl = "https://localhost:7000/api/Payment/success",
                FailUrl = "https://localhost:7000/api/Payment/fail",
                CancelUrl = "https://localhost:7000/api/Payment/cancel"
            };

            var gatewayResponse =
                await _paymentGatewayService.CreatePayment(gatewayRequest);

            return gatewayResponse;
        }
    }
}