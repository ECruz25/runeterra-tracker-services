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
        public async Task<List<Match>> MatcheshByAccount(int id)
        {
            List<Match> matches = await _context.Match
                .Where(m => m.Accountid == id)
                .Select(t => new Match { 
                        Accountid = t.Accountid, 
                        Date = t.Date, 
                        Deckid = t.Deckid, 
                        Matchid = t.Matchid, 
                        Result = t.Result
                    })
                .ToListAsync();
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
            accountToCreate.AddMatch(match);
            _context.Account.Update(accountToCreate);
            await _context.Match.AddAsync(match);
            await _context.SaveChangesAsync();
        }
    }
}
