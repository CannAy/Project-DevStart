using DevStart_DataAccsess.Identity;
using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace DevStart_WebMvcUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IAccountService accountService, UserManager<AppUser> userManager)
        {
            _accountService = accountService;
        }

        // Index Action - Muhtemelen bir gösterge ya da ana sayfa
        public IActionResult Index()
        {
            return View();
        }

        // LoginRegister Action - Hem giriş hem de kayıt işlemlerini gösterecek
        public IActionResult LoginRegister()
        {
            var model = new LoginRegisterViewModel
            {
                LoginViewModel = new LoginViewModel(),
                RegisterViewModel = new RegisterViewModel()
            };
            return View(model);
        }

        // Register Action - Sadece Register işlemi ile ilgilenecek
        [HttpPost]
        public async Task<IActionResult> Register(LoginRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.CreateUserAsync(model.RegisterViewModel);

                if (response.Success)
                {
                    TempData["Message"] = "Kayıt başarılı! Lütfen giriş yapın.";
                    return RedirectToAction("LoginRegister"); // Kayıttan sonra kullanıcıyı aynı sayfaya yönlendir
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                }
            }
            // ModelState hatalarını detaylı olarak göster
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            // Hatalıysa LoginRegister view'ına model ile geri dön
            return View("LoginRegister", model);
        }

        // Login Action - Sadece Login işlemi ile ilgilenecek
        [HttpPost]
        public async Task<IActionResult> Login(LoginRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string msg = await _accountService.GetUserAsync(model.LoginViewModel);

                if (msg == "OK")
                {
                    return Redirect(model.LoginViewModel.ReturnUrl ?? "/Home/Index"); // Başarılı girişte yönlendirme
                }
                else
                {
                    ModelState.AddModelError("", msg == "Kullanıcı bulunamadı!" ? "Kullanıcı bulunamadı!" : "Kullanıcı adı veya şifre hatalı!");
                }
            }
            // Hatalıysa LoginRegister view'ına model ile geri dön
            return View("LoginRegister", model);
        }
    }
}
