using EcommerceStore.Data;
using EcommerceStore.Data.Entities;
using EcommerceStore.Models;
using Microsoft.AspNetCore.Identity;
using System;
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
        public async Task<bool> LoginAsync(string username, string password)
        {
            var customer = await _userManager.FindByNameAsync(username);
            if (customer == null)
            {
                return false;
            }
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            return result.Succeeded;
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
                Gender = registerViewModel.Gender
            };

            var result = await _userManager.CreateAsync(newCustomer, registerViewModel.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
