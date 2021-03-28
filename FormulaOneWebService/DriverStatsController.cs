using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL.Models;
using FormulaOneDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOneWebService
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverStatsController : ControllerBase
    {
        // GET: api/DriverStats
        [HttpGet]
        public IEnumerable<driverStats> Get()
        {
            DBtools obj = new DBtools();
            return obj.getDriverStats();
        }

        // GET: api/DriverStats/5
        [HttpGet("{id}")]
        public IEnumerable<driverStats> Get(int id)
        {
            DBtools obj = new DBtools();
            return obj.getDriverStats(id);
        }

        // POST: api/DriverStats
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/DriverStats/5
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
