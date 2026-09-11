using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IPaymentService
    {
        Task<object> CreatePayment(int orderId);
    }
}
