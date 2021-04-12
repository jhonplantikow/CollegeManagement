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
    public class GradeController : ControllerBase
    {
        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<Model.Grade> Get()
        {
            Business.Grade c = new();      
            return c.Get();
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public Model.Grade Get(int id)
        {
            Business.Grade c = new();
            return c.GetByID(id);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public void Post(Model.Grade grades)
        {
            Business.Grade c = new();
            c.Insert(grades);
        }

        // PUT api/<TeacherController>/5
        [HttpPut]
        public void Put(Model.Grade grades)
        {
            Business.Grade c = new();
            c.Update(grades);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Business.Grade c = new();
            c.Delete(id);
        }
    }
}
