using Microsoft.EntityFrameworkCore;
using SkolaLabb2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLabb2.Data
{
    public class SkoDB : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-I9VU7M4;Initial Catalog=SkoLabb;Integrated Security = True;");
        }

    }
}
