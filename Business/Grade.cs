using Infrastructure.DB;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class Grade
    {
        public Grade()
        {

        }

        public Model.Grade GetByID(int ID)
        {
            GradesRepository g = new(new CollegeDBContext());
            return g.GetByID(ID);
        }

        public int Insert(Model.Grade grades)
        {
            GradesRepository g = new(new CollegeDBContext());
            return g.Insert(grades);
        }

        public IEnumerable<Model.Grade> Get()
        {
            GradesRepository g = new(new CollegeDBContext());
            return g.GetAll();
        }

        public IEnumerable<Model.StudentGrade> GetStudentGradeInfo()
        {
            GradesRepository g = new(new CollegeDBContext());
            return g.GetStudentGradeInfo();
        }

        public IEnumerable<Model.AVGCourse> GetAVGGradeCourseInfo()
        {
            GradesRepository g = new(new CollegeDBContext());
            return g.GetAVGGradeCourseInfo();
        }
        
        public Model.Grade Update(Model.Grade grades)
        {
            GradesRepository g = new(new CollegeDBContext());
            return g.Update(grades);
        }

        public void Delete(int id)
        {
            GradesRepository g = new(new CollegeDBContext());
            g.Delete(id);
        }
    }
}
