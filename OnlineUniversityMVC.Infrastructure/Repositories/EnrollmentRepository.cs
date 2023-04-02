using Microsoft.EntityFrameworkCore;
using OnlineUniversityMVC.Domain.Entities;
using OnlineUniversityMVC.Domain.Interfaces;
using OnlineUniversityMVC.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Infrastructure.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly OnlineUniversityMVCDbContext _dbContext;

        public EnrollmentRepository(OnlineUniversityMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Entities.Enrollment?> GetById(int id)
        {
            return await _dbContext.Enrollments
                        .Include(e => e.Course)
                        .Include(e => e.ModuleGrades)
                            .ThenInclude(e => e.Module)
                        .Include(e => e.Student)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Enroll(Course course, Student student)
        {

            var enrollment = new Enrollment()
            {
                Course = course,
                Student = student
            };
            AddGrades(enrollment);
            await _dbContext.SaveChangesAsync();
        }

        private void AddGrades(Enrollment enrollment)
        {
            foreach (var module in enrollment.Course.Modules)
            {
                _dbContext.Add(new ModuleGrade() { Enrollment = enrollment, Grade = null, Module = module });
            }
        }

    }
}
