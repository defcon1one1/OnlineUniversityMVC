namespace OnlineUniversityMVC.Domain.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
    }
}
