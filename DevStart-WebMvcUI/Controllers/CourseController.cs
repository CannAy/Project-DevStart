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
            return View(courses);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CourseViewModel model)
        {
            


            return View();
        }

  //      [HttpPost]
		//public async Task<IActionResult> Create(CourseViewModel model , IFormFile formFile )
		//{
  //          var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images//", formFile.FileName);
  //          var stream = new FileStream(path, FileMode.Create); //yeni bir stream oluşturacağımız için FileMode.Create
  //          formFile.CopyTo(stream);

		//	model.PictureUrl = "/images/" + formFile.FileName;
		//	var user = await _courseService.Find(User.Identity.Name);
		//	model.UserId = user.Id;
		//	await _courseService.AddAsync(model);

		//	return RedirectToAction("Index");
  //      }
	}
}
