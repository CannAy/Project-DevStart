using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevStart_WebMvcUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAccountService _accountService;

        public RegisterController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var users = await _accountService.GetAllUsers();
        //    return View(users);
        //}
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //Response response = new Response();
            var response = await _accountService.CreateUserAsync(model);

            if (ModelState.IsValid)
            {
                if (response.Success)
                {
                    TempData["message"] = "Kayıt Başarılı";
                    return RedirectToAction("Index", "Home"); // Kayıttan sonra giriş sayfasına yönlendir
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                }
            }
            return View(model);



            //if (response.Success)
            //{
            //    TempData["message1"] = response.Success;
            //    TempData["message2"] = "Kayıt Başarılı";
            //}
            //else
            //{
            //    TempData["message1"] = response.Success;
            //    TempData["message2"] = response.Message;
            //}
            //return RedirectToAction("Index");
        }
    }
}
