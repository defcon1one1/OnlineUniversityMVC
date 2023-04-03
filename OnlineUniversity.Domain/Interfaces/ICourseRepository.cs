using OnlineUniversityMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task Create(Course course);
        Task<IEnumerable<Course>> GetAll();
        Task<Course?> GetByName(string name);
        Task<Course?> GetById(int id);
    }
}
