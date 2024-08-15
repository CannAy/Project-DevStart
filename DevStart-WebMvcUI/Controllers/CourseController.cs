using DevStart_Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevStart_WebMvcUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService) //DI Container -> CorseService
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var list = _courseService.GetAllAsync();

            return View(list);
        }
    }
}
