using EcommerceStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetLaptopAsync(string[] Category);
        Task<List<ProductViewModel>> GetSmartAsync(string[] Category);
        Task<List<ProductViewModel>> GetAccessoryAsync(string[] Category);
        Task<ProductViewModel> GetProductAsync(int id);
        Task<List<DescriptionViewModel>> GetDescriptionAsync(int productId);
        Task<List<EvaluationViewModel>> GetEvaluationAsync(int productId);
        Task InsertEvalutionAsync(ClaimsPrincipal user, ProductViewModel product);
        Task InsertProductAsync(ClaimsPrincipal user, ProductViewModel product);
    }
}
