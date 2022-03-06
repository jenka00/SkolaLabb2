using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkolaLabb2.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public string TeacherFName { get; set; }
        public string TeacherLName { get; set; }

        public static List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>
            {
                    new Teacher {TeacherFName = "Reidar", TeacherLName = "Andersson"},
                    new Teacher {TeacherFName = "Anas", TeacherLName = "Qlok"},
                    new Teacher {TeacherFName = "Tobias", TeacherLName = "Eriksson"}
            };
            return teachers;
        }
    }
}
