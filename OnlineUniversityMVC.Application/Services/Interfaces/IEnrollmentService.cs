using OnlineUniversityMVC.Application.Dtos;

namespace OnlineUniversityMVC.Application.Services
{
    public interface IEnrollmentService
    {
        Task Create(EnrollmentDto enrollmentDto);
        Task<EnrollmentDto?> GetById(int id);

    }
}