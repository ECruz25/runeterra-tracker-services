using Microsoft.AspNetCore.Mvc;
using runeterra_tracker_services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace runeterra_tracker_services.Services
{
    public class AccountService
    {
        private readonly qzdwlleeContext _context;

        public AccountService(qzdwlleeContext context)
        {
            _context = context;
        }

        public async Task<Account> Authenticate(AccountAuthenticationRequest request)
        {
            Account requestedAccount = await _context.Account.SingleOrDefaultAsync(acc => acc.Email.ToUpper() == request.Email.ToUpper());
            if (requestedAccount == null || !BC.Verify(request.Password, requestedAccount.Password))
            {
                return null;
            }
            return requestedAccount;
        }

        public async Task<Account> Register(AccountRegisterRequest request)
        {
            Account newAccount = new Account(request)
            {
                Password = BC.HashPassword(request.Password)
            };
            await _context.Account.AddAsync(newAccount);
            await _context.SaveChangesAsync();
            return newAccount;
        }
    }
}
