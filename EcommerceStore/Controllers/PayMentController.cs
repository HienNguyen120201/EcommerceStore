﻿using EcommerceStore.Models;
using EcommerceStore.Services;
using Microsoft.AspNetCore.Mvc;
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
                model = new BillAndBillDetailViewModel();
            await _paymentService.GetInforBillAsync(User, model);
            return View(model);
        }
        [HttpPost("/payment")]
        public async Task<IActionResult> PayMent(BillAndBillDetailViewModel bill)
        {
            if(bill.Type=="-")
            {
                await _paymentService.UpdateQuantityAsync(User, bill);
                await _paymentService.GetBillUpdateAsync(User, bill);
                return View(bill);
            }
            if (bill.Type == "+")
            {
                await _paymentService.UpdateQuantityAsync(User, bill);
                await _paymentService.GetBillUpdateAsync(User, bill);
                return View(bill);
            }
            if(bill.Type=="d")
            {
                await _paymentService.DeleteProductAsync(User, bill);
                await _paymentService.GetBillUpdateAsync(User, bill);
                return View(bill);
            }
            await _paymentService.UpdateBillAsync(bill, User);
            return View(bill);
        }
        public async Task<IActionResult> PaymentHistory()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var pmHistory = await _paymentService.GetPaymentHistoryAsync(User);
            return View(pmHistory);
        }
        public async Task<IActionResult> PaymentDetailHistory(int id)
        {
            var paymentDetail = await _paymentService.GetPaymentDetailAsync(id);
            return View(paymentDetail);
        }
    }
}
