﻿using FormulaOneDLL;
using FormulaOneDLL.Models;
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
    public class RaceResult : ControllerBase
    {
        // GET: api/<RaceResult>
        [HttpGet]
        public IEnumerable<RaceResults> Get()
        {
            DBtools dt = new DBtools();
            return dt.GetRaceResult();
        }

        // GET api/<RaceResult>/5
        [HttpGet("{raceId}")]
        public IEnumerable<RaceResults> Get(string raceId)
        {
            DBtools dt = new DBtools();
            return dt.GetRaceResult(raceId);
        }

        // POST api/<RaceResult>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RaceResult>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RaceResult>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
