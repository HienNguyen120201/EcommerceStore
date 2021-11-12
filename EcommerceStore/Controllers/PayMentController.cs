using EcommerceStore.Models;
using EcommerceStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceStore.Controllers
{
    public class PayMentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PayMentController (IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet("/payment")]
        public async Task<IActionResult> PayMent()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Home");
            BillAndBillDetailViewModel model = await _paymentService.GetBillDetalsAsync(User);
            if (model == null)
                return View(new BillAndBillDetailViewModel());
            await _paymentService.GetInforBillAsync(User, model);
            return View(model);
        }
        [HttpPost("/payment")]
        public async Task<IActionResult> PayMent(BillAndBillDetailViewModel bill)
        {
            await _paymentService.UpdateBillAsync(bill, User);
            return View(bill);
        }
    }
}
