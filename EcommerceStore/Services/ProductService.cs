using EcommerceStore.Data;
using EcommerceStore.Data.Entities;
using EcommerceStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public class ProductService:IProductService
    {
        private readonly ECommerceDbContext _context;
        private readonly UserManager<Customer> _userManager;
        public ProductService(ECommerceDbContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<List<ProductViewModel>> GetLaptopAsync()
        {
            var laptop = await (from l in _context.Product
                                where l.Status == "laptop"
                                select new ProductViewModel
                                {
                                    Name = l.Name,
                                    Producer=l.Producer,
                                    Status=l.Status,
                                    Price = l.Price,
                                    ProductId = l.ProductId,
                                    ImgUrl = l.ImgUrl,
                                    Rating = l.Rating
                                }).ToListAsync();
            return laptop;
        }
        public async Task<List<ProductViewModel>> GetSmartAsync()
        {
            var smart= await (from l in _context.Product
                                where l.Status == "smartphone"
                                select new ProductViewModel
                                {
                                    Name = l.Name,
                                    Producer = l.Producer,
                                    Status = l.Status,
                                    Price = l.Price,
                                    ProductId = l.ProductId,
                                    ImgUrl = l.ImgUrl,
                                    Rating = l.Rating
                                }).ToListAsync();
            return smart;
        }
        public async Task<List<ProductViewModel>> GetAccessoryAsync()
        {
            var accessory  = await (from l in _context.Product
                                where l.Status == "accessory"
                                select new ProductViewModel
                                {
                                    Name = l.Name,
                                    Producer = l.Producer,
                                    Status = l.Status,
                                    Price = l.Price,
                                    ProductId = l.ProductId,
                                    ImgUrl = l.ImgUrl,
                                    Rating = l.Rating
                                }).ToListAsync();
            return accessory;
        }
    }
}
