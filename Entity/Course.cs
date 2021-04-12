using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
