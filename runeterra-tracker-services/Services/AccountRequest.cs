using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace runeterra_tracker_services.Services
{
    public class AccountRegisterRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
    public class AccountAuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
