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
    public class AdminService: IAdminService
    {
        private readonly ECommerceDbContext _context;
        private readonly UserManager<Customer> _userManager;
        public AdminService(ECommerceDbContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<List<RevenueViewModel>> GetRevenuesAsync()
        {
            var revenue = await (from b in _context.Bill
                                 where b.PaymentMethod != string.Empty
                                 select new RevenueViewModel
                                 {
                                     BillId=b.BillId,
                                     FullName=b.UserName,
                                     PaymentMethod=b.PaymentMethod,
                                     PhoneNumber=b.PhoneNumber,
                                     TotalPrice=b.TotalPrice
                                 }).ToListAsync();
            return revenue;
        }
        public async Task<List<AdminProductViewModel>> GetAdminProductAsync()
        {
            var product = await (from p in _context.Product
                                 select new AdminProductViewModel
                                 {
                                     ProductId = p.ProductId,
                                     Name = p.Name,
                                     Status = p.Status,
                                     Producer = p.Producer,
                                     Price = p.Price,
                                     ImgUrl = p.ImgUrl,
                                     Rating=p.Rating
                                 }).ToListAsync();
            return product;
        }
        public void InsertProductToDbAsync(InsertProductToDBViewModel product)
        {
            var newProduct = new Product()
            {
                Name = product.Name,
                Status = product.Status,
                Producer = product.Producer,
                Special = product.Special,
                Price = product.Price,
                ImgUrl = product.ImgUrl
            };
            _context.Product.Add(newProduct);
            _context.SaveChanges();
        }
        public async Task<bool> InsertAccountAdminAysnc(InsertAccountAdminViewModel account)
        {
            if (account.Password != account.RePassword) return false;
            var customer = await _userManager.FindByNameAsync(account.UserName);
            if (customer != null)
            {
                return false;
            }
            var newCustomer = new Customer()
            {
                Id = System.Guid.NewGuid(),
                UserName = account.UserName,
                Admin=true,
                FullName = account.FullName,
                Email = account.Email
            };
            var result = await _userManager.CreateAsync(newCustomer, account.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task<List<AdminAccountViewModel>> GetAdminAccountAsync()
        {
            var account = await (from a in _context.Customer
                                 select new AdminAccountViewModel
                                 {
                                     FullName = a.FullName,
                                     Gender = a.Gender,
                                     BirthDay = a.BirthDay,
                                     Point = a.Point
                                 }).ToListAsync();
            return account;
        }
        public void DeleteProduct(int productId)
        {
            var product = (from p in _context.Product
                           where p.ProductId == productId
                           select p).FirstOrDefault();
            _context.Remove(product);
            _context.SaveChanges();
        }
    }
}
