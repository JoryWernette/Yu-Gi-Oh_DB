using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class CardAccessorFake : ICardAccessor
    {
        int rowsAffected;

        private List<Card> cardList = new List<Card>();
        private Card card = new Card();

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

        public List<Card> SelectAllCards()
        {
            return this.cardList;
        }

        public Card SelectCardByCardName(string cardName)
        {
            card = cardList[2];
            return card;
        }

        public List<Card> SelectCardsByBanlistPlacement(string banlistPlacement)
        {
            return this.cardList;
        }

        public int UpdateACard(Card newCard, Card oldCard)
        {
            return rowsAffected;
        }

        public int UpdateACardsBanlistPlacement(string cardName, string oldBanlistPlacement, string newBanlistPlacement)
        {
            return rowsAffected;
        }
    }
}
