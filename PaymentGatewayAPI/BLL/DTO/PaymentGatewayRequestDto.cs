namespace BLL.DTOs
{
    public class PaymentGatewayRequestDto
    {
        public decimal TotalAmount { get; set; }

        public string TransactionId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }

        public string SuccessUrl { get; set; }

        public string FailUrl { get; set; }

        public string CancelUrl { get; set; }
    }
}