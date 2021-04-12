using Infrastructure.DB;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TeacherRepository
    {
        private readonly CollegeDBContext _db;
        public TeacherRepository(CollegeDBContext db)
        {
            _db = db;
        }

        public Teacher GetByID(int ID)
        {
            return _db.Teacher.Where(t => t.ID == ID).FirstOrDefault();
        }

        public List<Teacher> GetAll()
        {
            return _db.Teacher.ToList();
        }

        public int Insert(Teacher teacher)
        {
            _db.Teacher.Add(teacher);
            return _db.SaveChanges();
        }

        public bool Delete(int ID)
        {
            var t = _db.Teacher.Where(t => t.ID == ID).SingleOrDefault();

            if (t == null)
                return false;

            _db.Teacher.Remove(t);

            _db.SaveChanges();

            return true;
        }

        public Teacher Update(Teacher teacher)
        {
            var t = _db.Teacher.Where(t => t.ID == teacher.ID).SingleOrDefault();

            if (t == null)
                return null;

            t.Birthday = teacher.Birthday;
            t.Name = teacher.Name ?? t.Name;
            t.Salary = teacher.Salary;

            _db.SaveChanges();

            return t;
        }
    }
}
