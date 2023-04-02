using OnlineUniversityMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task Create(Student student);
        Task<IEnumerable<Student>> GetAll();
        Task<Student?> GetById(int id);
        Task<Student?> GetByUserId(string userId);
        Task<IEnumerable<Enrollment>> GetStudentEnrollments(Student student);

    }
}
