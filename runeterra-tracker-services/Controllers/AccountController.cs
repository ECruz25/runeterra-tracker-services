using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using runeterra_tracker_services.Models;
using runeterra_tracker_services.Services;

namespace runeterra_tracker_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static readonly qzdwlleeContext _context = new qzdwlleeContext(); 
        private readonly AccountService _services = new AccountService(_context);
        // GET: api/<AccountController>
        [HttpGet]
        public async Task<List<Account>> Get()
        {
            List<Account> response = await _context.Account.ToListAsync();
            return response;
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public async Task<Account> Get(int id)
        {
            Account response = await _context.Account.FirstOrDefaultAsync(acc => acc.Accountid == id);
            return response;
        }

        [HttpGet("Winrate/{id}")]
        public async Task<double> GetWinrate(int account)
        {
            Account response = await _context.Account.FirstOrDefaultAsync(acc => acc.Accountid == account);
            double winrate = response.WinRate();
            return winrate;
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AccountRegisterRequest request)
        {
            Account response = await _services.Register(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]AccountAuthenticationRequest request)
        {
            Account response = await _services.Authenticate(request);
            return Ok(response);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
