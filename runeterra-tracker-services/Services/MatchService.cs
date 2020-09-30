using Microsoft.EntityFrameworkCore;
using runeterra_tracker_services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Match = runeterra_tracker_services.Models.Match;

namespace runeterra_tracker_services.Services
{
    public class MatchService
    {
        private readonly qzdwlleeContext _context;
        public MatchService(qzdwlleeContext context)
        {
            _context = context;
        }
        public List<Match> MatchesshByAccount(MatchesByAccountRequest request)
        {
            List<Match> matches = _context.Match.Where(m => m.Accountid == request.Id).ToList();
            return matches;
        }
    }
}
