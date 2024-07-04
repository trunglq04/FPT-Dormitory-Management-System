

using DMS_API.VNPay;

namespace DMS_API.Services
{
    public interface IVNPayService
    {
        Task<string> CreatePaymentURLAsync(HttpContext context, VnPaymentRequest model);
        VnPaymentResponse PaymentExecute(IQueryCollection collection);
        Task<bool> UpdateUserBalance(Guid userId, float amount);
    }
}
