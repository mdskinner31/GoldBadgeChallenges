using GB_ChallengeTwo_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GB_ChallengeTwo_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToClaimsList_ShouldReturnCorrect()
        {
            Claims claims = new Claims();
           ClaimsRepository claimsRepository = new ClaimsRepository();
        }
        [TestMethod]
        public void ShowAllClaims_ShouldReturnSomethings()
        {
            Claims claims = new Claims();
            ClaimsRepository claimsRepo = new ClaimsRepository();

            claimsRepo.AddClaimsToList(claims);

            List<Claims> listOfClaims = claimsRepo.GetClaimsList();

            bool listHasClaims = listOfClaims.Contains(claims);


        }

        [TestMethod]
        public void SetNewID_ShouldSetID()
        {
            Claims claims = new Claims();
            claims.ClaimID = 2;

            int expected = 2;
            int actual = claims.ClaimID;

            Assert.AreEqual(expected, actual);
        }
    }
}
