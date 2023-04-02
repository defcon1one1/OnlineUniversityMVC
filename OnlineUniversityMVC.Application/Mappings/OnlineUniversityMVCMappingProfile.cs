using AutoMapper;
using OnlineUniversityMVC.Application.Dtos;
using OnlineUniversityMVC.Domain.Entities;

namespace OnlineUniversityMVC.Application.Mappings
{
    public class OnlineUniversityMVCMappingProfile : Profile
    {
        public OnlineUniversityMVCMappingProfile()
        {
            CreateMap<CourseDto, Domain.Entities.Course>();
            CreateMap<Domain.Entities.Course, CourseDto>();

            CreateMap<StudentDto, Domain.Entities.Student>();
            CreateMap<Domain.Entities.Student, StudentDto>();

            CreateMap<EnrollmentDto, Domain.Entities.Enrollment>();
            CreateMap<Domain.Entities.Enrollment, EnrollmentDto>();

            CreateMap<ModuleGradeDto, Domain.Entities.ModuleGrade>();
            CreateMap<Domain.Entities.ModuleGrade, ModuleGradeDto>();

        }
    }
}
