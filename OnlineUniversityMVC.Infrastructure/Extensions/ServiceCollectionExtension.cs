using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineUniversityMVC.Application;
using OnlineUniversityMVC.Domain.Interfaces;
using OnlineUniversityMVC.Infrastructure.Persistence;
using OnlineUniversityMVC.Infrastructure.Repositories;
using OnlineUniversityMVC.Infrastructure.Seeders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineUniversityMVC.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OnlineUniversityMVCDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("OnlineUniversityMVC")));


            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<OnlineUniversityMVCDbContext>();

            services.AddScoped<Seeder>();

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IModuleGradeRepository, ModuleGradeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }
}
