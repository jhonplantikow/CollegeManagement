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
    public class TeacherController : ControllerBase
    {
        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<Model.Teacher> Get()
        {
            Business.Teacher c = new();
            return c.Get();
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public Model.Teacher Get(int id)
        {
            Business.Teacher c = new();
            return c.GetByID(id);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public void Post(Model.Teacher teacher)
        {
            Business.Teacher c = new();
            c.Insert(teacher);
        }

        // PUT api/<TeacherController>/5
        [HttpPut]
        public void Put(Model.Teacher teacher)
        {
            Business.Teacher c = new();
            c.Update(teacher);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Business.Teacher c = new();
            c.Delete(id);
        }
    }
}
