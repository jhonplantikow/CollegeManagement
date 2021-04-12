using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SubjectInfo
    {
        public string TeacherName { get; set; }
        public DateTime TeacherBirthday { get; set; }
        public string Subject { get; set; }
        public int StudentQTY { get; set; }
        public decimal? GradeSUM { get; set; }
    }

    public class ListCourse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
    }
}
