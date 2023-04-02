using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineUniversityMVC.Domain.Interfaces;
using OnlineUniversityMVC.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OnlineUniversityMVCDbContext _dbContext;

        public UserRepository(OnlineUniversityMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(IdentityUser user)
        {
            var role = new IdentityUserRole<string>()
            {
                UserId = user.Id,
                RoleId = _dbContext.Roles.Where(r => r.Name == "Student").FirstOrDefault().Id
            };
            _dbContext.Add(role);
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public IdentityUser GetById(string id)
        {
            return _dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public string GetRoleName(IdentityUser user)
        {
            var roleId = _dbContext.UserRoles.Where(u => u.UserId == user.Id).Select(u => u.RoleId).FirstOrDefault();
            var roleName = _dbContext.Roles.Where(r => r.Id == roleId).Select(r => r.Name).FirstOrDefault();
            return roleName;

        }

    }
}
