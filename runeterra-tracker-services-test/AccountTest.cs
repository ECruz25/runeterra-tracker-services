using NUnit.Framework;
using runeterra_tracker_services.Models;
using System;

namespace runeterra_tracker_services_test
{
    public class AccountTest
    {
        Match match;
        Account account;
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
                Accountid = 1
            };
            match = new Match
            {
                Date = DateTime.Now,
                Deckid = "CEBQUAQGAQEAWFA2DQQCMLJ2AIBAGAYIAEAQGAQAAEAQCAZT",
                Result = "WIN"
            };
        }

        [Test]
        public void ShouldAddAMatchToAccont()
        {
            account.AddMatch(match);
            Assert.AreEqual(account.Match.Count, 1);
        }
    }
}