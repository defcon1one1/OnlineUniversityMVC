using OnlineUniversityMVC.Application.Dtos;

namespace OnlineUniversityMVC.Presentation.Models
{
    public class EnrollViewModel
    {
        public StudentDto StudentToEnroll { get; set; }
        public IEnumerable<CourseDto> CoursesAvailable { get; set; }
    }
}
