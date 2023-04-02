using OnlineUniversityMVC.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Infrastructure.Persistence
{
    public class OnlineUniversityMVCDbContext : IdentityDbContext
    {

        public OnlineUniversityMVCDbContext(DbContextOptions<OnlineUniversityMVCDbContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<ModuleGrade> ModuleGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enrollment>(eb =>
            {
                eb.HasKey(e => e.Id);

                eb.HasIndex(e => new { e.CourseId, e.StudentId }).IsUnique();

                eb.HasOne(e => e.Student)
                    .WithMany(s => s.Enrollments)
                    .HasForeignKey(e => e.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

                eb.HasOne(e => e.Course)
                    .WithMany(c => c.Enrollments)
                    .HasForeignKey(e => e.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);

                eb.HasMany(ce => ce.ModuleGrades)
                    .WithOne(mg => mg.Enrollment)
                    .HasForeignKey(mg => mg.EnrollmentId);
            });

            modelBuilder.Entity<Course>(eb => {

                eb.HasKey(e => e.Id);

                eb.Property(e => e.IsActive).HasDefaultValue(true);

                eb.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                eb.HasMany(c => c.Modules)
                    .WithOne(m => m.Course)
                    .HasForeignKey(m => m.CourseId);
            });

            modelBuilder.Entity<Student>(eb =>
            {
                eb.HasKey(e => e.Id);

                eb.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                eb.HasMany(s => s.Enrollments)
                    .WithOne(ce => ce.Student)
                    .HasForeignKey(ce => ce.StudentId);
            });

            modelBuilder.Entity<ModuleGrade>(eb =>
            {
                eb.HasKey(e => e.Id);

                eb.ToTable(e => e.HasCheckConstraint("CK_ModuleGrade_Grade", "[Grade] BETWEEN 3 AND 5"));

                eb.HasIndex(e => new { e.ModuleId, e.EnrollmentId }).IsUnique();

                eb.HasOne(mg => mg.Module)
                    .WithMany()
                    .HasForeignKey(mg => mg.ModuleId)
                    .OnDelete(DeleteBehavior.NoAction);

                eb.HasOne(mg => mg.Enrollment)
                    .WithMany(ce => ce.ModuleGrades)
                    .HasForeignKey(mg => mg.EnrollmentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });


        }

    }
}
