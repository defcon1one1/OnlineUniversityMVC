using OnlineUniversityMVC.Application.Dtos;

namespace OnlineUniversityMVC.Application.Services
{
    public interface IEnrollmentService
    {
        Task Enroll(CourseDto courseDto, StudentDto studentDto);
        Task<EnrollmentDto> GetById(int id);

    }
}