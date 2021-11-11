using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceStore.Services;
using EcommerceStore.Models;

namespace EcommerceStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> Revenue()
        {
            var revenue = await _adminService.GetRevenuesAsync();
            return View(revenue);
        }
        public IActionResult Account()
        {
            return View();
        }
        public async Task<IActionResult> AdminProduct()
        {
            var product = await _adminService.GetAdminProductAsync();
            return View(product);
        }
        public IActionResult InsertProductToDb(InsertProductToDBViewModel product)
        {
            _adminService.InsertProductToDbAsync(product);
            return RedirectToAction("AdminProduct","Admin");
        }
    }
}
