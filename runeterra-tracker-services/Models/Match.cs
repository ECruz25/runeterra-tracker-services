using System;
using System.Collections.Generic;

namespace runeterra_tracker_services.Models
{
    public partial class Match
    {
        public int Matchid { get; set; }
        public int Accountid { get; set; }
        public string Deckid { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }

        public virtual Account Account { get; set; }
    }
}
