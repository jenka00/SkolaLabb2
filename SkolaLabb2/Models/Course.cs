using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkolaLabb2.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }

        public ICollection<Student> Students { get; set; }

        public static List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>
            {
                new Course { CourseName = "SUT21" },
                new Course { CourseName = "MUT21" },
                new Course { CourseName = "TUT21" }
            };
            return courses;
        }
    }
}
