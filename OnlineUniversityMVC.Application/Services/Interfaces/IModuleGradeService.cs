using OnlineUniversityMVC.Application.Dtos;

namespace OnlineUniversityMVC.Application.Services.Interfaces
{
    public interface IModuleGradeService
    {
        Task AddOrUpdateGrade(ModuleGradeDto gradeDto);
        Task<ModuleGradeDto?> GetById(int id);
    }
}