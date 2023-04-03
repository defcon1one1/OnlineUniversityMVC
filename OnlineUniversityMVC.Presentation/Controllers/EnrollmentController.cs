
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineUniversityMVC.Application.ApplicationUser;
using OnlineUniversityMVC.Application.Dtos;
using OnlineUniversityMVC.Application.Services;
using OnlineUniversityMVC.Application.Services.Interfaces;
using OnlineUniversityMVC.Domain.Entities;
using OnlineUniversityMVC.Presentation.Models;

namespace OnlineUniversityMVC.Presentation.Controllers
{
    public class EnrollmentController : Controller
    {

        private readonly IEnrollmentService _enrollmentService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IStudentService _studentService;
        public EnrollmentController(IEnrollmentService enrollmentService, IHttpContextAccessor contextAccessor, IStudentService studentService)
        {
            _enrollmentService = enrollmentService;
            _contextAccessor = contextAccessor;
            _studentService = studentService;

        }
        [Authorize(Roles = "Admin")]
        //[Route("Enrollment/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _enrollmentService.GetById(id);
            return View(model);
        }

        



    }
}
