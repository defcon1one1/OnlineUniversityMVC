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
        public int StudentId { get; set; }
        public Student Student { get; set; } = default!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
        public IEnumerable<ModuleGrade> ModuleGrades { get; set; }

    }
}
