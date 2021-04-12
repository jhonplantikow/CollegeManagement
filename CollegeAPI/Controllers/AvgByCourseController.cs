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
    public class AvgByCourseController : ControllerBase
    {
        // GET: api/<AvgByCourseController>
        [HttpGet]
        public IEnumerable<Model.AVGCourse> Get()
        {
            Business.Grade b = new();
            return b.GetAVGGradeCourseInfo();
        }
    }
}
