using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }        
        public string Name { get; set; }
        public int CourseID { get; set; }
        public string CourseName1 { get; set; }
    }
}
