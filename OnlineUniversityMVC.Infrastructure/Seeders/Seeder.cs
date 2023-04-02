using Microsoft.AspNetCore.Identity;
using OnlineUniversityMVC.Domain.Entities;
using OnlineUniversityMVC.Infrastructure.Persistence;
using System.Security.Cryptography;

namespace OnlineUniversityMVC.Infrastructure.Seeders
{
    public class Seeder
    {
        private readonly OnlineUniversityMVCDbContext _dbContext;
        public Seeder(OnlineUniversityMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task Seed()
        {
            // check connection
            if (await _dbContext.Database.CanConnectAsync())
            {
                // check if tables are empty
                if (!_dbContext.Students.Any() && !_dbContext.Enrollments.Any() && !_dbContext.Courses.Any() && !_dbContext.Modules.Any() && !_dbContext.ModuleGrades.Any())
                {

                    // identity users -------------------------------------------------------
                    var users = new List<IdentityUser> {
                    new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "johnsmith@mail.com",
                        PasswordHash = HashPassword("johnsmith@mail.com"),
                        NormalizedEmail = "johnsmith@mail.com".ToUpper(),
                        NormalizedUserName = "johnsmith@mail.com".ToUpper(),
                        UserName = "johnsmith@mail.com".ToUpper(),
                        LockoutEnabled = true,
                    },
                    new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "annadoe@mail.com",
                        PasswordHash = HashPassword("annadoe@mail.com"),
                        NormalizedEmail = "annadoe@mail.com".ToUpper(),
                        NormalizedUserName = "annadoe@mail.com".ToUpper(),
                        UserName = "annadoe@mail.com".ToUpper(),
                        LockoutEnabled = true,
                    },
                    new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "bobjohnson@mail.com",
                        PasswordHash = HashPassword("bobjohnson@mail.com"),
                        NormalizedEmail = "bobjohnson@mail.com".ToUpper(),
                        NormalizedUserName = "bobjohnson@mail.com".ToUpper(),
                        UserName = "bobjohnson@mail.com".ToUpper(),
                        LockoutEnabled = true,
                    },
                    new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "frankunderwood@mail.com",
                        PasswordHash = HashPassword("frankunderwood@mail.com"),
                        NormalizedEmail = "frankunderwood@mail.com".ToUpper(),
                        NormalizedUserName = "frankunderwood@mail.com".ToUpper(),
                        UserName = "frankunderwood@mail.com".ToUpper(),
                        LockoutEnabled = true,
                    },
                    new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "matthewharris@mail.com",
                        PasswordHash = HashPassword("matthewharris@mail.com"),
                        NormalizedEmail = "matthewharris@mail.com".ToUpper(),
                        NormalizedUserName = "matthewharris@mail.com".ToUpper(),
                        UserName = "matthewharris@mail.com".ToUpper(),
                        LockoutEnabled = true,
                    },
                    new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "gregorytaylor@mail.com",
                        PasswordHash = HashPassword("gregorytaylor@mail.com"),
                        NormalizedEmail = "gregorytaylor@mail.com".ToUpper(),
                        NormalizedUserName = "gregorytaylor@mail.com".ToUpper(),
                        UserName = "gregorytaylor@mail.com".ToUpper(),
                        LockoutEnabled = true,
                    },
                    new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "admin@admin.com",
                        PasswordHash = HashPassword("admin@admin.com"),
                        NormalizedEmail = "admin@admin.com".ToUpper(),
                        NormalizedUserName = "admin@admin.com".ToUpper(),
                        UserName = "admin@admin.com".ToUpper(),
                        LockoutEnabled = true,
                    }
                    };
                    foreach(var user in users)
                    {
                        _dbContext.Add(user);
                    }
                    await _dbContext.SaveChangesAsync();

                    IdentityRole roleAdmin = new IdentityRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    };
                    IdentityRole roleStudent = new IdentityRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Student",
                        NormalizedName = "STUDENT",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    };

                    _dbContext.Add(roleStudent);

                    var userRolesStudent = new List<IdentityUserRole<string>>()
                    {
                        new IdentityUserRole<string>() { UserId = users[0].Id, RoleId = roleStudent.Id },
                        new IdentityUserRole<string>() { UserId = users[1].Id, RoleId = roleStudent.Id },
                        new IdentityUserRole<string>() { UserId = users[2].Id, RoleId = roleStudent.Id },
                        new IdentityUserRole<string>() { UserId = users[3].Id, RoleId = roleStudent.Id },
                        new IdentityUserRole<string>() { UserId = users[4].Id, RoleId = roleStudent.Id },
                        new IdentityUserRole<string>() { UserId = users[5].Id, RoleId = roleStudent.Id },
                    };
                    foreach (var userRole in userRolesStudent)
                    {
                        _dbContext.Add(userRole);
                    }

                    var userRoleAdmin = new IdentityUserRole<string>()
                    {
                        UserId = users[6].Id,
                        RoleId = roleAdmin.Id,
                    };
                    _dbContext.Add(roleAdmin);
                    _dbContext.Add(userRoleAdmin);
                    await _dbContext.SaveChangesAsync();

                    // students -------------------------------------------------------------
                    var students = new List<Student>
            {
                new Student { Name = "John Smith", Email = users[0].Email, UserId = users[0].Id, User = users[0] },
                new Student { Name = "Anna Doe", Email = users[1].Email,UserId = users[1].Id, User = users[1] },
                new Student { Name = "Bob Johnson", Email = users[2].Email,UserId = users[2].Id, User = users[2] },
                new Student { Name = "Frank Underwood", Email = users[3].Email, UserId = users[3].Id, User = users[3] },
                new Student { Name = "Matthew Harris", Email = users[4].Email, UserId = users[4].Id, User = users[4] },
                new Student { Name = "Gregory Taylor", Email = users[5].Email, UserId = users[5].Id, User = users[5] }

            };


                    foreach (var student in students)
                    {
                        _dbContext.Add(student);
                    }

                    // save changes
                    await _dbContext.SaveChangesAsync();

                    // ---------------------courses 
                    var courses = new List<Course>
            {
                new Course { Name = "Math" },
                new Course { Name = "History" },
                new Course { Name = "Biology"},
                new Course { Name = "Chemistry" }
            };

                    foreach (var course in courses)
                    {
                        _dbContext.Add(course);
                    }

                    //save changes
                    await _dbContext.SaveChangesAsync();



                    // ---------------------modules
                    var modules = new List<Module>
            {
                new Module { Name = "Algebra", CourseId = 1 },
                new Module { Name = "Calculus", CourseId = 1 },
                new Module { Name = "Statistics", CourseId = 1 },

                new Module { Name = "Medieval history", CourseId = 2 },
                new Module { Name = "Modern history", CourseId = 2 },
                new Module { Name = "Ancient history", CourseId = 2},

                new Module { Name = "Science of evolution", CourseId = 3 },
                new Module { Name = "History of biology", CourseId = 3 },
                new Module { Name = "Genetics", CourseId = 3},

                new Module { Name = "Basics of chemistry", CourseId = 4 },
                new Module { Name = "Organic chemistry", CourseId = 4 },
                new Module { Name = "Practical chemistry", CourseId = 4}


            };

                    foreach (var module in modules)
                    {
                        _dbContext.Add(module);
                    }

                    // save changes
                    await _dbContext.SaveChangesAsync();


                    // ---------------------enrollments
                    var enrollments = new List<Enrollment>
            {
                new Enrollment {IsCompleted = false, StudentId = 1, CourseId = 1 },
                new Enrollment {IsCompleted = true, StudentId = 1, CourseId = 2 },

                new Enrollment {IsCompleted = false, StudentId = 2, CourseId = 2 },
                new Enrollment {IsCompleted = false, StudentId = 2, CourseId = 3 },

                new Enrollment {IsCompleted = false, StudentId = 3, CourseId = 4 }
            };

                    foreach (var enrollment in enrollments)
                    {
                        _dbContext.Add(enrollment);
                    }

                    // save changes
                    await _dbContext.SaveChangesAsync();


                    // ---------------------grades
                    var grades = new List<ModuleGrade>
            {
                new ModuleGrade { Grade = 3, ModuleId = 1, EnrollmentId = 1 },
                new ModuleGrade { Grade = 5, ModuleId = 2, EnrollmentId = 1 },
                new ModuleGrade { Grade = null, ModuleId = 3, EnrollmentId = 1 },

                new ModuleGrade { Grade = 3, ModuleId = 4, EnrollmentId = 2 },
                new ModuleGrade { Grade = 5, ModuleId = 5, EnrollmentId = 2 },
                new ModuleGrade { Grade = 4, ModuleId = 6, EnrollmentId = 2 },

                new ModuleGrade { Grade = 3, ModuleId = 4, EnrollmentId = 3 },
                new ModuleGrade { Grade = 5, ModuleId = 5, EnrollmentId = 3 },
                new ModuleGrade { Grade = null, ModuleId = 6, EnrollmentId = 3 },

                new ModuleGrade { Grade = 4, ModuleId = 7, EnrollmentId = 4 },
                new ModuleGrade { Grade = 4, ModuleId = 8, EnrollmentId = 4 },
                new ModuleGrade { Grade = null, ModuleId = 9, EnrollmentId = 4 },

                new ModuleGrade { Grade = null, ModuleId = 10, EnrollmentId = 5 },
                new ModuleGrade { Grade = null, ModuleId = 11, EnrollmentId = 5 },
                new ModuleGrade { Grade = null, ModuleId = 12, EnrollmentId = 5 }

            };


                    foreach (var grade in grades)
                    {
                        _dbContext.Add(grade);
                    }

                    // save changes
                    await _dbContext.SaveChangesAsync();


                }
            }



        }

        private string HashPassword(string password)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
            {

                byte[] salt;
                byte[] buffer2;

                using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
                {
                    salt = bytes.Salt;
                    buffer2 = bytes.GetBytes(0x20);
                }
                byte[] dst = new byte[0x31];
                Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
                Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
                Convert.ToBase64String(dst);
                var hash = Convert.ToBase64String(dst);
                return hash;
            }
        }
    }
}
