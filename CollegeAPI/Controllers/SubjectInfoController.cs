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
    public class SubjectInfoController : ControllerBase
    {
        // GET: api/<SubjectInfoController>
        [HttpGet]
        public IEnumerable<Model.SubjectInfo> Get()
        {
            Business.Subject c = new();
            return c.GetSubjectInfo();
        }
    }
}
