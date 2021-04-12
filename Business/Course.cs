using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.DB;
using Infrastructure.Repository;
using Model;

namespace Business
{
    public class Course
    {        
        public Course()
        {            
            
        }

        public Model.Course GetByID(int ID)
        {
            CourseRepository c = new CourseRepository(new CollegeDBContext());
            return c.GetByID(ID);
        }

        public int Insert(Model.Course course)
        {
            CourseRepository c = new (new CollegeDBContext());
            return c.Insert(course);
        }

        public List<Model.Course> Get()
        {
            CourseRepository c = new CourseRepository(new CollegeDBContext());
            return c.GetAll();
        }

        public Model.Course Update(Model.Course course)
        {
            CourseRepository c = new CourseRepository(new CollegeDBContext());
            return c.Update(course);
        }

        public void Delete(int id)
        {
            CourseRepository c = new CourseRepository(new CollegeDBContext());
            c.Delete(id);
        }
    }
}
