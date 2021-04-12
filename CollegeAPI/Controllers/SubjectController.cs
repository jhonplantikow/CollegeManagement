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
    public class SubjectController : ControllerBase
    {
        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<Model.ListCourse> Get()
        {
            Business.Subject c = new();

            //return new List<Model.Subject>();
            return c.Get();
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public Model.Subject Get(int id)
        {
            Business.Subject c = new();
            return c.GetByID(id);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public void Post(Model.Subject subjects)
        {
            Business.Subject c = new();
            c.Insert(subjects);
        }

        // PUT api/<TeacherController>/5
        [HttpPut]
        public void Put(Model.Subject subjects)
        {
            Business.Subject c = new();
            c.Update(subjects);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Business.Subject c = new();
            c.Delete(id);
        }
    }
}
