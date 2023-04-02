namespace OnlineUniversityMVC.Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = default!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
        public ICollection<Domain.Entities.ModuleGrade> ModuleGrades { get; set; }
    }
}
