
namespace OnlineUniversityMVC.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; } = true;
        public IEnumerable<Module> Modules { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }

    }
}
