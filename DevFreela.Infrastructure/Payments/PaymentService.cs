using DevFreela.Core.DTOs;
using DevFreela.Core.Services;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        public Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            return Task.FromResult(true);
        }
    }
}