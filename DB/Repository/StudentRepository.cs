using Infrastructure.DB;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class StudentRepository
    {
        private readonly CollegeDBContext _db;
        public StudentRepository(CollegeDBContext db)
        {
            _db = db;
        }

        public Student GetByID(int ID)
        {
            return _db.Student.Where(c => c.ID == ID).FirstOrDefault();
        }

        public List<Model.Student> GetAll()
        {
            var student = _db.Student.ToList();
            return student;
        }

        public int Insert(Student student)
        {
            _db.Student.Add(student);
            return _db.SaveChanges();
        }

        public bool Delete(int ID)
        {
            var s = _db.Student.Where(s => s.ID == ID).SingleOrDefault();

            if (s == null)
                return false;

            _db.Student.Remove(s);

            _db.SaveChanges();

            return true;
        }

        public Student Update(Student student)
        {
            var s = _db.Student.Where(c => c.ID == student.ID).SingleOrDefault();

            if (s == null)
                return null;

            s.Birthday = student.Birthday;
            s.Name = student.Name ?? s.Name;

            _db.SaveChanges();

            return s;
        }
    }
}
