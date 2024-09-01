using DevStart_Entity.Interfaces;
using DevStart_Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevStart_WebMvcUI.Controllers
{
    public class UserSalesController : Controller
    {
        private readonly ICourseSaleService _courseSaleService;
        private readonly ICourseSaleDetailService _courseSaleDetailService;

        public UserSalesController(ICourseSaleService courseSaleService, ICourseSaleDetailService courseSaleDetailService)
        {
            _courseSaleService = courseSaleService;
            _courseSaleDetailService = courseSaleDetailService;
        }

        public async Task<IActionResult> Index()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid.TryParse(userIdString, out Guid userId);

            var sales = await _courseSaleService.GetAllAsync();
            var userSales = sales.Where(s=> s.UserId == userId).ToList();

            return View(userSales);
        }

        [HttpGet]
        public async Task<JsonResult> GetDetail(Guid courseSaleId)
        {
            // courseId'yi kullanarak veritabanından dersleri alıyoruz
            var list = await _courseSaleDetailService.GetDetailsByCourseSaleIdAsync(courseSaleId);

            // Dersleri JSON verisi olarak döndürmek için bir liste oluşturuyoruz
            var jsonResponse = list.Select(detail => new
            {
                count = detail.CourseSaleDetailQuantity,
                courseId = detail.CourseId,
            }).ToList();

            return Json(jsonResponse);
        }
    }
}
