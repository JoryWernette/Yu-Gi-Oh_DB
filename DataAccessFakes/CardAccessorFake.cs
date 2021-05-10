/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This class is the 'fakes' class that I use
/// to test my Card Accessor code
/// </summary>

using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Jory A. Wernette
    /// Created: 2021/05/10
    /// 
    /// This class creates a 'fake' Card to be used
    /// in the CardManagerTest class
    /// </summary>
    public class CardAccessorFake : ICardAccessor
    {
        int rowsAffected;

        private List<Card> cardList = new List<Card>();
        private Card card = new Card();

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the Fake CardAccessor so I can test to see if everything but the db is working
        /// </summary>
        public CardAccessorFake()
        {
            cardList.Add(new Card()
            {
                CardID = "LOB-EN000",
                CardName = "Tri-Horned Dragon",
                CardCategory = "Monster",
                CardType = "Normal",
                MonsterType = "Dragon",
                MonsterSubType = "",
                MonsterAttribute = "Light",
                LevelRank = 8,
                Attack = 2850,
                Defense = 2350,
                PendulumScale = 0,
                LinkNumber = 0,
                BanlistPlacement = "Unlimited",
                CardText = "An unworthy dragon with three sharp horns sprouting from its head."
            });

            cardList.Add(new Card()
            {
                CardID = "LOB-EN001",
                CardName = "Blue-Eyes White Dragon",
                CardCategory = "Monster",
                CardType = "Normal",
                MonsterType = "Dragon",
                MonsterSubType = "",
                MonsterAttribute = "Light",
                LevelRank = 8,
                Attack = 3000,
                Defense = 2500,
                PendulumScale = 0,
                LinkNumber = 0,
                BanlistPlacement = "Unlimited",
                CardText = "This legendary dragon is a powerful engine of destruction. Virtually invincible, very few have faced this awesome creature and lived to tell the tale."
            });

            cardList.Add(new Card()
            {
                CardID = "LOB-EN002",
                CardName = "Hitotsu-Me Giant",
                CardCategory = "Monster",
                CardType = "Normal",
                MonsterType = "Beast-Warrior",
                MonsterSubType = "",
                MonsterAttribute = "Earth",
                LevelRank = 4,
                Attack = 1200,
                Defense = 1000,
                PendulumScale = 0,
                LinkNumber = 0,
                BanlistPlacement = "Unlimited",
                CardText = "A one-eyed behemoth with thick, powerful arms made for delivering punishing blows."
            });
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Creates a new Card
        /// </summary>
        /// 
        /// <param name="card"> The Card object to be created</param>
        /// <exception>No Card created</exception>
        /// <returns>Bool denoting success or failure</returns>
        public bool AddNewCard(Card card)
        {
            bool result = false;
            int startingAmount = cardList.Count;
            if (card.CardName != "")
            {
                cardList.Add(card);
            }
            int endingAmount = cardList.Count;
            if (endingAmount > startingAmount)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Selects all Cards Currently in the Database
        /// </summary>
        /// 
        /// <param></param>
        /// <exception>No Cards found</exception>
        /// <returns>A list of Card objects</returns>
        public List<Card> SelectAllCards()
        {
            return this.cardList;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Selects the Card Currently in the Database under a certain name
        /// </summary>
        /// 
        /// <param name="cardName"> The name of a card</param>
        /// <exception>No Card Found</exception>
        /// <returns>a Card object</returns>
        public Card SelectCardByCardName(string cardName)
        {
            card = cardList[2];
            return card;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Selects the Cards Currently in the Database under a certain Banlist Placement
        /// </summary>
        /// 
        /// <param name="banlistPlacement"> The name of a Banlist Placement type</param>
        /// <exception>No Cards Found</exception>
        /// <returns>List of Cards</returns>
        public List<Card> SelectCardsByBanlistPlacement(string banlistPlacement)
        {
            return this.cardList;
        }

        /// <summary>
        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// An abstract method for editing a card.
        /// </summary>
        /// 
        ///<param name="oldCard">The old card object</param>
        ///<param name="newCard">The new card that is to replace the old one</param>
        ///<exception></exception>
        ///<returns>number depending on if the card was updated</returns>
        public int UpdateACard(Card newCard, Card oldCard)
        {
            return rowsAffected;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// An abstract method for editing a card's banlist placement.
        /// </summary>
        /// 
        ///<param name="oldBanlistPlacement">The old Banlist Placement</param>
        ///<param name="newBanlistPlacement">The new Banlist Placement that is to replace the old one</param>
        ///<exception></exception>
        ///<returns>number depending on if the card was updated</returns>
        public int UpdateACardsBanlistPlacement(string cardName, string oldBanlistPlacement, string newBanlistPlacement)
        {
            return rowsAffected;
        }
    }
}
