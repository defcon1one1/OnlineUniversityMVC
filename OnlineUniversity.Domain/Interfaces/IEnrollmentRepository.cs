using OnlineUniversityMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Domain.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment?> GetById(int id);
        Task Create(Enrollment enrollment);
    }
}
