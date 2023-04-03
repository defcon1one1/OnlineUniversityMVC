using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public StudentService(IStudentRepository repository, IUserService userService, IMapper mapper)
        {
            _studentRepository = repository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<StudentDto?> GetById(int id)
        {
            var student = await _studentRepository.GetById(id);
            var studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;
        }

        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            var students = await _studentRepository.GetAll();
            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return studentDtos;
        }

        public async Task Create(StudentDto studentDto)
        {
            studentDto.UserId = Guid.NewGuid().ToString();
            var student = _mapper.Map<Student>(studentDto);
            studentDto.Enrollments = new List<Enrollment>();
            await _userService.Create(studentDto);
           
            await _studentRepository.Create(student);
        }

        public async Task<IEnumerable<EnrollmentDto>>? GetStudentEnrollments(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            var enrollments = await _studentRepository.GetStudentEnrollments(student);
            var enrollmentsDto = _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);   
            return enrollmentsDto;
        }

        public async Task<StudentDto?> GetByUserId(string userId)
        {
            var student = await _studentRepository.GetByUserId(userId);
            var studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;
        }

        public async Task<IEnumerable<CourseDto>> GetNotEnrolledCourses(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            var notEnrolledCourses = await _studentRepository.GetNotEnrolledCourses(student);
            var notEnrolledCoursesDto = _mapper.Map<IEnumerable<CourseDto>>(notEnrolledCourses);
            return notEnrolledCoursesDto;
        }
    }
}
