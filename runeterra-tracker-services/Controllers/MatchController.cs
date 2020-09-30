using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using runeterra_tracker_services.Models;
using runeterra_tracker_services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace runeterra_tracker_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private static readonly qzdwlleeContext _context = new qzdwlleeContext();
        private readonly MatchService _services = new MatchService(_context);
        // GET api/<MatchController>/5
        [HttpGet("{id}")]
        public List<Match> Get(MatchesByAccountRequest request)
        {
            List<Match> response = _services.MatchesshByAccount(request);
            return response;
        }

        // POST api/<MatchController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MatchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MatchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
