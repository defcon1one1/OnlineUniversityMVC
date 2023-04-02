using Microsoft.AspNetCore.Identity;
using OnlineUniversityMVC.Application.Dtos;
using OnlineUniversityMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task Create(StudentDto studentDto);
        IdentityUser GetById(string id);
        string GetRoleName(IdentityUser user);
    }
}
