namespace OnlineUniversityMVC.Domain.Entities
{
    public class ModuleGrade
    {
        public int Id { get; set; }
        public int? Grade { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }


    }
}
