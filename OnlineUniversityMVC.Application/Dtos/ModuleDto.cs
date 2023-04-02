using OnlineUniversityMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.Dtos
{
    public class ModuleDto
    {
        public string Name { get; set; } = default!;
        public Course Course { get; set; } = default!;
    }
}
