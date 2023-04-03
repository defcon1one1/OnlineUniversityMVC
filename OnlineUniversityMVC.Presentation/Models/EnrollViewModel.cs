using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineUniversityMVC.Application.Dtos;
using OnlineUniversityMVC.Domain.Entities;

namespace OnlineUniversityMVC.Presentation.Models
{
    public class EnrollViewModel
    {
        public StudentDto StudentToEnroll { get; set; }
        public CourseDto CourseToEnroll { get; set; }
        public IEnumerable<CourseDto> CoursesAvailable { get; set; }
    }
}
