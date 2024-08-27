using DevStart_DataAccsess.Identity;
using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DevStart_WebMvcUI.Controllers
{
    public class UserController : Controller
    {
        //******ADMIN TARAFI CONTROLLER******//

        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(IAccountService accountService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _accountService.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            string message = await _accountService.CreateUserAsync(model);

            if (message == "Kullanıcı başarıyla oluşturuldu.")
            {
                TempData["message1"] = true;
                TempData["message2"] = "Kayıt Başarılı";
            }
            else
            {
                TempData["message1"] = false;
                TempData["message2"] = message;
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    Response response = new Response();
        //    response = await _accountService.CreateUserAsync(model);

        //    if (response.Success)
        //    {
        //        TempData["message1"] = response.Success;
        //        TempData["message2"] = "Kayıt Başarılı";
        //    }
        //    else
        //    {
        //        TempData["message1"] = response.Success;
        //        TempData["message2"] = response.Message;
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
