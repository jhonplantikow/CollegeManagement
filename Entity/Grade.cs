using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Grade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public decimal? GradeObj { get; set; }
    }
}
