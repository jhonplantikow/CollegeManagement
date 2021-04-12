using Infrastructure.DB;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Student : Model.Student
    {
        public string course { get; set; }
        public string student { get; set; }
        public string subject { get; set; }
        public float grade { get; set; }

        public Student()
        {

        }

        public Model.Student GetByID(int ID)
        {
            StudentRepository s = new(new CollegeDBContext());
            return s.GetByID(ID);
        }

        public int Insert(Model.Student student)
        {
            StudentRepository s = new(new CollegeDBContext());
            return s.Insert(student);
        }

        public List<Model.Student> Get()
        {
            StudentRepository s = new(new CollegeDBContext());
            return s.GetAll();
        }

        public Model.Student Update(Model.Student student)
        {
            StudentRepository s = new(new CollegeDBContext());
            return s.Update(student);
        }

        public void Delete(int id)
        {
            StudentRepository s = new(new CollegeDBContext());
            s.Delete(id);
        }
    }
}
