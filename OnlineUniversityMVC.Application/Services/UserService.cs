using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineUniversityMVC.Application.Dtos;
using OnlineUniversityMVC.Application.Services.Interfaces;
using OnlineUniversityMVC.Domain.Entities;
using OnlineUniversityMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _repository = userRepository;
            _mapper = mapper;
        }
        private string HashPassword(string password)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
            {

                byte[] salt;
                byte[] buffer2;

                using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
                {
                    salt = bytes.Salt;
                    buffer2 = bytes.GetBytes(0x20);
                }
                byte[] dst = new byte[0x31];
                Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
                Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
                Convert.ToBase64String(dst);
                var hash = Convert.ToBase64String(dst);
                return hash;
            }
        }
        public async Task Create(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            string hash = HashPassword(student.Email);

            var user = new IdentityUser()
            {
                Id = student.UserId,
                Email = student.Email,
                PasswordHash = hash,
                NormalizedEmail = student.Email.ToUpper(),
                NormalizedUserName = student.Email.ToUpper(),
                UserName = student.Email.ToUpper(),
                LockoutEnabled = true,
            };

            await _repository.Create(user);
        }

        public IdentityUser GetById(string id)
        {
            return _repository.GetById(id);
        }

        public string GetRoleName(IdentityUser user)
        {
            return _repository.GetRoleName(user);
        }
    }
}
