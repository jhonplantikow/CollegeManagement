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
    public class CoursesController : ControllerBase
    {
        // GET: api/<CoursesController>
        [HttpGet]
        public IEnumerable<Model.Course> Get()
        {
            Business.Course c = new();
            return c.Get();
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public Model.Course Get(int id)
        {
            Business.Course c = new();
            return c.GetByID(id);
        }

        // POST api/<CoursesController>
        [HttpPost]
        public void Post(Model.Course course)
        {
            Business.Course c = new();
            c.Insert(course);
        }

        // PUT api/<CoursesController>/5
        [HttpPut]
        public void Put(Model.Course course)
        {
            Business.Course c = new();
            c.Update(course);
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Business.Course c = new();
            c.Delete(id);
        }
    }
}
