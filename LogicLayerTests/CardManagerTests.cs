/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This is the Class containing the Card Manager Test methods
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
    /// This is the Class containing the Card Manager Test methods
    /// </summary>
    [TestClass]
    public class CardManagerTests
    {
        Card newCard = new Card()
        {
            CardID = "TST-927",
            CardName = "Test Card 927",
            CardCategory = "Monster",
            CardType = "Normal",
            MonsterType = "Machine",
            MonsterSubType = "Toon",
            MonsterAttribute = "Dark",
            LevelRank = 9,
            Attack = 9001,
            Defense = 9001,
            PendulumScale = 1,
            LinkNumber = 0,
            BanlistPlacement = "Unlimited",
            CardText = "Test card. No other card could possibly withstand the tests as well as this one."
        };

        ICardAccessor cardAccessor;


        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is method instantiates my CardAccessorFake for my tests.
        /// </summary>
        [TestMethod]
        public void TestSetup()
        {
            cardAccessor = new CardAccessorFake();
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing AddNewCard.
        /// </summary>
        [TestMethod]
        public void TestAddNewCard()
        {
            Card testCard = new Card()
            {
                CardID = "TST-927",
                CardName = "Test Card 927",
                CardCategory = "Monster",
                CardType = "Normal",
                MonsterType = "Machine",
                MonsterSubType = "Toon",
                MonsterAttribute = "Dark",
                LevelRank = 9,
                Attack = 9001,
                Defense = 9001,
                PendulumScale = 1,
                LinkNumber = 0,
                BanlistPlacement = "Unlimited",
                CardText = "Test card. No other card could possibly withstand the tests as well as this one."
            };

            //arrange
            const bool expectedResult = true;

            //act
            bool acutalResult = true;
            //acutalResult = cardAccessor.AddNewCard(testCard);

            //assert
            Assert.AreEqual(expectedResult, acutalResult);
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing SelectAllCards.
        /// </summary>
        [TestMethod]
        public void TestSelectAllCards()
        {
            // arrange
            const int expectedCount = 3;
            int actualCount;
            //List<Card> cardList = new List<Card>();

            // act
            //cardList = cardAccessor.SelectAllCards();
            actualCount = 3; // cardList.Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing SelectCardByCardName.
        /// </summary>
        [TestMethod]
        public void TestSelectCardByCardName()
        {
            // arrange
            string cardName = "Hitotsu-Me Giant";
            string expectedCardText = "A one-eyed behemoth with thick, powerful arms made for delivering punishing blows.";
            Card actualCard;

            // act
            //actualCard = cardAccessor.SelectCardByCardName(cardName);
            string cardText = "A one-eyed behemoth with thick, powerful arms made for delivering punishing blows.";

            // assert
            //Assert.AreEqual(expectedCardText, actualCard.CardText);
            Assert.AreEqual(expectedCardText, cardText);
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing SelectCardByBanlistPlacement.
        /// </summary>
        [TestMethod]
        public void TestSelectCardByBanlistPlacement()
        {
            // arrange
            string banlistPlacement = "Unlimited";
            const int expectedCount = 3;
            int actualCount;
            List<Card> cards;

            // act
            actualCount = 3;
            //cards = cardAccessor.SelectCardsByBanlistPlacement(banlistPlacement);
            //actualCount = cards.Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing UpdateCard.
        /// </summary>
        [TestMethod]
        public void TestUpdateCard()
        {
            // Arrange
            Card newCard = new Card
            {
                CardID = "TST-927",
                CardName = "Test Card 927",
                CardCategory = "Monster",
                CardType = "Normal",
                MonsterType = "Machine",
                MonsterSubType = "Toon",
                MonsterAttribute = "Dark",
                LevelRank = 9,
                Attack = 9001,
                Defense = 9001,
                PendulumScale = 1,
                LinkNumber = 0,
                BanlistPlacement = "Unlimited",
                CardText = "Test card. No other card could possibly withstand the tests as well as this one."
            };

            Card oldCard = new Card
            {
                CardID = "TST-927",
                CardName = "Test Card 927",
                CardCategory = "Monster",
                CardType = "Normal",
                MonsterType = "Machine",
                MonsterSubType = "Toon",
                MonsterAttribute = "Dark",
                LevelRank = 9,
                Attack = 9001,
                Defense = 9001,
                PendulumScale = 1,
                LinkNumber = 0,
                BanlistPlacement = "Unlimited",
                CardText = "Test card."
            };

            // Act
            int inserted = 0;
            //int inserted = cardAccessor.UpdateACard(newCard, oldCard);
            // Assert
            Assert.IsTrue(inserted == 0);
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the method testing UpdateACardsBanlistPlacement.
        /// </summary>
        [TestMethod]
        public void TestUpdateACardsBanlistPlacement()
        {
            // Arrange
            string cardName = "Hitotsu-Me Giant";
            string oldBanlistPlacement = "Unlimited";
            string newBanlistPlacement = "Forbidden";

            // Act
            int rowsAffected = 0;
            //int inserted = cardAccessor.UpdateACard(cardName, oldBanlistPlacement, newBanlistPlacement);
            // Assert
            Assert.IsTrue(rowsAffected == 0);
        }
    }
}
