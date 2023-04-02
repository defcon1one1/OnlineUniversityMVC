
namespace OnlineUniversityMVC.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public bool? IsActive { get; set; } = true;
        public ICollection<Module> Modules { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
