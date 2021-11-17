using EcommerceStore.Data;
using EcommerceStore.Data.Entities;
using EcommerceStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly SignInManager<Customer> _signInManager;
        private readonly UserManager<Customer> _userManager;
        private readonly ECommerceDbContext _context;
        public CustomerService(
            SignInManager<Customer> signInManager,
            UserManager<Customer> userManager,
            ECommerceDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        public async Task<int> LoginAsync(string username, string password)
        {
            var customer = await _userManager.FindByNameAsync(username);
            if (customer == null)
            {
                return 1;
            }
            var adminId = (from u in _context.Customer
                           where u.UserName == username
                           select u.Admin).FirstOrDefault();
            if (adminId==false)
            {
                var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
                if (result.Succeeded)
                { return 2; }
                else
                {
                    return 1;
                }
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
                if (result.Succeeded)
                { return 3; }
                else
                {
                    return 1;
                }
            }    
        }

        public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
        {
            if (registerViewModel.Password != registerViewModel.RePassword) return false;

            var customer = await _userManager.FindByNameAsync(registerViewModel.UserName);
            if (customer != null)
            {
                return false;
            }

            var newCustomer = new Customer()
            {
                Id = System.Guid.NewGuid(),
                UserName = registerViewModel.UserName,
                PhoneNumber = registerViewModel.PhoneNumber,
                FullName = registerViewModel.FullName,
                Gender = registerViewModel.Gender,
                BirthDay=registerViewModel.Birthday,
                Email=registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(newCustomer, registerViewModel.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task<List<ProductViewModel>> GetAllProductAsync()
        {
            var products = await (from p in _context.Product
                                  select new ProductViewModel
                                  {
                                      ImgUrl = p.ImgUrl,
                                      ProductId = p.ProductId,
                                      Name = p.Name,
                                      Price = p.Price,
                                      Producer = p.Producer,
                                      Rating = p.Rating,
                                      Status = p.Status,
                                      Special = p.Special,
                                      SellOff = p.SellOff,
                                      TimeSellOff = p.TimeSellOff
                                  }).ToListAsync();
            return products;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
