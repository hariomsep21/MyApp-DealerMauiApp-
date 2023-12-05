using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public interface IPaymnetService
    {
        Task<List<PaymentDetailDto>> GetDuePayments();
        Task<List<PaymentDetailDto>> GetPaymentStatus();
        Task<List<PaymentDetailDto>> GetUpcomingPayment();
        Task<PaymentDetailDto> GetPaymentDetails(int paymentId);
       
    }
}
