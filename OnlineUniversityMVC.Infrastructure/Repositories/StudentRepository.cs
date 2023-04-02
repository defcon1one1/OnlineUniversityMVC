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
    public class StudentRepository : IStudentRepository
    {

        private readonly OnlineUniversityMVCDbContext _dbContext;

        public StudentRepository(OnlineUniversityMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetStudentEnrollments(Student student)
        {
            return student.Enrollments.ToList();
        }



        public async Task<Student?> GetById(int id)
        {
            return await _dbContext.Students
                        .Include(student => student.Enrollments)
                            .ThenInclude(enrollment => enrollment.Course)
                        .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Student?> GetByUserId(string userId)
        {
            var student = await _dbContext.Students
                .Include(student => student.Enrollments)
                    .ThenInclude(enrollment => enrollment.Course)
                .FirstOrDefaultAsync(s => s.UserId == userId);
            return student;
        }
    }
}
