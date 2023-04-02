using AutoMapper;
using OnlineUniversityMVC.Application.Dtos;
using OnlineUniversityMVC.Application.Services.Interfaces;
using OnlineUniversityMVC.Domain.Entities;
using OnlineUniversityMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.Services
{
    public class ModuleGradeService : IModuleGradeService
    {
        private readonly IModuleGradeRepository _repository;
        private readonly IMapper _mapper;

        public ModuleGradeService(IModuleGradeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ModuleGradeDto?> GetById(int id)
        {
            var grade = await _repository.GetById(id);
            var gradeDto = _mapper.Map<ModuleGradeDto>(grade);
            return gradeDto;
        }

        public async Task AddOrUpdateGrade(ModuleGradeDto gradeDto)
        {
            var grade = _mapper.Map<ModuleGrade>(gradeDto);
            await _repository.AddOrUpdateGrade(grade);
        }

    }
}
