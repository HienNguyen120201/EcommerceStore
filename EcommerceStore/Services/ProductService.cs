﻿using EcommerceStore.Data;
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
        public async Task<List<ProductViewModel>> GetAccessoryAsync(string[] Category)
        {
            var query = from p in _context.Product
                        select p;
            if (Category.Count() > 0)
            {
                query = from q in query
                        where Category.Contains(q.Producer)
                        select q;
            }
            var accessory  = await (from l in query
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
        public async Task<ProductViewModel> GetProductAsync(int id)
        {
            var product = await (from p in _context.Product
                                 where p.ProductId == id
                                 select new ProductViewModel
                                 {
                                     ImgUrl = p.ImgUrl,
                                     ProductId = p.ProductId,
                                     Name = p.Name,
                                     Price = p.Price,
                                     Producer = p.Producer,
                                     Rating = p.Rating,
                                     Status = p.Status
                                 }).FirstOrDefaultAsync();
            return product;
        }
        public async Task<List<DescriptionViewModel>> GetDescriptionAsync(int productId)
        {
            var des = await (from d in _context.Description
                             join p in _context.Product on d.ProductId equals p.ProductId
                             where d.ProductId == productId
                             select new DescriptionViewModel
                             {
                                 Desc=d.Desc,
                                 ImgUrl=d.ImgUrl
                             }).ToListAsync();
            return des;
        }
    }
}
