namespace OnlineUniversityMVC.Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public IEnumerable<ModuleGrade>? ModuleGrades { get; set; }
    }
}
