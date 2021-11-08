using EcommerceStore.Data;
using EcommerceStore.Data.Entities;
using EcommerceStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<List<ProductViewModel>> GetLaptopAsync(string[] Category)
        {
            var query = from p in _context.Product
                        select p;
            if (Category.Count() > 0)
            {
                query = from q in query
                        where Category.Contains(q.Producer)
                        select q;
            }
            var laptop = await (from l in query
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
        public async Task<List<ProductViewModel>> GetSmartAsync(string[] Category)
        {
            var query = from p in _context.Product
                        select p;
            if (Category.Count() > 0)
            {
                query = from q in query
                        where Category.Contains(q.Producer)
                        select q;
            }
            var smart= await (from l in query
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
                                 MainDesc = d.MainDesc,
                                 Desc = d.Desc,
                                 ImgUrl = d.ImgUrl
                             }).ToListAsync();
            return des;
        }
        public async Task<List<EvaluationViewModel>> GetEvaluationAsync(int productId)
        {
            var evalution = await (from e in _context.Evaluation
                                   join p in _context.Product on e.ProductId equals p.ProductId
                                   join c in _context.Customer on e.CustomerId equals c.Id
                                   where e.ProductId == productId
                                   select new EvaluationViewModel
                                   {
                                       Fullname = c.FullName,
                                       Rating = e.Rating,
                                       Comment = e.Comment,
                                       EvalTime = e.EvalTime
                                   }).ToListAsync();
            return evalution;
        }
        public async Task InsertEvalutionAsync(ClaimsPrincipal user,ProductViewModel product)
        {
            var customer = await _userManager.GetUserAsync(user);
            var evalution = new Evaluation()
            {
                ProductId = product.InsertEvaluation.ProductId,
                EvalTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now),
                Comment = product.InsertEvaluation.Comment,
                Rating = product.InsertEvaluation.Rating,
                CustomerId = customer.Id
            };
            _context.Evaluation.Add(evalution);
            _context.SaveChanges();
            var rating = await (from p in _context.Product
                                where p.ProductId == product.InsertEvaluation.ProductId
                                select p).FirstOrDefaultAsync();
            var ratingsum = (from e in _context.Evaluation
                             where e.ProductId == product.InsertEvaluation.ProductId
                             select e).Average(x => x.Rating);
            int ratings = (int)ratingsum;
            rating.Rating = ratings;
            _context.SaveChanges();
        }
        public async Task InsertProductAsync(ClaimsPrincipal user, ProductViewModel product)
        {
            var customer = await _userManager.GetUserAsync(user);
            var currentCart = await (from b in _context.Bill
                                     where b.CustomerId == customer.Id && b.PaymentMethod == string.Empty
                                     select b).FirstOrDefaultAsync();
            var billId = new int();
            if(currentCart!=null)
            {
                billId = currentCart.BillId;
                var productCurrentCart = await (from bd in _context.BillProduct
                                                where bd.BillId == billId && bd.ProductId == product.InsertProductToCart.ProductId
                                                select bd).FirstOrDefaultAsync();
                if(productCurrentCart!=null)
                {
                    productCurrentCart.Quantity += product.InsertProductToCart.Quantity;
                    productCurrentCart.TotalProductPrice = productCurrentCart.Quantity * productCurrentCart.ProductPrice;
                    _context.SaveChanges();
                    currentCart.TotalPrice = (from bd in _context.BillProduct
                                         where bd.BillId == billId
                                         select bd).Sum(x => x.TotalProductPrice);
                }    
                else
                {
                    var newBillProduct = new BillProduct()
                    {
                        BillId = billId,
                        ProductId = product.InsertProductToCart.ProductId,
                        ProductName = product.InsertProductToCart.Name,
                        ProductPrice = product.InsertProductToCart.ProductPrice,
                        Quantity = product.InsertProductToCart.Quantity,
                        TotalProductPrice = product.InsertProductToCart.Quantity * product.InsertProductToCart.ProductPrice
                    };
                    _context.BillProduct.Add(newBillProduct);
                    _context.SaveChanges();
                }    
            }
            else
            {
                var newBill = new Bill()
                {
                    BillId = billId,
                    CustomerId = customer.Id,
                    TotalPrice = product.InsertProductToCart.Quantity * product.InsertProductToCart.ProductPrice,
                    PaymentMethod = string.Empty,
                    AddressReceive=string.Empty
                };
                _context.Bill.Add(newBill);
                var newBillProduct = new BillProduct()
                {
                    BillId = billId,
                    ProductId = product.InsertProductToCart.ProductId,
                    ProductName = product.InsertProductToCart.Name,
                    ProductPrice = product.InsertProductToCart.ProductPrice,
                    Quantity = product.InsertProductToCart.Quantity,
                    TotalProductPrice = product.InsertProductToCart.Quantity * product.InsertProductToCart.ProductPrice
                };
                _context.BillProduct.Add(newBillProduct);
                _context.SaveChanges();
                var newBillId = await (from b in _context.Bill
                                       where b.BillId == billId
                                       select b).FirstOrDefaultAsync();
                newBillId.TotalPrice = (from bd in _context.BillProduct
                                   where bd.BillId == billId
                                   select bd).Sum(x => x.TotalProductPrice);
            }
        }
    }
}
