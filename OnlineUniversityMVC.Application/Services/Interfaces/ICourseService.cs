using OnlineUniversityMVC.Application.Dtos;

namespace OnlineUniversityMVC.Application.Services
{
    public interface ICourseService
    {
        Task Create(CourseDto courseDto);
        Task<IEnumerable<CourseDto>> GetAll();
        Task<CourseDto?> GetByName(string name);
    }
}