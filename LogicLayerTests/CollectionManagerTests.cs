using DataAccessFakes;
using DataAccessLayer;
using DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
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

        [TestInitialize]
        public void TestSetup()
        {
            collectionAccessor = new CollectionAccessorFakes();
        }

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
    }
}
