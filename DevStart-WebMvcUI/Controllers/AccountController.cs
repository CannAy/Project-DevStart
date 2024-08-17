using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace DevStart_WebMvcUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {          
            return View();
        }
        public IActionResult Login(string? ReturnUrl) //Login ekranı
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = ReturnUrl //kullanıcıdan gelen returnurl'i alıyoruz bununla!
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) //Login ekranı (post)
        {
            string msg = await _accountService.GetUserAsync(model);
            if (msg == "Kullanıcı bulunamadı!")
            {
                ModelState.AddModelError("", msg);
                return View(model);
            }
            else if (msg == "OK")
            {
                return Redirect(model.ReturnUrl ?? "/Article/Index");  // ?? null'sa sen anasayfaya git!
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");

            }
            return View(model);
        }
		public IActionResult Register()
		{
			return View();
		}

		//create user dediğimizde gönderdiğimiz bilgileri alabilmesi için;
		//[HttpPost]
		//public async Task<Response> Register(RegisterViewModel model)
		//{
   //         Response response = new Response();
			//bool state = await _accountService.CreateUserAsync(model);

			//if (state)
			//{
   //             response.Success = true;
   //             response.Message = "Kayıt başarılı";
			//}
			//else
			//{
			//	//ModelState.AddModelError("", msg);
   //             response.Success = false;
   //             response.Message = "Kayıt başarısız";                
   //         }
   //         return response;
           
		//}

	}
}
