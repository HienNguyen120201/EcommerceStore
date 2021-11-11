using EcommerceStore.Models;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public interface ICustomerService
    {
        Task<int> LoginAsync(string username, string password);
        Task<bool> RegisterAsync(RegisterViewModel registerViewModel);
        Task SignOutAsync();
    }
}
