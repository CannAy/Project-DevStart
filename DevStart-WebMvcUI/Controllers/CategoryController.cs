using Azure;
using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevStart_WebMvcUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CategoryId = Guid.NewGuid(); //id üretilmiş oldu.
                await _categoryService.AddAsync(model);
                TempData["message1"] = true;
                TempData["message2"] = "Kayıt Başarılı";
            }
            else
            {
                TempData["message1"] = false;
                TempData["message2"] = "Kayıt Başarısız";
            }
            return View();
        }
    }
}
