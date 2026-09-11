using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public interface IPaymentGatewayService
    {
        Task<string> CreatePayment(PaymentGatewayRequestDto request);
    }
}