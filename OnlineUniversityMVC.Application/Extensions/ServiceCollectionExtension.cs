using Microsoft.Extensions.DependencyInjection;
using OnlineUniversityMVC.Application.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineUniversityMVC.Application.Services;
using OnlineUniversityMVC.Application.Services.Interfaces;

namespace OnlineUniversityMVC.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(OnlineUniversityMVCMappingProfile));
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IModuleGradeService, ModuleGradeService>();
            services.AddScoped<IUserService, UserService>();

        }
    }
}
