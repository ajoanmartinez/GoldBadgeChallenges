using _03_KomodoBadges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_KomodoBadges_Tests
{
    [TestClass]
    public class BadgesRepoTests
    {
        private BadgesRepo _repo;
        private Badges _obj;
       

        [TestMethod]
        public void AddToDictionary()
        {
            // Arrange
            Badges badge = new Badges();

            // Act
           _repo.AddBadgeToDictionary(5678, new List<string> { "A5"});

            // Assert
            Assert.IsNotNull(badge.BadgeID);
                    
        }

        [TestMethod]
        public void UpdateBadge()
        {
            // Arrange
            Badges badge = new Badges(1235, new List<string> { "D4, F5" });

            // Act
            _repo.UpdateDoorsOnExistingBadge(1235, new List<string> { "D6" });

            // Assert
            Assert.AreEqual(badge, _obj);
        }


        [TestMethod]
        public void RemoveBadge()
        {
            // Arrange 
            Badges badge = new Badges(0711, new List<string> { "D4, F5" });

            // Act
            bool removeDoor = _repo.RemoveDoorsFromExistingBadge(0711, new List<string> { "D4, F5}" });

            // Assert 
            Assert.IsTrue(removeDoor);
        }
     
    }
}
