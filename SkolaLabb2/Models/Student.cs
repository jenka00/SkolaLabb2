using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkolaLabb2.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentFName { get; set; }
        public string StudentLName { get; set; }

        public int CourseID { get; set; }
        public Course course { get; set; }

        public static List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>
            {
                    new Student { StudentFName = "Bella", StudentLName = "Andersson", CourseID = 2},
                    new Student { StudentFName = "Tommy", StudentLName = "Larsson", CourseID = 2},
                    new Student { StudentFName = "Tor", StudentLName = "Björk", CourseID = 3},
                    new Student { StudentFName = "Anna", StudentLName = "Larsson", CourseID = 3},
                    new Student { StudentFName = "Erik", StudentLName = "Persson", CourseID = 4},
                    new Student { StudentFName = "Lars", StudentLName = "Stork", CourseID = 4}
            };
            return students;
        }
    }
   

}
