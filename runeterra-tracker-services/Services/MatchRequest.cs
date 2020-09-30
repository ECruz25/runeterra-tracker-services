using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace runeterra_tracker_services.Services
{
    public class CreateMatchRequest
    {
        public int AccountId { get; set; }
        public string DeckId { get; set; }
        public string Result { get; set; }
    }

    public class MatchByIdRequest
    {
        public int Id { get; set; }
    }
}
