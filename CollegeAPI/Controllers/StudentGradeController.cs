using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollegeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGradeController : ControllerBase
    {
        // GET: api/<StudentGradeController>
        [HttpGet]
        public IEnumerable<Model.StudentGrade> Get()
        {
            Business.Grade c = new();
            return c.GetStudentGradeInfo();
        }
    }
}
