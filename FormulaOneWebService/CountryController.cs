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
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        string tab = "Country";
        // GET: api/Country
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            DBtools dbt = new DBtools();
            return dbt.GetData("Country");
        }

        // GET: api/Country/5
        [HttpGet("{paramName}/{param}")]
        public List<Country> Get( string paramName,string param)
        {
            DBtools db = new DBtools();
            return db.GetDataWParam(tab, paramName, param);
        }

        // POST: api/Country
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Country/5
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
