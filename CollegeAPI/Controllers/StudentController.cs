using Business;
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
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Model.Student> Get()
        {
            Business.Student c = new();

            return c.Get();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Model.Student Get(int id)
        {
            Business.Student c = new();
            return c.GetByID(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post(Model.Student student)
        {
            Business.Student c = new();
            c.Insert(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public void Put(Model.Student student)
        {
            Business.Student c = new();
            c.Update(student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Business.Student c = new();
            c.Delete(id);
        }
    }
}
