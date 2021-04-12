using Infrastructure.DB;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SubjectRepository
    {
        private readonly CollegeDBContext _db;
        public SubjectRepository(CollegeDBContext db)
        {
            _db = db;
        }

        public Subject GetByID(int ID)
        {
            return _db.Subject.Where(s => s.ID == ID).FirstOrDefault();
        }

        public IEnumerable<SubjectInfo> GetSubjectInfo()
        {
            var grouper = (from rts in _db.RelationshipsTeacherSubject
                           join tc in _db.Teacher on rts.TeacherID equals tc.ID
                           join sb in _db.Subject on rts.SubjectID equals sb.ID
                           join rss in _db.RelationshipsStudentSubject on rts.SubjectID equals rss.SubjectID
                           join gr in _db.Grade on new { rss.StudentID, rss.SubjectID } equals new { gr.StudentID, gr.SubjectID }
                           select new SubjectInfo
                           {
                               TeacherName = tc.Name,
                               TeacherBirthday = tc.Birthday,
                               Subject = sb.Name,
                               StudentQTY = rss.StudentID,
                               GradeSUM = gr.GradeObj
                           }).ToList();

            var result = grouper
                .GroupBy(x => new
                {
                    x.TeacherName,
                    x.TeacherBirthday,
                    x.Subject
                })
                .Select(s => new SubjectInfo
                {
                    TeacherName = s.First().TeacherName,
                    TeacherBirthday = s.First().TeacherBirthday,
                    Subject = s.First().Subject,
                    StudentQTY = s.Count(),
                    GradeSUM = s.Sum(c => c.GradeSUM)
                });

            return result;
        }

        public IEnumerable<Model.ListCourse> GetAll()
        {
            //return (from s in _db.Subject
            //        join c in _db.Course on s.CourseID equals c.ID
            //        select new
            //        {
            //            ID = s.ID,
            //            Name = s.Name,
            //            CourseID = s.CourseID,
            //            CourseName1 = c.Name

            //        }).AsEnumerable<dynamic>();



            return (from s in _db.Subject
                    join c in _db.Course on s.CourseID equals c.ID
                    select new Model.ListCourse
                    {
                        ID = s.ID,
                        Name = s.Name,
                        CourseID = s.CourseID,
                        CourseName = c.Name

                    }).ToList();
        }

        public int Insert(Subject subjects)
        {
            _db.Subject.Add(subjects);
            return _db.SaveChanges();
        }

        public bool Delete(int ID)
        {
            var s = _db.Subject.Where(s => s.ID == ID).SingleOrDefault();

            if (s == null)
                return false;

            _db.Subject.Remove(s);

            _db.SaveChanges();

            return true;
        }

        public Subject Update(Subject subjects)
        {
            var s = _db.Subject.Where(s => s.ID == subjects.ID).SingleOrDefault();

            if (s == null)
                return null;

            s.Name = subjects.Name ?? s.Name;
            s.CourseID = subjects.CourseID > 0 ? subjects.CourseID : s.CourseID;

            _db.SaveChanges();

            return s;
        }
    }
}
