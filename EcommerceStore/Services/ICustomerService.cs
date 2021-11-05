using EcommerceStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public interface ICustomerService
    {
        Task<bool> LoginAsync(string username, string password);
        Task<bool> RegisterAsync(RegisterViewModel registerViewModel);
        Task SignOutAsync();
    }
}
