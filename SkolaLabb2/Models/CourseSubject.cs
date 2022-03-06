using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkolaLabb2.Models
{
    public class CourseSubject
    {
        [Key]
        public int CourseSubjectID { get; set; }

        public int CourseID { get; set; }
        public Course course { get; set; }

        public int SubjectID { get; set; }
        public Subject subject { get; set; }

        public static List<CourseSubject> GetCourseSubjects()
        {
            List<CourseSubject> coSub = new List<CourseSubject>
            {
                new CourseSubject {CourseID = 2, SubjectID = 1},
                new CourseSubject {CourseID = 2, SubjectID = 2},
                new CourseSubject {CourseID = 2, SubjectID = 4},
                new CourseSubject {CourseID = 2, SubjectID = 5},
                new CourseSubject {CourseID = 2, SubjectID = 8},
                new CourseSubject {CourseID = 3, SubjectID = 1},
                new CourseSubject {CourseID = 3, SubjectID = 2},
                new CourseSubject {CourseID = 3, SubjectID = 3},
                new CourseSubject {CourseID = 3, SubjectID = 4},
                new CourseSubject {CourseID = 3, SubjectID = 8},
                new CourseSubject {CourseID = 4, SubjectID = 3},
                new CourseSubject {CourseID = 4, SubjectID = 7},
                new CourseSubject {CourseID = 4, SubjectID = 6},
                new CourseSubject {CourseID = 4, SubjectID = 1}
            };
            return coSub;
        }
    }
}
