using DevStart_Entity.Entities;
using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using DevStart_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevStart_WebMvcUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;


        public CourseController(ICourseService courseService, ICategoryService categoryService) //DI Container -> CourseService
        {
            _courseService = courseService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View((new CourseViewModel(), courses));
        }

        [HttpPost]
        public async Task<IActionResult> Index(CourseViewModel model, IFormFile PictureUrl)
        {
            //if (ModelState.IsValid)
            // {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images", PictureUrl.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await PictureUrl.CopyToAsync(stream);
            }

            model.PictureUrl = "/images/" + PictureUrl.FileName;

            var user = await _courseService.Find(User.Identity.Name);
            model.UserId = user.Id;

            await _courseService.AddAsync(model);

            TempData["message1"] = true;
            TempData["message2"] = "Kurs başarıyla kayıt edildi.";

            var courses = await _courseService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

            return View((model, courses));
            //}
            //else
            //{
            //    TempData["message1"] = false;
            //    TempData["message2"] = "Kurs kayıt edilemedi.";

            //    var courses = await _courseService.GetAllAsync();
            //    var categories = await _categoryService.GetAllAsync();
            //    ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

            //    return View((model, courses));
            //}
        }


        [HttpPost]
        public async Task<IActionResult> Create(CourseViewModel model, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images", formFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                model.PictureUrl = "/images/" + formFile.FileName;

                var user = await _courseService.Find(User.Identity.Name);
                model.UserId = user.Id;

                await _courseService.AddAsync(model);

                TempData["message1"] = true;
                TempData["message2"] = "Kurs başarıyla kayıt edildi.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message1"] = false;
                TempData["message2"] = "Kurs kayıt edilemedi.";
                return RedirectToAction("Index");
            }
        }
    }
}
