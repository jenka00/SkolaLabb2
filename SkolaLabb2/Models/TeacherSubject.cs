using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkolaLabb2.Models
{
    public class TeacherSubject
    {
        [Key]
        public int TeacherSubjectID { get; set; }

        public int SubjectID { get; set; }
        public Subject subject { get; set; }

        public int TeacherID { get; set; }
        public Teacher teacher { get; set; }

        public static List<TeacherSubject> GetTeacherSubjects()
        {
            List<TeacherSubject> teSub = new List<TeacherSubject>
            {
                new TeacherSubject {TeacherID = 1, SubjectID = 1},
                new TeacherSubject {TeacherID = 1, SubjectID = 3},
                new TeacherSubject {TeacherID = 1, SubjectID = 5},
                new TeacherSubject {TeacherID = 1, SubjectID = 7},
                new TeacherSubject {TeacherID = 2, SubjectID = 1},
                new TeacherSubject {TeacherID = 2, SubjectID = 2},
                new TeacherSubject {TeacherID = 2, SubjectID = 4},
                new TeacherSubject {TeacherID = 2, SubjectID = 5},
                new TeacherSubject {TeacherID = 3, SubjectID = 3},
                new TeacherSubject {TeacherID = 3, SubjectID = 8},
                new TeacherSubject {TeacherID = 3, SubjectID = 6},
                new TeacherSubject {TeacherID = 3, SubjectID = 2}
            };
            return teSub;
        }
    }
}
