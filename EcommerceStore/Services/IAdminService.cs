using EcommerceStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public interface IAdminService
    {
        Task<List<RevenueViewModel>> GetRevenuesAsync();
        Task<List<AdminProductViewModel>> GetAdminProductAsync();
        void InsertProductToDbAsync(InsertProductToDBViewModel product);
        Task<bool> InsertAccountAdminAysnc(InsertAccountAdminViewModel account);
        Task<List<AdminAccountViewModel>> GetAdminAccountAsync();
        void DeleteProduct(int productId);
    }
}
