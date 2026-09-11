using BLL.DTOs;
using Microsoft.Extensions.Configuration;

namespace BLL.Services
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PaymentGatewayService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> CreatePayment(PaymentGatewayRequestDto request)
        {
            var storeId = _configuration["PaymentGateway:StoreId"];
            var storePassword = _configuration["PaymentGateway:StorePassword"];
            var baseUrl = _configuration["PaymentGateway:BaseUrl"];

            var formData = new Dictionary<string, string>
    {
        { "store_id", storeId },
        { "store_passwd", storePassword },

        { "total_amount", request.TotalAmount.ToString("0.00") },
        { "currency", "BDT" },
        { "tran_id", request.TransactionId },

        { "success_url", request.SuccessUrl },
        { "fail_url", request.FailUrl },
        { "cancel_url", request.CancelUrl },

        { "cus_name", request.CustomerName },
        { "cus_email", request.CustomerEmail },
        { "cus_phone", request.CustomerPhone },

        { "cus_add1", "Dhaka" },
        { "cus_city", "Dhaka" },
        { "cus_country", "Bangladesh" },

        { "shipping_method", "NO" },
        { "product_name", "Payment" },
        { "product_category", "General" },
        { "product_profile", "general" }
    };

            var content = new FormUrlEncodedContent(formData);

            try
            {
                var response = await _httpClient.PostAsync(baseUrl, content);

                var result = await response.Content.ReadAsStringAsync();

                return $"HTTP Status: {(int)response.StatusCode}\nResponse: {result}";
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }
    }
}