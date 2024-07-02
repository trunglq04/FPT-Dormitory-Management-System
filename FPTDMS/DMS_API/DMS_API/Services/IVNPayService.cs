

using DMS_API.VNPay;

namespace DMS_API.Services
{
    public interface IVNPayService
    {
        string CreatePaymentURL(HttpContext context, VnPaymentRequest model);
        VnPaymentResponse PaymentExecute(IQueryCollection collection);
    }
}
