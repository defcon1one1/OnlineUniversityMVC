using Microsoft.AspNetCore.Identity;
using OnlineUniversityMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public IEnumerable<Enrollment> Enrollments { get; set; }
        [EmailAddress]
        public string? Email { get; set; } = null;
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}
