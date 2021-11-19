using EcommerceStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public interface ICustomerService
    {
        Task<List<ProductViewModel>> GetAllProductAsync();
        Task<int> LoginAsync(string username, string password);
        Task<bool> RegisterAsync(RegisterViewModel registerViewModel);
        Task SignOutAsync();
    }
}
