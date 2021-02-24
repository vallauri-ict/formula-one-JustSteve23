using FormulaOneDLL.Models;
using FormulaOneDLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOneWebService
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircuitController : ControllerBase
    {
        // GET: api/<CircuitController>
        [HttpGet]
        public IEnumerable<GPlist> Get()
        {
            DBtools dbt = new DBtools();
            return dbt.GetDataCircuitList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<CircuitController>/5
        [HttpGet("{param}/{value}")]
        public List<Circuit> Get(string param,string value)
        {
            DBtools dbt = new DBtools();
            return dbt.GetDataCircuitList(param,value);
        }

        // POST api/<CircuitController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CircuitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CircuitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
