using OnlineUniversityMVC.Application.Dtos;
using OnlineUniversityMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> GetById(int id);
        Task<StudentDto> GetByUserId(string userId);
        Task<IEnumerable<StudentDto>> GetAll();
        Task Create(StudentDto studentDto);
        Task<IEnumerable<EnrollmentDto>?> GetStudentEnrollments(StudentDto studentDto);
        Task<IEnumerable<CourseDto>> GetNotEnrolledCourses(StudentDto studentDto);
    }
}
