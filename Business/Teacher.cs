using Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repository;

namespace Business
{
   public  class Teacher
    {
        public Teacher()
        {

        }

        public Model.Teacher GetByID(int ID)
        {
            TeacherRepository t = new(new CollegeDBContext());
            return t.GetByID(ID);
        }

        public int Insert(Model.Teacher teacher)
        {
            TeacherRepository t = new(new CollegeDBContext());
            return t.Insert(teacher);
        }

        public List<Model.Teacher> Get()
        {
            TeacherRepository t = new(new CollegeDBContext());
            return t.GetAll();
        }

        public Model.Teacher Update(Model.Teacher teacher)
        {
            TeacherRepository t = new(new CollegeDBContext());
            return t.Update(teacher);
        }

        public void Delete(int id)
        {
            TeacherRepository t = new(new CollegeDBContext());
            t.Delete(id);
        }
    }
}
