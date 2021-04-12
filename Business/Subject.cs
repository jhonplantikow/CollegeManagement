using Infrastructure.DB;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Subject
    {
        public Subject()
        {

        }

        public Model.Subject GetByID(int ID)
        {
            SubjectRepository s = new(new CollegeDBContext());
            return s.GetByID(ID);
        }
        public IEnumerable<Model.ListCourse> Get()
        {
            SubjectRepository s = new(new CollegeDBContext());
            return s.GetAll();
        }

        public IEnumerable<Model.SubjectInfo> GetSubjectInfo()
        {
            SubjectRepository s = new(new CollegeDBContext());
            return s.GetSubjectInfo();
        }

        public int Insert(Model.Subject subjects)
        {
            SubjectRepository s = new(new CollegeDBContext());
            return s.Insert(subjects);
        }


        public Model.Subject Update(Model.Subject subjects)
        {
            SubjectRepository s = new(new CollegeDBContext());
            return s.Update(subjects);
        }

        public void Delete(int id)
        {
            SubjectRepository s = new(new CollegeDBContext());
            s.Delete(id);
        }
    }
}
