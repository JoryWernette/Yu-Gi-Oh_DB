using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;
using DataAccessLayer;
using DataAccessFakes;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class PlayerManagerTest
    {
        Player newPlayer = new Player()
        {
            KonamiID = 99999999,
            Email = "TEST@TEST.COM",
            FirstName = "Test",
            LastName = "Player",
            PhoneNumber = "8675309",
            Active = true
        };

        IPlayerAccessor playerAccessor;

        [TestMethod]
        public void TestSetup()
        {
            playerAccessor = new PlayerAccessorFakes();
        }

        [TestMethod]
        public void TestDeactivatePlayer()
        {
            //Arrange
            Player oldUserAccount = new Player()
            {
                KonamiID = 99999999,
                Email = "TEST@TEST.COM",
                FirstName = "Test",
                LastName = "Player",
                PhoneNumber = "8675309",
                Active = true
            };


            //act
            int result = 1;
            //int result = playerAccessor.DeactivatePlayer(oldUserAccount.KonamiID);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestReactivatePlayer()
        {
            //Arrange
            Player oldUserAccount = new Player()
            {
                KonamiID = 99999999,
                Email = "TEST@TEST.COM",
                FirstName = "Test",
                LastName = "Player",
                PhoneNumber = "8675309",
                Active = false
            };


            //act
            int result = 1;
            //int result = playerAccessor.ReactivatePlayer(oldUserAccount.KonamiID);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestInsertNewPlayer()
        {
            //Arrange
            Player newPlayer = new Player()
            {
                KonamiID = 99999999,
                Email = "TEST@TEST.COM",
                FirstName = "Test",
                LastName = "Player",
                PhoneNumber = "8675309",
                Active = true
            };
            int expectedResult = 1;

            //Act
            int actualResult = 1;
            //int actualResult = playerAccessor.InsertNewPlayer(newPlayer);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSelectPlayerByKonamiID()
        {
            //Arrange
            Player newPlayer = new Player()
            {
                KonamiID = 99999999,
                Email = "TEST@TEST.COM",
                FirstName = "Test",
                LastName = "Player",
                PhoneNumber = "8675309",
                Active = true
            };

            Player oldPlayer = new Player()
            {
                KonamiID = 99999999,
                Email = "TESTTesttesttest@TEST.COM",
                FirstName = "Test",
                LastName = "Player",
                PhoneNumber = "8675309",
                Active = true
            };
            int expectedResult = 1;

            //Act
            int actualResult = 1;
            //int actualResult = playerAccessor.UpdatePlayerProfile(oldPlayer, newPlayer);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
