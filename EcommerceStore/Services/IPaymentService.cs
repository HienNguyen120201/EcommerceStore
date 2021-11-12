using EcommerceStore.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public interface IPaymentService
    {
        Task<BillAndBillDetailViewModel> GetBillDetalsAsync(ClaimsPrincipal user);
        Task<bool> UpdateBillAsync(BillAndBillDetailViewModel bill,ClaimsPrincipal user);
        Task<bool> GetInforBillAsync(ClaimsPrincipal user, BillAndBillDetailViewModel infor);
    }
}
