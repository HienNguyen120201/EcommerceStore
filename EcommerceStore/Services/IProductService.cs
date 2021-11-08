using EcommerceStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetLaptopAsync();
        Task<List<ProductViewModel>> GetSmartAsync();
        Task<List<ProductViewModel>> GetAccessoryAsync(string[] Category);
        Task<ProductViewModel> GetProductAsync(int id);
        Task<List<DescriptionViewModel>> GetDescriptionAsync(int productId);
    }
}
