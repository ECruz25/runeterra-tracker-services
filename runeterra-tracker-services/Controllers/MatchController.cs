using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public async Task<List<Match>> Get(int request)
        {
            List<Match> response = await _services.MatcheshByAccount(request);
            return response;
        }

        // POST api/<MatchController>
        [HttpPost]
        public void Post([FromBody] CreateMatchRequest request)
        {
            _services.CreateMatch(request);
        }
    }
}
