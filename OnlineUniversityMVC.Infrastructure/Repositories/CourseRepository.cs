using OnlineUniversityMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using OnlineUniversityMVC.Domain.Interfaces;
using OnlineUniversityMVC.Infrastructure.Persistence;

namespace OnlineUniversityMVC.Infrastructure.Repositories
{
    internal class CourseRepository : ICourseRepository
    {
        private readonly OnlineUniversityMVCDbContext _dbContext;


        public async Task<Course?> GetById(int id)
        {
            return await _dbContext.Courses
                    .Include(course => course.Modules)
                    .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Course?> GetByName(string name)
        {
            return await _dbContext.Courses
                .Include(course => course.Modules)
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
        public CourseRepository(OnlineUniversityMVCDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task Create(Course course)
        {
            _dbContext.Add(course);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _dbContext.Courses.ToListAsync();
        }

    }
}
