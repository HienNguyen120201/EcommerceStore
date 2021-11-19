using EcommerceStore.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public interface IPaymentService
    {
        Task<BillAndBillDetailViewModel> GetBillDetalsAsync(ClaimsPrincipal user);
        Task<bool> UpdateBillAsync(BillAndBillDetailViewModel bill,ClaimsPrincipal user);
        Task<bool> GetInforBillAsync(ClaimsPrincipal user, BillAndBillDetailViewModel infor);
        Task<bool> UpdateQuantityAsync(ClaimsPrincipal user, BillAndBillDetailViewModel bill);
        Task<bool> GetBillUpdateAsync(ClaimsPrincipal user, BillAndBillDetailViewModel infor);
        Task<bool> DeleteProductAsync(ClaimsPrincipal user, BillAndBillDetailViewModel infor);
        Task<List<PaymentHistoryViewModel>> GetPaymentHistoryAsync(ClaimsPrincipal user);
        Task<List<PaymentDetailViewModel>> GetPaymentDetailAsync(int billId);
        Task UpdatePaymentMethodAsync(ClaimsPrincipal user, PaymentMethodViewModel payment);
        Task<PaymentMethodViewModel> GetPayment(ClaimsPrincipal user);
    }
}
