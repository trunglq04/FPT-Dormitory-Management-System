using DMS_API.Models.Domain;
using DMS_API.Repository.Interface;
using DMS_API.VNPay;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DMS_API.Services
{   
    public class VNPayService : IVNPayService
    {
        IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;
        public VNPayService(IConfiguration config, IUnitOfWork unitOfWork) {
            _config = config;
            _unitOfWork = unitOfWork;
        }
        public async Task<string> CreatePaymentURLAsync(HttpContext context, VnPaymentRequest model)
        {
            var tick = DateTime.Now.Ticks.ToString();

            // Create a new Order object
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = model.OrderId,           // Assign the user ID from the input model to the order
                OrderReference = tick,
                Amount = (float)model.Amount,
                CreatedDate = model.CreatedDate,
                Status = "Pending"
            };

            // Add the new order to the database through the Unit of Work pattern
            await _unitOfWork.Orders.AddAsync(order);

            // Save the changes to the database, persisting the new order
            await _unitOfWork.SaveChanges();

            var vnpay = new VnPayLibrary();
            vnpay.AddRequestData("vnp_Version", _config["VnPay:vnp_Version"]);
            vnpay.AddRequestData("vnp_Command", _config["VnPay:vnp_Command"]);
            vnpay.AddRequestData("vnp_TmnCode", _config["VnPay:vnp_TmnCode"]);
            vnpay.AddRequestData("vnp_Amount", (model.Amount * 100).ToString()); 
            //Số tiền thanh toán. Số tiền không 
            //mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND
            //(một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần(khử phần thập phân), sau đó gửi sang VNPAY
            //là: 10000000
                
            vnpay.AddRequestData("vnp_CreateDate", model.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", _config["VnPay:vnp_CurrCode"]);
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
            vnpay.AddRequestData("vnp_Locale", _config["VnPay:Locale"]);
            vnpay.AddRequestData("vnp_OrderInfo", _config["VnPay:vnp_OrderInfo"] + $" {model.Description}");
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", _config["VnPay:vnp_ReturnUrl"]);
            vnpay.AddRequestData("vnp_TxnRef", tick);
            // Mã tham chiếu của giao dịch tại hệ 
            //thống của merchant.Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY.Không được
              //  trùng lặp trong ngày

            var url = vnpay.CreateRequestUrl(_config["VnPay:vnp_Url"], _config["VnPay:vnp_HashSecret"]);
            return url;
        }

        public VnPaymentResponse PaymentExecute(IQueryCollection collection)
        {
            var vnpay = new VnPayLibrary();
            foreach (var (key,value) in collection)
            {
                if(!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnpay.AddResponseData(key, value.ToString());
                }

            }
            var vnp_OrderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
            var vnp_TransactionId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
            var vnp_SecureHash = collection.FirstOrDefault(p => p.Key == "vnp_SecureHash").Value;
            var vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            var vnp_OrderInfo = vnpay.GetResponseData("vnp_OrderInfo");
            var vnp_Amount = vnpay.GetResponseData("vnp_Amount");
            bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, _config["VnPay:vnp_HashSecret"]);
            if (!checkSignature) 
            {
                return new VnPaymentResponse
                {
                    Success = false,
                };
            }
            else
            {
                return new VnPaymentResponse
                {
                    Success = true,
                    PaymentMethod = "VnPay",
                    OrderDescription = vnp_OrderInfo,
                    OrderId = vnp_OrderId.ToString(),
                    TransactionId = vnp_TransactionId.ToString(),
                    Token = vnp_SecureHash,
                    VnPayResponseCode = vnp_ResponseCode,
                    OrderInfo = vnp_OrderInfo,
                    Amount = float.Parse(vnp_Amount)
                };
            }
        }

        public async Task<bool> UpdateUserBalance(Guid userId, float amount)
        {
            var balance = await _unitOfWork.Balances.GetByUserIdAsync(userId);
            if (balance == null)
            {
                // Create a new balance entry if it doesn't exist
                balance = new Balance
                {
                    UserId = userId,
                    Amount = amount
                };
                await _unitOfWork.Balances.AddAsync(balance);
            }
            else
            {
                // Update the existing balance
                balance.Amount += amount;
                await _unitOfWork.Balances.UpdateBalanceAsync(balance);
            }

            await _unitOfWork.SaveChanges();
            return true;
        }
    }
}
