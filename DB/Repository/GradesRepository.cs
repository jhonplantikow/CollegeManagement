using Infrastructure.DB;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GradesRepository
    {
        private readonly CollegeDBContext _db;
        public GradesRepository(CollegeDBContext db)
        {
            _db = db;
        }

        public Grade GetByID(int ID)
        {
            return _db.Grade.Where(c => c.ID == ID).FirstOrDefault();
        }

        public IEnumerable<Model.Grade> GetAll()
        {
            return _db.Grade.ToList();
        }

        public IEnumerable<Model.AVGCourse> GetAVGGradeCourseInfo()
        {

            var gradesCourseInfo = (from rts in _db.RelationshipsTeacherSubject
                                    join sb in _db.Subject on rts.SubjectID equals sb.ID
                                    join c in _db.Course on sb.CourseID equals c.ID
                                    join rss in _db.RelationshipsStudentSubject on sb.ID equals rss.SubjectID
                                    join gr in _db.Grade on rss.SubjectID equals gr.SubjectID
                                    select new Model.AVGCourse
                                    {
                                        CourseName = c.Name,
                                        QTYStudent = rss.StudentID,
                                        AVGStudent = gr.GradeObj,
                                        QTYTeacher = rts.TeacherID
                                    }).GroupBy(g => g.CourseName).ToList();


            return gradesCourseInfo.Select(s => new AVGCourse
            {
                CourseName = s.Key,
                QTYStudent = s.Select(qs => qs.QTYStudent).Distinct().Count(),
                AVGStudent = s.Select(av => av.AVGStudent).Average(),
                QTYTeacher = s.Select(qt => qt.QTYTeacher).Distinct().Count()
            }).ToList();

        }

        public IEnumerable<Model.StudentGrade> GetStudentGradeInfo()
        {
            var grades = (from rss in _db.RelationshipsStudentSubject
                          join st in _db.Student on rss.StudentID equals st.ID
                          join sb in _db.Subject on rss.SubjectID equals sb.ID
                          join gr in _db.Grade on new { rss.StudentID, rss.SubjectID } equals new { gr.StudentID, gr.SubjectID }
                          select new Model.StudentGrade
                          {
                              StudentName = st.Name,
                              Subject = sb.Name,
                              Grade = gr.GradeObj
                          }).ToList();

            return grades;
        }

        public int Insert(Grade grades)
        {
            _db.Grade.Add(grades);
            return _db.SaveChanges();
        }

        public bool Delete(int ID)
        {
            var g = _db.Grade.Where(g => g.ID == ID).SingleOrDefault();

            if (g == null)
                return false;

            _db.Grade.Remove(g);

            _db.SaveChanges();

            return true;
        }

        public Grade Update(Grade grades)
        {
            var g = _db.Grade.Where(g => g.ID == grades.ID).SingleOrDefault();

            if (g == null)
                return null;

            g.GradeObj = grades.GradeObj;
            g.StudentID = grades.StudentID;
            g.SubjectID = grades.SubjectID;
            g.TeacherID = grades.TeacherID;

            _db.SaveChanges();

            return g;
        }
    }
}
