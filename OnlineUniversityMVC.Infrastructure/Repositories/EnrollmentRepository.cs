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

        public async Task<Enrollment?> GetById(int id)
        {
            return await _dbContext.Enrollments
                        .Include(e => e.Course)
                        .Include(e => e.ModuleGrades)
                            .ThenInclude(e => e.Module)
                        .Include(e => e.Student)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(Enrollment enrollment)
        {
            _dbContext.Add(enrollment);
            await _dbContext.SaveChangesAsync();
            foreach (var module in enrollment.Course.Modules)
            {
                var moduleGrade = new ModuleGrade() { EnrollmentId = enrollment.Id, ModuleId = module.Id, Grade = null };
                _dbContext.Add(moduleGrade);
            }
            await _dbContext.SaveChangesAsync();
        }

    }
}
