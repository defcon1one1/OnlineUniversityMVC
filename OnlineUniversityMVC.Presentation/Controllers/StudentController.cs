
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineUniversityMVC.Application.ApplicationUser;
using OnlineUniversityMVC.Application.Dtos;
using OnlineUniversityMVC.Application.Services;
using OnlineUniversityMVC.Application.Services.Interfaces;
using OnlineUniversityMVC.Domain.Entities;

namespace OnlineUniversityMVC.Presentation.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        private readonly IHttpContextAccessor _contextAccessor;

        public StudentController(IStudentService service, IHttpContextAccessor contextAccessor)
        {
            _service = service;
            _contextAccessor = contextAccessor;
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAll();
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _service.GetById(id);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(StudentDto studentDto)
        {
            await _service.Create(studentDto);
            return Redirect("Index");
        }
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> MyEnrollments()
        {
            var userContext = new UserContext(_contextAccessor);
            string userId = string.Empty;
            try
            {
                userId = userContext.GetCurrentUser().Id;
            }
            catch (Exception ex)
            {
                return NoContent();
            }
            var studentDto = await _service.GetByUserId(userId);
            try
            {
                var model = await _service.GetStudentEnrollments(studentDto);
                return View(model);
            }
            catch (Exception ex)
            {
                var model = new List<EnrollmentDto>();
                return View(model);
            }
        }

    }
}
