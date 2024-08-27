using DevStart_Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevStart_WebMvcUI.Components
{
    public class CoursesViewComponent : ViewComponent
    {
        private readonly ICourseService _courseService;

        public CoursesViewComponent(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _courseService.GetAllAsync();
            return View("Index", list);
        }
    }
}
