using Infrastructure.DB;
using Model;
using System;
using System.Collections.Generic;

namespace Infrastructure.Seed
{
    public class CollegeInitializer : System.Data.Entity.DropCreateDatabaseAlways<CollegeDBContext>
    {
        protected override void Seed(CollegeDBContext context)
        {
            var students = new List<Student>
            {
                new Student{ID=1,Name="Carson",Birthday=DateTime.Now.AddYears(-23)},
                new Student{ID=2,Name="Meredith",Birthday=DateTime.Parse("2002-09-01")},
                new Student{ID=3,Name="Arturo",Birthday=DateTime.Parse("2003-09-01")},
                new Student{ID=4,Name="Gytis",Birthday=DateTime.Parse("2002-09-01")},
                new Student{ID=5,Name="Yan",Birthday=DateTime.Parse("2002-09-01")},
                new Student{ID=6,Name="Peggy",Birthday=DateTime.Parse("2001-09-01")},
                new Student{ID=7,Name="Laura",Birthday=DateTime.Parse("2003-09-01")},
                new Student{ID=8,Name="Nino",Birthday=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Student.Add(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
                new Teacher{ID=1,Name="João",Birthday=DateTime.Parse("2001-09-01"), Salary=1000},
                new Teacher{ID=2,Name="Nuno",Birthday=DateTime.Parse("2005-09-01"), Salary=300},
                new Teacher{ID=3,Name="Arturo",Birthday=DateTime.Parse("1988-09-01"), Salary=1200},
                new Teacher{ID=4,Name="Gytis",Birthday=DateTime.Parse("1999-09-01"), Salary=1040},
                new Teacher{ID=5,Name="Yan",Birthday=DateTime.Parse("1960-09-01"), Salary=1300},
                new Teacher{ID=6,Name="Peggy",Birthday=DateTime.Parse("2001-09-01"), Salary=1600}
            };

            teachers.ForEach(s => context.Teacher.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{ID=1,Name="Chemistry"},
                new Course{ID=2,Name="Microeconomics"},
                new Course{ID=3,Name="Calculus"},
                new Course{ID=4,Name="Trigonometry"},
                new Course{ID=5,Name="Composition"},
                new Course{ID=6,Name="Literature"}
            };

            courses.ForEach(s => context.Course.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>
            {
                new Subject{ID=1, CourseID=1, Name="Chemistry 1"},
                new Subject{ID=2, CourseID=1, Name="Chemistry 2"},
                new Subject{ID=3, CourseID=2, Name="Microeconomics 1"},
                new Subject{ID=4, CourseID=2, Name="Microeconomics 2"},
                new Subject{ID=5, CourseID=3, Name="Calculus 1"},
                new Subject{ID=6, CourseID=3, Name="Calculus 2"},
                new Subject{ID=7, CourseID=4, Name="Trigonometry 1"},
                new Subject{ID=8, CourseID=4, Name="Trigonometry 2"},
                new Subject{ID=9, CourseID=5, Name="Composition 1"},
                new Subject{ID=10, CourseID=5, Name="Composition 2"},
                new Subject{ID=11, CourseID=6, Name="Literature 1"},
                new Subject{ID=12, CourseID=6, Name="Literature 2"}

            };
            subjects.ForEach(s => context.Subject.Add(s));
            context.SaveChanges();

            var relationshipsTeacherSubject = new List<RelationshipsTeacherSubject>
            {
                new RelationshipsTeacherSubject{ID=1,  TeacherID=1, SubjectID=1 },
                new RelationshipsTeacherSubject{ID=2,  TeacherID=1, SubjectID=2 },
                new RelationshipsTeacherSubject{ID=3,  TeacherID=1, SubjectID=3 },
                new RelationshipsTeacherSubject{ID=4,  TeacherID=2, SubjectID=4 },
                new RelationshipsTeacherSubject{ID=5,  TeacherID=2, SubjectID=5 },
                new RelationshipsTeacherSubject{ID=6,  TeacherID=3, SubjectID=6 },
                new RelationshipsTeacherSubject{ID=7,  TeacherID=4, SubjectID=7 },
                new RelationshipsTeacherSubject{ID=8,  TeacherID=4, SubjectID=8 },
                new RelationshipsTeacherSubject{ID=9,  TeacherID=5, SubjectID=9 },
                new RelationshipsTeacherSubject{ID=10, TeacherID=5, SubjectID=10},
                new RelationshipsTeacherSubject{ID=11, TeacherID=5, SubjectID=11},
                new RelationshipsTeacherSubject{ID=12, TeacherID=6, SubjectID=12 }

            };
            relationshipsTeacherSubject.ForEach(s => context.RelationshipsTeacherSubject.Add(s));
            context.SaveChanges();

            var relationshipsStudentSubject = new List<RelationshipsStudentSubject>
            {
                new RelationshipsStudentSubject{ID=1, StudentID=1, SubjectID=1 },
                new RelationshipsStudentSubject{ID=2, StudentID=1, SubjectID=2 },
                new RelationshipsStudentSubject{ID=3, StudentID=2, SubjectID=1 },
                new RelationshipsStudentSubject{ID=4, StudentID=2, SubjectID=2 },
                new RelationshipsStudentSubject{ID=5, StudentID=3, SubjectID=1 },
                new RelationshipsStudentSubject{ID=6, StudentID=3, SubjectID=2 },
                new RelationshipsStudentSubject{ID=7, StudentID=3, SubjectID=3 },
                new RelationshipsStudentSubject{ID=8, StudentID=3, SubjectID=4 },
                new RelationshipsStudentSubject{ID=9, StudentID=4, SubjectID=5 },
                new RelationshipsStudentSubject{ID=10,StudentID=4, SubjectID=6 },
                new RelationshipsStudentSubject{ID=11,StudentID=5, SubjectID=7 },
                new RelationshipsStudentSubject{ID=12,StudentID=5, SubjectID=8 },
                new RelationshipsStudentSubject{ID=13,StudentID=6, SubjectID=9 },
                new RelationshipsStudentSubject{ID=14,StudentID=6, SubjectID=10},
                new RelationshipsStudentSubject{ID=15,StudentID=7, SubjectID=11},
                new RelationshipsStudentSubject{ID=16,StudentID=7, SubjectID=12},
                new RelationshipsStudentSubject{ID=17,StudentID=8, SubjectID=11},
                new RelationshipsStudentSubject{ID=18,StudentID=8, SubjectID=12 }
            };
            relationshipsStudentSubject.ForEach(s => context.RelationshipsStudentSubject.Add(s));
            context.SaveChanges();

            var grades = new List<Grade>
            {
                new Grade{ID=1,  StudentID=1, SubjectID=1  , TeacherID=1, GradeObj=10},
                new Grade{ID=2,  StudentID=1, SubjectID=2  , TeacherID=1, GradeObj=9},
                new Grade{ID=3,  StudentID=2, SubjectID=1  , TeacherID=1, GradeObj=7},
                new Grade{ID=4,  StudentID=2, SubjectID=2  , TeacherID=1, GradeObj=10},
                new Grade{ID=5,  StudentID=3, SubjectID=1  , TeacherID=1, GradeObj=5},
                new Grade{ID=6,  StudentID=3, SubjectID=2  , TeacherID=1, GradeObj=10},
                new Grade{ID=7,  StudentID=3, SubjectID=3  , TeacherID=1, GradeObj=1},
                new Grade{ID=8,  StudentID=3, SubjectID=4  , TeacherID=2, GradeObj=10},
                new Grade{ID=9,  StudentID=4, SubjectID=5  , TeacherID=2, GradeObj=10},
                new Grade{ID=10, StudentID=4, SubjectID=6  , TeacherID=3, GradeObj=10},
                new Grade{ID=11, StudentID=5, SubjectID=7  , TeacherID=4, GradeObj=9},
                new Grade{ID=12, StudentID=5, SubjectID=8  , TeacherID=4, GradeObj=10},
                new Grade{ID=13, StudentID=6, SubjectID=9  , TeacherID=5, GradeObj=2},
                new Grade{ID=14, StudentID=6, SubjectID=10 , TeacherID=5, GradeObj=10},
                new Grade{ID=15, StudentID=7, SubjectID=11 , TeacherID=5, GradeObj=10},
                new Grade{ID=16, StudentID=7, SubjectID=12 , TeacherID=6, GradeObj=5},
                new Grade{ID=17, StudentID=8, SubjectID=11 , TeacherID=5, GradeObj=10},
                new Grade{ID=18, StudentID=8, SubjectID=12 , TeacherID=6, GradeObj=4}
            };
            grades.ForEach(s => context.Grade.Add(s));
            context.SaveChanges();
        }
    }
}
