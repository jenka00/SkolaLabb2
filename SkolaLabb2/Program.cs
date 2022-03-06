using SkolaLabb2.Data;
using SkolaLabb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SkolaLabb2
{
    class Program
    {
        static void Main(string[] args)
        {
            using SkoDB Context = new SkoDB();

            //VISA LÄRARE I MATEMATIK
            var TeachInMaths = (from teach in Context.Teachers
                                join teachSub in Context.TeacherSubjects
                                on teach.TeacherID equals teachSub.TeacherID
                                join subj in Context.Subjects
                                on teachSub.SubjectID equals subj.SubjectID
                                where subj.SubjectName == "Matematik"
                                select teach);

            Console.WriteLine("Lärare i Matematik");
            foreach (var t in TeachInMaths)
            {
                Console.WriteLine("Namn: {0} {1}", t.TeacherFName, t.TeacherLName);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------------------------");

            //VISA ELEVER MED DERAS LÄRARE
            var StudAndTeach = (from cou in Context.Courses
                                join stud in Context.Students
                                on cou.CourseID equals stud.CourseID
                                join couSub in Context.CourseSubjects
                                on stud.CourseID equals couSub.CourseID
                                join teachSub in Context.TeacherSubjects
                                on couSub.SubjectID equals teachSub.SubjectID
                                join teach in Context.Teachers on
                                teachSub.TeacherID equals teach.TeacherID                             
                                select new
                                {
                                    cName = cou.CourseName,
                                    sFName = stud.StudentFName,
                                    sLName = stud.StudentLName,
                                    tFName = teach.TeacherFName,
                                    tLName = teach.TeacherLName
                                }).Distinct();
            foreach (var p in StudAndTeach)
            {
                Console.WriteLine("Klass: {0} \tElevnamn: {1} {2} Lärarnamn: {3} {4}", p.cName, p.sFName, p.sLName, p.tFName, p.tLName);
            }

            //FUNKAR INTE
            //var subjCourse = (from cou in Context.Courses
            //                  join couSub in Context.CourseSubjects
            //                  on cou.CourseID equals couSub.CourseID
            //                  join sub in Context.Subjects
            //                  on couSub.SubjectID equals sub.SubjectID
            //                  into SubjectGroup
            //                  select new { cou, SubjectGroup });
            //foreach (var course in subjCourse)
            //{
            //    Console.WriteLine("Kurs {0}", course.cou.CourseName);
            //    foreach (var subject in course.SubjectGroup)
            //    {
            //        Console.WriteLine("Ämne {0}", subject.SubjectName);
            //    }
            //}


            //FUNKAR INTE
            //var StudAndTeach = (from stud in Context.Students
            //                    join cou in Context.Courses
            //                    on stud.CourseID equals cou.CourseID
            //                    into StudGroup
            //                    //join couSub in Context.CourseSubjects
            //                    //on stud.CourseID equals couSub.CourseID
            //                    //join sub in Context.Subjects
            //                    //on couSub.SubjectID equals sub.SubjectID
            //                    select new
            //                    { stud, StudGroup });
            //foreach (var p in StudAndTeach)
            //{
            //    Console.WriteLine("Klass: {0}", p.stud.StudentFName);
            //    foreach (var s in p.StudGroup)
            //    {
            //        Console.WriteLine("Elev: {1}", s.CourseName);
            //    }
            //}

            //KOLLA OM SUBJECT INNEHÅLLER PROGRAMMERING 1
            List < Subject > checkSub = (from sub in Subject.GetAllSubjects()
                                         where sub.SubjectName.Contains("Programmering 1")
                                         select sub).ToList();
            if (checkSub.Count > 0)
            {
                foreach (Subject s in checkSub)
                {
                    Console.WriteLine("Ämnet {0} finns med i listan.", s.SubjectName);
                }
            }
            else
            {
                Console.WriteLine("Ämnet finns inte med i listan.");
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------------------------");

            //ÄNDRAR NAMNET PÅ ELEVENS LÄRARE FRÅN ANAS TILL REIDAR
            Console.WriteLine("Ange studentnummer: ");
            int chosenStudent = Convert.ToInt32(Console.ReadLine());

            var checkAndChangeTeach = (from teach in Context.Teachers
                                       join teachSub in Context.TeacherSubjects
                                       on teach.TeacherID equals teachSub.TeacherID
                                       join couSub in Context.CourseSubjects
                                       on teachSub.SubjectID equals couSub.SubjectID
                                       join stud in Context.Students
                                       on couSub.CourseID equals stud.CourseID
                                       where teach.TeacherFName == "Anas" && stud.StudentID == chosenStudent
                                       select teach);

            foreach (var t in checkAndChangeTeach)
            {
                t.TeacherFName = "Reidar";
                t.TeacherLName = "Andersson";
            }
            Context.SaveChanges();

            Console.ReadKey();
            Console.WriteLine("------------------------------------------------------");

            /////UPPDATERA ETT ÄMNE            
            //var updateSubj = Context.Subjects.Where(n => n.SubjectName == "Avancerad.NET").ToList();
            //foreach (var update in updateSubj)
            //{
            //    update.SubjectName = "Programmering 2";
            //}

            //Context.SaveChanges();

            //var S = (from s in Context.Subjects
            //        select new
            //        { 
            //            SubName = s.SubjectName
            //        });
            //foreach (var item in S)
            //{
            //    Console.WriteLine(item.SubName);
            //}
            //Console.WriteLine();

            //var SubList = Subject.GetAllSubjects();
            //foreach (var item in SubList)
            //{
            //    Context.Subjects.Add(item);
            //    Context.SaveChanges();
            //}

            //var TeachList = Teacher.GetAllTeachers();
            //foreach (var t in TeachList)
            //{
            //    Context.Teachers.Add(t);

            //}

            //var TeachSubjList = TeacherSubject.GetTeacherSubjects();
            //foreach (var ts in TeachSubjList)
            //{
            //    Context.TeacherSubjects.Add(ts);
            //}

            //var CouSubjList = CourseSubject.GetCourseSubjects();
            //foreach (var cs in CouSubjList)
            //{
            //    Context.CourseSubjects.Add(cs);
            //}

            //var t1 = Context.Teachers.Where(t => t.TeacherFName == "Anas").FirstOrDefault();

            //if(t1 is Teacher)
            //{
            //    t1.TeacherFName = "Reidar";
            //    t1.TeacherLName = "Eriksson";
            //    t1.TeacherID = 1;                
            //}

            //Context.SaveChanges();

            //var changeTeachName = (from teach in Context.Teachers 
            //                        join teachSub in Context.TeacherSubjects
            //                        on teach.TeacherID equals teachSub.TeacherID
            //                        join sub in Context.Subjects 
            //                        on teachSub.SubjectID equals sub.SubjectID
            //                        where sub.SubjectName == "Webbutveckling"
            //                        select teach);
            //foreach (var teacher in changeTeachName)
            //{

            //    //Context.Teachers.Update(teacher.TeacherFName == "Reidar", teacher.TeacherLName == "Andersson");
            //}
        }
    }
}
