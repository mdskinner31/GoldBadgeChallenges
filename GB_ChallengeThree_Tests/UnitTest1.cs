using GB_ChallengeThree_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GB_ChallengeThree_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private BadgeRepo _repo;
        private Badge _items;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _items = new Badge(5, "D5");

            _repo.AddDoorAccess(_items);
        }
        [TestMethod]
        public void NewBadgeName()
        {
            Badge badge = new Badge();
            badge.BadgeID = 22345;
            int expected = 22345;
            int actual = badge.BadgeID;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddBadge_ShouldShow()
        {
            Badge badge = new Badge();
            
            BadgeRepo badgeRepo = new BadgeRepo();
        }
    }
}
