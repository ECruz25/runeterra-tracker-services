using NUnit.Framework;
using runeterra_tracker_services.Models;
using System;

namespace runeterra_tracker_services_test
{
    public class AccountTest
    {
        Match match;
        Match match2;
        Account account;
        Account account2;
        [SetUp]
        public void Setup()
        {
            account = new Account()
            {
                Createdon = DateTime.Now,
                Name = "Edwin",
                Password = "Password",
                Username = "ECruz25",
                Email = "edwin",
                Lastlogin = DateTime.Now,
            };
            account2 = new Account()
            {
                Createdon = DateTime.Now,
                Name = "Edwin",
                Password = "Password",
                Username = "ECruz25",
                Email = "edwin",
                Lastlogin = DateTime.Now,
            };
            match = new Match
            {
                Date = DateTime.Now,
                Deckid = "CEBQUAQGAQEAWFA2DQQCMLJ2AIBAGAYIAEAQGAQAAEAQCAZT",
                Result = "WIN"
            };
            match2 = new Match
            {
                Date = DateTime.Now,
                Deckid = "CEBQUAQGAQEAWFA2DQQCMLJ2AIBAGAYIAEAQGAQAAEAQCAZ1",
                Result = "LOSS"
            };
            account.AddMatch(match);
            account.AddMatch(match2);
        }

        [Test]                      
        public void ShouldAddAMatchToAccont()
        {
            Assert.AreEqual(account.Match.Count, 2);
        }

        [Test]
        public void ShouldReturn50AsWinrate()
        {
            Assert.AreEqual(0.5d, account.WinRate());
        }

        [Test]
        public void ShouldReturn0WhenThereAreNoMatches()
        {
            Assert.AreEqual(0, account2.WinRate());
        }
    }
}