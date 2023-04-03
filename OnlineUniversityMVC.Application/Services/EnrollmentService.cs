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
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repository;
        private readonly IMapper _mapper;

        public EnrollmentService(IEnrollmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EnrollmentDto?> GetById(int id)
        {
            var enrollment = await _repository.GetById(id);
            var enrollmentDto = _mapper.Map<EnrollmentDto>(enrollment);
            return enrollmentDto;
        }

        public async Task Create(EnrollmentDto enrollmentDto) 
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            await _repository.Create(enrollment);
        }

    }
}
