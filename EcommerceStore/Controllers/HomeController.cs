using EcommerceStore.Models;
using EcommerceStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EcommerceStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;        
        }
        public async Task<IActionResult> Index()
        {
            var products = await _customerService.GetAllProductAsync();
            return View(products);
        }
        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var loginSucess = await _customerService.LoginAsync(loginViewModel.UserName, loginViewModel.Password);

            if (loginSucess==1)
            {
                loginViewModel.ErrorMessage = "Tài khoản không tồn tại";
                return View(loginViewModel);
            }
            else if(loginSucess==2)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Revenue","Admin");
            }    
        }

        [HttpGet("/Register")]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost("/Register")]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            if(registerViewModel.Password!=registerViewModel.RePassword){
                registerViewModel.ErrorMessage = "Mật khẩu nhập lại không trùng nhau";
                return View(registerViewModel);
            }
            var registerSucess = await _customerService.RegisterAsync(registerViewModel);

            if (!registerSucess)
            {
                registerViewModel.ErrorMessage = "Tài khoản đã tồn tại";
                return View(registerViewModel);
            }

            return RedirectToAction("Login");
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _customerService.SignOutAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
