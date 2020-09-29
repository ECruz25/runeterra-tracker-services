﻿using System;
using System.Collections.Generic;

namespace runeterra_tracker_services.Models
{
    public partial class Account
    {
        public Account()
        {
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
    }
}
