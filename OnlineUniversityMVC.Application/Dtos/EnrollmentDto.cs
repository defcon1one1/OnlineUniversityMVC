using OnlineUniversityMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.Dtos
{
    public class EnrollmentDto
    {
        public int Id { get; set; } 
        public bool IsCompleted { get; set; }
        public Student Student { get; set; } = default!;
        public Course Course { get; set; } = default!;
        public ICollection<ModuleGrade> ModuleGrades { get; set; }

    }
}
