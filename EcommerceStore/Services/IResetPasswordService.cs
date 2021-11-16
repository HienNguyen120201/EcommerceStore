using EcommerceStore.Models;
using System;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public interface IResetPasswordService
    {
        public Task<bool> SendMailResetPasswordAsync(string username);
        public Task<bool> ResetPasswordAsync(Guid customerId, ResetPasswordViewModel resetPasswordViewModel);
    }
}
