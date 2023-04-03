using OnlineUniversityMVC.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineUniversityMVC.Application.Services;
using OnlineUniversityMVC.Application.Dtos;

namespace OnlineUniversityMVC.Presentation.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAll();
            return View(model);
        }

        [Route("Course/{name}/Details")]
        public async Task<IActionResult> Details(string name)
        {
            var model = await _service.GetByName(name);
            return View(model);
        }

    }
}
 