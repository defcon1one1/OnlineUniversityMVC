using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace OnlineUniversityMVC.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<Enrollment> Enrollments { get; set; }

        public string? Email { get; set; } = null;
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

    }
}