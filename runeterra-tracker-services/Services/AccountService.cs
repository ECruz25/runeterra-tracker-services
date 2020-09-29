using Microsoft.AspNetCore.Mvc;
using runeterra_tracker_services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Http;

namespace runeterra_tracker_services.Services
{
    public class AccountService
    {
        private readonly qzdwlleeContext _context;

        public AccountService(qzdwlleeContext context)
        {
            _context = context;
        }

        public void Authenticate(AccountAuthenticationRequest request)
        {
            throw new NotImplementedException();
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
