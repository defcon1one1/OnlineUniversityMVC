using Microsoft.AspNetCore.Identity;
using OnlineUniversityMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<Enrollment> Enrollments { get; set; }
        public string? Email { get; set; } = null;
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}
