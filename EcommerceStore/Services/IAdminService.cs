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
    }
}
