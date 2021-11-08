using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceStore.Services;
using EcommerceStore.Models;
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
        public async Task<IActionResult> Laptop(string[] Category)
        {
            var laptop = await _productService.GetLaptopAsync(Category);
            return View(laptop);
        }
        public async Task<IActionResult> Smart(string[] Category)
        {
            var smart = await _productService.GetSmartAsync(Category);
            return View(smart);
        }
        public async Task<IActionResult> Accessory(string[] Category)
        {
            var accessory = await _productService.GetAccessoryAsync(Category);
            return View(accessory);
        }
        public async Task<IActionResult> Product(ProductViewModel product,int id)
        {
            product = await _productService.GetProductAsync(id);
            product.Descriptions = await _productService.GetDescriptionAsync(id);
            product.Evalutions = await _productService.GetEvaluationAsync(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> InsertEvaluation(ProductViewModel product)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Home");
            await _productService.InsertEvalution(User, product);
            return RedirectToAction("Laptop");
        }
    }
}
