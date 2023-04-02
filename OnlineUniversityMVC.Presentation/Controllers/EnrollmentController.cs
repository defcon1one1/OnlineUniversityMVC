
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ICourseService _courseService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IStudentService _studentService;
        public EnrollmentController(IEnrollmentService enrollmentService, ICourseService courseService, IHttpContextAccessor contextAccessor, IStudentService studentService)
        {
            _enrollmentService = enrollmentService;
            _courseService = courseService;
            _contextAccessor = contextAccessor;
            _studentService = studentService;
        }
        [Authorize(Roles = "Admin")]
        [Route("Enrollment/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _enrollmentService.GetById(id);
            return View(model);
        }
        [Authorize(Roles = "Student")]
        [Route("EnrollmentStudent/{id}")]
        public async Task<IActionResult> DetailsStudent(int id)
        {
            var model = await _enrollmentService.GetById(id);
            return View(model);
        }
        
        [Authorize (Roles = "Student")]
        [Route("Enrollment/Enroll")]
        public async Task<IActionResult> Enroll()
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
            var studentDto = await _studentService.GetByUserId(userId);
            var courseDtos = await _courseService.GetAll();

            var viewModel = new EnrollViewModel() { StudentToEnroll = studentDto, CoursesAvailable = courseDtos };
            return View(viewModel);

        }

        [HttpPost]
        [Authorize (Roles = "Student")]

        public async Task<IActionResult> Enroll(CourseDto courseDto, StudentDto studentDto) 
        {
            await _enrollmentService.Enroll(courseDto, studentDto);
            return Redirect("Home");
        }

    }
}
