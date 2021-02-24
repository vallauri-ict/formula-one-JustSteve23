using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using FormulaOneDLL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOneWebService
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamListController : ControllerBase
    {
        // GET: api/<TeamListController>
        [HttpGet]
        public IEnumerable<TeamList> Get()
        {
            DBtools dbt = new DBtools();
            return dbt.GetDataTeamList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<TeamListController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeamListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeamListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeamListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
