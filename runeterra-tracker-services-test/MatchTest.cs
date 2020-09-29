using NUnit.Framework;
using runeterra_tracker_services.Models;
using System;

namespace runeterra_tracker_services_test
{
    public class MatchTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeckIdShouldBe48Characters()
        {
            Match match = new Match
            {
                Date = DateTime.Now,
                Deckid = "CEBQUAQGAQEAWFA2DQQCMLJ2AIBAGAYIAEAQGAQAAEAQCAZT",
                Result = "WIN"
            };
            Assert.IsTrue(match.Deckid.Length == 48);
        }
    }
}