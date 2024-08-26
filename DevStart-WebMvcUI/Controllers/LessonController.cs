using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevStart_WebMvcUI.Controllers
{
    public class LessonController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly ILessonService _lessonService;

        public LessonController(ICourseService courseService, ICategoryService categoryService, ILessonService lessonService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _lessonService = lessonService;
        }


        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllAsync();
            ViewBag.Courses = new SelectList(courses, "CourseId", "CourseTitle");
            return View(new LessonViewModel());

        }

        [HttpPost]
        public async Task<IActionResult> Index(LessonViewModel model, IFormFile VideoLink)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images", VideoLink.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await VideoLink.CopyToAsync(stream);
            }

            model.VideoLink = "/images/" + VideoLink.FileName;


            await _lessonService.AddAsync(model);

            TempData["message1"] = true;
            TempData["message2"] = "Kurs başarıyla kayıt edildi.";

            var courses = await _courseService.GetAllAsync();
            ViewBag.Courses = new SelectList(courses, "CourseId", "CourseTitle");

            return View(model);
        }
    }
}
