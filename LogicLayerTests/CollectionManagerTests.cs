/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This is the Class containing the Collection Manager Test methods
/// </summary>

using DataAccessFakes;
using DataAccessLayer;
using DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{

    /// <summary>
    /// Jory A. Wernette
    /// Created: 2021/05/10
    /// 
    /// This is the Class containing the Collection Manager Test methods
    /// </summary>
    [TestClass]
    public class CollectionManagerTests
    {
        Collection newCollection = new Collection()
        {
            CollectionID = 927,
            Email = "joryawernette@gmail.com",
            CardName = "Flame Swordsman",
            CardLocation = "Fusion Binder"

        };

        ICollectionAccessor collectionAccessor;


        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is method instantiates my CollectionAccessorFake for my tests.
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            collectionAccessor = new CollectionAccessorFakes();
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing RetrieveMyCollection.
        /// </summary>
        [TestMethod]
        public void TestRetrieveMyCollection()
        {
            //arrange
            string email = "joryawernette@gmail.com";
            const int expectedResult = 3;
            //act
            int actualResult = 3;
            List<Collection> MyCollection = collectionAccessor.RetrieveMyCollection(email);
            actualResult = MyCollection.Count;
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing AddCardToMyCollection.
        /// </summary>
        [TestMethod]
        public void TestAddCardToMyCollection()
        {
            //Arrange
            string email = "admin@company.com";
            string cardName = "Man-Eater Bug";
            string cardLocation = "Effect Monster Box";
            bool expectedResult = true;

            //Act
            bool actualResult = false;
            actualResult = collectionAccessor.AddCardToMyCollection(email, cardName, cardLocation);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing EditACardInMyCollection.
        /// </summary>
        [TestMethod]
        public void TestEditACardInMyCollection()
        {
            //Arrange
            int collectionID = 1;
            string cardLocation = "Collector's Binder";
            string oldLocation = "Blue-Eyes Deck";
            bool expectedResult = true;

            //Act
            bool actualResult = false;
            actualResult = collectionAccessor.EditACardInMyCollection(collectionID, cardLocation, oldLocation);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing RemoveACardFromMyCollection.
        /// </summary>
        [TestMethod]
        public void TestRemoveACardFromMyCollection()
        {
            //Arrange
            int collectionID = 1;
            bool expectedResult = true;

            //Act
            bool actualResult = false;
            actualResult = collectionAccessor.RemoveACardFromMyCollection(collectionID);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
