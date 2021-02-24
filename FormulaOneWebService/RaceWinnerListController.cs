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
    public class RaceWinnerListController : ControllerBase
    {
        // GET: api/<RaceWinnerListController>
        [HttpGet]
        public IEnumerable<RaceWinnerList> Get()
        {
            DBtools dt = new DBtools();
            return dt.GetRaceWinnerList();
        }

        // GET api/<RaceWinnerListController>/5
        [HttpGet("{id}")]
        public string Get(int RaceId)
        {
            return "value";
        }

        // POST api/<RaceWinnerListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RaceWinnerListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RaceWinnerListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
