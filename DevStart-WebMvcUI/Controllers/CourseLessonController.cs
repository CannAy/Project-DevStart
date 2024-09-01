﻿using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DevStart_WebMvcUI.Controllers
{
    public class CourseLessonController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly ILessonService _lessonService;

        public CourseLessonController(ICourseService courseService, ICategoryService categoryService, ILessonService lessonService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _lessonService = lessonService;
        }
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();

            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdString, out Guid userId))
            {
                courses = courses.Where(c => c.UserId == userId);
            }

            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View(courses);
        }
    }
}
