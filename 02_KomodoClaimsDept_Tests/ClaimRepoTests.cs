using _02_KomodoClaimsDept_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_KomodoClaimsDept_Tests
{
    [TestClass]
    public class ClaimRepoTests
    {
        private ClaimRepository _repo;
        private Claim _claim;
        
        // Add Claim to Queue Method
        [TestMethod]
        public void AddToQueue()
        {
            // Arrange
            ClaimRepository repository = new ClaimRepository();
            Queue<Claim> claims = repository.GetClaimQueue();

            Claim obj1 = new Claim(1, ClaimType.Theft, "Stolen car.", 10000.00, new DateTime(2020, 11, 27), new DateTime(2020, 12, 15), true);
            Claim obj2 = new Claim(2, ClaimType.Car, "Car accident.", 12000.00, new DateTime(2020, 11, 27), new DateTime(2020, 12, 15), true);

            // Act
            repository.AddClaimToQueue(obj1);
            repository.AddClaimToQueue(obj2);

            // Assert
            int expected = 2;
            int actual = claims.Count;
            Assert.AreEqual(expected, actual);         

        }
        // Dequeue Method
        [TestMethod]
        public void RemoveFromQueue()
        {
            // Arrange
            ClaimRepository repository = new ClaimRepository();
            Queue<Claim> claims = repository.GetClaimQueue();

            Claim obj1 = new Claim(1, ClaimType.Theft, "Stolen car.", 10000.00, new DateTime(2020, 11, 27), new DateTime(2020, 12, 15), true);
            Claim obj2 = new Claim(2, ClaimType.Car, "Car accident.", 12000.00, new DateTime(2020, 11, 27), new DateTime(2020, 12, 15), true);

            // Act
            repository.AddClaimToQueue(obj1);
            repository.AddClaimToQueue(obj2);

            claims.Dequeue();

            // Assert
            int expected = 1;
            int actual = claims.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
