using AutoMapper;
using OnlineUniversityMVC.Application.Dtos;
using OnlineUniversityMVC.Domain.Entities;
using OnlineUniversityMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;
        private bool disposedValue;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CourseDto?> GetByName(string name)
        {
            var course = await _repository.GetByName(name);
            var courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public async Task Create(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _repository.Create(course);
        }

        public async Task<IEnumerable<CourseDto>> GetAll()
        {
            var courses = await _repository.GetAll();
            var coursesDto = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(courses);
            return coursesDto;
        }

        public async Task<CourseDto> GetById(int id)
        {
            var course = await _repository.GetById(id);
            
               
            var courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }

    }
}
