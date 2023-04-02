using OnlineUniversityMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.Dtos
{
    public class ModuleGradeDto
    {
        public int Id { get; set; }
        [Range(3, 5, ErrorMessage = "Grade must be between 3 and 5.")]
        public int? Grade { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; } = default!;
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}
