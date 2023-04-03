
using AutoMapper;
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
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IEnrollmentService _enrollmentService;
        private readonly ICourseService _courseService;
        private readonly IHttpContextAccessor _contextAccessor;

        public StudentController(IStudentService service, IHttpContextAccessor contextAccessor, IEnrollmentService enrollmentService, ICourseService courseService)
        {
            _studentService = service;
            _contextAccessor = contextAccessor;
            _enrollmentService = enrollmentService;
            _courseService = courseService;
        }


        [Authorize(Roles = "Admin")]
        [Route("Students")]
        public async Task<IActionResult> Students()
        {
            var model = await _studentService.GetAll();
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _studentService.GetById(id);
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
            await _studentService.Create(studentDto);
            return Redirect("Students");
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
            var studentDto = await _studentService.GetByUserId(userId);
            try
            {
                var model = await _studentService.GetStudentEnrollments(studentDto);
                return View(model);
            }
            catch (Exception ex)
            {
                var model = new List<EnrollmentDto>();
                return View(model);
            }
        }

        [Authorize(Roles = "Student")]
        [Route("Student/Enroll")]
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
            var courseDtos = await _studentService.GetNotEnrolledCourses(studentDto);

            var viewModel = new EnrollViewModel() { StudentToEnroll = studentDto, CoursesAvailable = courseDtos };

            return View(viewModel);

        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        [Route("Student/Enroll")]
        public async Task<IActionResult> Enroll(EnrollViewModel viewModel)
        {
            var courseDto = await _courseService.GetById(viewModel.CourseToEnroll.Id);
            var studentDto = await _studentService.GetById(viewModel.StudentToEnroll.Id);
            var enrollmentDto = new EnrollmentDto()
            {
                CourseId = courseDto.Id,
                StudentId = studentDto.Id,
                IsCompleted = false
            };
            await _enrollmentService.Create(enrollmentDto);
            return RedirectToAction("MyEnrollments");
        }

        [Authorize(Roles = "Student")]
        [Route("Student/MyEnrollments/EnrollmentDetails/{id}")]
        public async Task<IActionResult> EnrollmentDetails(int id)
        {
            var userContext = new UserContext(_contextAccessor);
            string userId = string.Empty;
            try
            {
                userId = userContext.GetCurrentUser().Id;
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }

            var studentDto = await _studentService.GetByUserId(userId);
            var enrollmentDto = await _enrollmentService.GetById(id);

            if (enrollmentDto == null || enrollmentDto.StudentId != studentDto.Id)
            {
                return Unauthorized();
            }

            var model = await _enrollmentService.GetById(enrollmentDto.Id);
            return View(model);
        }


    }
}
