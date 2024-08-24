using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevStart_WebMvcUI.Controllers
{
    public class UserController : Controller
    { 
                                                //******ADMIN TARAFI CONTROLLER******//

        private readonly IAccountService _accountService;

        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _accountService.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            Response response = new Response();
            response = await _accountService.CreateUserAsync(model);

            if (response.Success)
            {
                TempData["message1"] = response.Success;
                TempData["message2"] = "Kayıt Başarılı";
            }
            else
            {
                TempData["message1"] = response.Success;
                TempData["message2"] = response.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
