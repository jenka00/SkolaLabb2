using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkolaLabb2.Models
{
    public class Subject
    {   
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public static List<Subject> GetAllSubjects()
        {
            List<Subject> subjects = new List<Subject>
            {
                new Subject {SubjectName = "Programmering 1"},
                new Subject {SubjectName = "Programmering 2"},
                new Subject {SubjectName = "Matematik"},
                new Subject {SubjectName = "OOP"},
                new Subject {SubjectName = "Databasutveckling"},
                new Subject {SubjectName = "Agil systemutveckling"},
                new Subject {SubjectName = "Fysik"},
                new Subject {SubjectName = "Webbutveckling"}
            };
            return subjects;
        }
    }
}
