using Microsoft.EntityFrameworkCore;
using OnlineUniversityMVC.Domain.Entities;
using OnlineUniversityMVC.Domain.Interfaces;
using OnlineUniversityMVC.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Infrastructure.Repositories
{
    public class ModuleGradeRepository : IModuleGradeRepository
    {
        private readonly OnlineUniversityMVCDbContext _dbContext;

        public ModuleGradeRepository(OnlineUniversityMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddOrUpdateGrade(Domain.Entities.ModuleGrade moduleGrade)
        {
            var existingGrade = await _dbContext.ModuleGrades
                 .SingleOrDefaultAsync(g => g.ModuleId == moduleGrade.ModuleId && g.EnrollmentId == moduleGrade.EnrollmentId);
            if (existingGrade != null)
            {
                // Update the existing grade
                existingGrade.Grade = moduleGrade.Grade;
                _dbContext.ModuleGrades.Update(existingGrade);
            }
            else
            {
                // Add a new grade
                _dbContext.ModuleGrades.Add(moduleGrade);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ModuleGrade?> GetById(int id)
        {
            var grade = _dbContext.ModuleGrades.SingleOrDefaultAsync(g => g.Id == id);
            return await grade;
        }
    }
}
