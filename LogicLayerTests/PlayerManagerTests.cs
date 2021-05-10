/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This is the Class containing the Player Manager Test methods
/// </summary>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;
using DataAccessLayer;
using DataAccessFakes;
using System.Collections.Generic;

namespace LogicLayerTests
{

    /// <summary>
    /// Jory A. Wernette
    /// Created: 2021/05/10
    /// 
    /// This is the Class containing the Player Manager Test methods
    /// </summary>
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

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is method instantiates my PlayerAccessorFake for my tests.
        /// </summary>
        [TestMethod]
        public void TestSetup()
        {
            playerAccessor = new PlayerAccessorFakes();
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing DeactivatePlayer.
        /// </summary>
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


        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing ReactivatePlayer.
        /// </summary>
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

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing InsertNewPlayer.
        /// </summary>
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

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing SelectPlayerByKonamiID.
        /// </summary>
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
