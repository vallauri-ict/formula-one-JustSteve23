using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using FormulaOneDLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOneWebService
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverListController : ControllerBase
    {
        // GET: api/DriverList
        [HttpGet]
        public IEnumerable<DriverList> Get()
        {
            DBtools dbt = new DBtools();
            return dbt.GetDataDriverList();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/DriverList/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DriverList
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/DriverList/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
