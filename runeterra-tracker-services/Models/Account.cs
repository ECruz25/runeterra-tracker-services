using runeterra_tracker_services.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace runeterra_tracker_services.Models
{
    public partial class Account
    {
        public Account()
        {
            Match = new HashSet<Match>();
        }

        public Account(AccountRegisterRequest request)
        {
            Name = request.Name;
            Username = request.Username;
            Email = request.Email;
            Createdon = DateTime.Now;
            Match = new HashSet<Match>();
        }

        public int Accountid { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime? Lastlogin { get; set; }

        public virtual ICollection<Match> Match { get; set; }

        public void AddMatch(Match match)
        {
            Match.Add(match);
        }

        public double WinRate()
        {
            double totalMatches = Match.Count;
            if (totalMatches == 0)
            {
                return 0;
            }
            double wins = Match.Where(m => m.Result == "WIN").Count();
            double result = (double)wins / totalMatches;
            return result;
        }
    }
}
