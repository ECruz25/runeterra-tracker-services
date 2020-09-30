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
        public List<Match> MatcheshByAccount(int id)
        {
            List<Match> matches = _context.Match.Where(m => m.Accountid == id).ToList();
            return matches;
        }

        public async void CreateMatch(CreateMatchRequest request)
        {
            Account accountToCreate = await _context.Account.FirstOrDefaultAsync(t => t.Accountid == request.AccountId);
            if (accountToCreate == null)
            {
                return;
            }
            Match match = new Match()
            {
                Account = accountToCreate,
                Accountid = request.AccountId,
                Date = DateTime.Now,
                Deckid = request.DeckId,
                Result = request.Result
            };
            await _context.Match.AddAsync(match);
            await _context.SaveChangesAsync();
        }
    }
}
