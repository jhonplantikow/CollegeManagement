using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.DB;
using Model;

namespace Infrastructure.Repository
{
    public class CourseRepository
    {
        private readonly CollegeDBContext _db;
        public CourseRepository(CollegeDBContext db)
        {
            _db = db;
        }

        public Course GetByID(int ID)
        {
            return _db.Course.Where(c => c.ID == ID).FirstOrDefault();
        }

        public List<Course> GetAll()
        {
            return _db.Course.ToList();
        }

        public int Insert(Course course)
        {
            _db.Course.Add(course);
            return _db.SaveChanges();
        }

        public bool Delete(int ID)
        {
            var c = _db.Course.Where(c => c.ID == ID).SingleOrDefault();

            if (c == null)
                return false;

            _db.Course.Remove(c);

            _db.SaveChanges();

            return true;
        }

        public Course Update(Course course)
        {         
            var c = _db.Course.Where(c => c.ID == course.ID).SingleOrDefault();

            if (c == null)
                return null;
            
            c.Name = course.Name ?? c.Name;

            _db.SaveChanges();

            return c;
        }
    }
}
