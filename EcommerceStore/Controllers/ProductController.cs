using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Laptop()
        {
            var laptop = await _productService.GetLaptopAsync();
            return View(laptop);
        }
        public async Task<IActionResult> Smart()
        {
            var smart = await _productService.GetSmartAsync();
            return View(smart);
        }
        public async Task<IActionResult> Accessory()
        {
            var accessory = await _productService.GetAccessoryAsync();
            return View(accessory);
        }
    }
}
