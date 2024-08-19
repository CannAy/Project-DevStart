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

		public CourseController(ICourseService courseService) //DI Container -> CourseService
		{
			_courseService = courseService;
		}
		
		public async Task<IActionResult> Index(Guid? id, string? search)
		{
			var list = await _courseService.GetAllAsync();
			if (id != null)
			{
				list = list.Where(c => c.CourseId == id.Value).ToList();
			}
			if (search != null) //search kısmı için Index'te
			{
				list = list.Where(a => a.CourseTitle.ToLower().Contains(search.ToLower())).ToList();
			}
			return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _courseService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name"); //category id'yi alıp Name olarak döndürüyor??
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Create(CourseViewModel model , IFormFile formFile )
		{
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images", formFile.FileName);
            var stream = new FileStream(path, FileMode.Create); //yeni bir stream oluşturacağımız için FileMode.Create
            formFile.CopyTo(stream);

            //model.PictureUrl = "/images/" + formFile.FileName;
            //var user = await _courseService.Find(user.Identity.Name);
            //model.UserId = user.Id;
            //await _courseService.Add(model);

            return RedirectToAction("Index");
        }
	}
}
