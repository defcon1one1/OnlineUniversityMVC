using OnlineUniversityMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must contain between 3 and 20 characters.")]
        [MaxLength(20, ErrorMessage = "Name must contain between 3 and 20 characters.")]
        public string Name { get; set; } = default!;
        public bool? IsActive { get; set; } = true;
        public IEnumerable<Module> Modules { get; set; }
    }
}
