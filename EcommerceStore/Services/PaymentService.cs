using EcommerceStore.Data;
using EcommerceStore.Data.Entities;
using EcommerceStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceStore.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly ECommerceDbContext _context;
        public PaymentService(UserManager<Customer> userManager, ECommerceDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<BillAndBillDetailViewModel> GetBillDetalsAsync(ClaimsPrincipal user)
        {
            var customer = await _userManager.GetUserAsync(user);
            var bill = await (from b in _context.Bill
                                   where b.CustomerId == customer.Id && b.PaymentMethod == string.Empty
                                   select new BillAndBillDetailViewModel
                                   {
                                       Total=b.TotalPrice
                                   }).FirstOrDefaultAsync();
            if (bill == null) return null;
            bill.ListProduct = await (from a in _context.Bill
                                     from b in _context.BillProduct 
                                     from c in _context.Product
                                     where customer.Id == a.CustomerId && a.PaymentMethod == string.Empty && a.BillId == b.BillId && b.ProductId==c.ProductId
                                     orderby b.ProductPrice
                                     select new BillDetailViewModel
                                     {
                                        ProductName=b.ProductName,
                                        ProductPrice=b.ProductPrice,
                                        Quantity=b.Quantity,
                                        Url=c.ImgUrl,
                                        ProductId=b.ProductId,
                                        TotalProductPrice=b.TotalProductPrice
                                      }).ToListAsync();
            return bill;
        }
        public async Task<bool> UpdateQuantityAsync(ClaimsPrincipal user, BillAndBillDetailViewModel infor)
        {
            var customer = await _userManager.GetUserAsync(user);
            var product = await (from b in _context.Bill
                                 from c in _context.BillProduct
                                 where b.CustomerId == customer.Id && b.PaymentMethod == string.Empty && b.BillId == c.BillId && c.ProductId == infor.Product.ProductId
                                 select c).FirstOrDefaultAsync();
            var bill1 = await (from b in _context.Bill
                               where b.CustomerId == customer.Id && b.PaymentMethod == string.Empty
                               select b).FirstOrDefaultAsync();
            if (product == null || bill1 == null) return true;

            if (infor.Type == "-")
            {
                product.Quantity--;
                if (product.Quantity <= 0)
                {
                    bill1.TotalPrice -= product.ProductPrice;
                    _context.Remove(product);
                    if (bill1.TotalPrice <= 0) _context.Remove(bill1);
                }
                else
                {
                    bill1.TotalPrice -= product.ProductPrice;
                    product.TotalProductPrice -= product.ProductPrice;
                }
            }
            else if (infor.Type == "+")
            {
                product.Quantity++;
                bill1.TotalPrice += product.ProductPrice;
                product.TotalProductPrice += product.ProductPrice;
            }
            _context.SaveChanges();
            return true;

        }
        public async Task<bool> DeleteProductAsync(ClaimsPrincipal user, BillAndBillDetailViewModel infor)
        {
            var customer = await _userManager.GetUserAsync(user);
            var product = await (from b in _context.Bill
                                 from c in _context.BillProduct
                                 where b.CustomerId == customer.Id && b.PaymentMethod == string.Empty && b.BillId == c.BillId && c.ProductId == infor.Product.ProductId
                                 select c).FirstOrDefaultAsync();
            var bill = await (from b in _context.Bill
                               where b.CustomerId == customer.Id && b.PaymentMethod == string.Empty
                               select b).FirstOrDefaultAsync();
            if (product == null || bill == null) return true;
            bill.TotalPrice -= product.TotalProductPrice;
            _context.Remove(product);
            if (bill.TotalPrice == 0) _context.Remove(bill);
            _context.SaveChanges();
            return true;
        }
        public async Task<bool> GetBillUpdateAsync(ClaimsPrincipal user, BillAndBillDetailViewModel infor)
        {
            var customer = await _userManager.GetUserAsync(user);
            infor.Total = await (from b in _context.Bill
                              where b.CustomerId == customer.Id && b.PaymentMethod == string.Empty
                              select b.TotalPrice).FirstOrDefaultAsync();
            infor.ListProduct = await (from a in _context.Bill
                                      from b in _context.BillProduct
                                      from c in _context.Product
                                      where customer.Id == a.CustomerId && a.PaymentMethod == string.Empty && a.BillId == b.BillId && b.ProductId == c.ProductId
                                       orderby b.ProductPrice
                                       select new BillDetailViewModel
                                      {
                                          ProductName = b.ProductName,
                                          ProductPrice = b.ProductPrice,
                                          Quantity = b.Quantity,
                                          Url = c.ImgUrl,
                                          ProductId = b.ProductId,
                                          TotalProductPrice = b.TotalProductPrice
                                      }).ToListAsync();
            return true;
        }
        public async Task<bool> GetInforBillAsync(ClaimsPrincipal user,BillAndBillDetailViewModel infor)
        {
            var customer = await _userManager.GetUserAsync(user);
            var bill = await (from b in _context.Bill
                              where b.CustomerId == customer.Id && b.PaymentMethod != string.Empty
                              orderby b.DateCreatBill descending
                              select new BillAndBillDetailViewModel
                              {
                                  Name = b.UserName,
                                  Hamlet = b.Thon,
                                  Village = b.Xa,
                                  District = b.Huyen,
                                  Province = b.Tinh,
                                  Telephone = b.PhoneNumber
                              }).FirstOrDefaultAsync();
            if (bill == null) return false;
            infor.Name = bill.Name;
            infor.Hamlet = bill.Hamlet;
            infor.Village = bill.Village;
            infor.District = bill.District;
            infor.Province = bill.Province;
            infor.Telephone = bill.Telephone;
            return true;
        }
        public async Task<bool> UpdateBillAsync(BillAndBillDetailViewModel bill, ClaimsPrincipal user)
        {
            var customer = await _userManager.GetUserAsync(user);
            var bill_null=await (from b in _context.Bill
                                 where b.CustomerId==customer.Id && b.PaymentMethod==string.Empty
                                 select b).FirstOrDefaultAsync();
            if (bill_null == null) return false;
            bill_null.UserName = bill.Name;
            bill_null.PaymentMethod = bill.PaymentMethod;
            bill_null.Thon = bill.Hamlet;
            bill_null.Xa = bill.Village;
            bill_null.Huyen = bill.District;
            bill_null.Tinh = bill.Province;
            bill_null.PhoneNumber = bill.Telephone;
            bill_null.DateCreatBill = DateTime.UtcNow;
            if (bill_null.TotalPrice > 10000000)
            {
                var updatePoint = await (from c in _context.Customer
                                         where c.Id == customer.Id
                                         select c).FirstOrDefaultAsync();
                updatePoint.Point += bill_null.TotalPrice / 10000000;
            }    
            _context.SaveChanges();
            return true;
        }
    }
}
