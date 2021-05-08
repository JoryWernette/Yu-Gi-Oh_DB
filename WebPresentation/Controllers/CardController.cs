using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicLayer;
using System.Web.Mvc;
using DataObjects;

namespace WebPresentation.Controllers
{
    public class CardController : Controller
    {
        CardManager cardManager = new CardManager();

        // GET: Card List
        public ActionResult Index()
        {
            List<Card> CardList = new List<Card>();
            CardList = cardManager.RetreiveAllCards();

            return View(CardList);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Card card, FormCollection form)
        {
            string cardID = card.CardID;
            string cardName = card.CardName;
            string cardCategory = form["Card Category"].ToString();
            card.CardCategory = cardCategory;
            string cardType = form["Card Type"].ToString();
            card.CardType = cardType;
            string monsterType = form["Monster Type"].ToString();
            card.MonsterType = monsterType;
            string monsterSubType = form["Monster Sub-Type"].ToString();
            card.MonsterSubType = monsterSubType;
            string monsterAttribute = form["Monster Attribute"].ToString();
            card.MonsterAttribute = monsterAttribute;
            int levelRank = card.LevelRank;
            int atk = card.Attack;
            int def = card.Defense;
            int penScale = card.PendulumScale;
            int linkNumber = card.LinkNumber;
            string banlistPlacement = form["Banlist Placement"].ToString();
            card.BanlistPlacement = banlistPlacement;
            string cardText = card.CardText;


            try
            {
                cardManager.AddNewCard(card);
            }
            catch (Exception)
            {

                return View("Create");
            }

            return View("Create");
        }

        public ActionResult Edit(string cardName)
        {
            Card card = new Card();
            try
            {
                card = cardManager.SelectCardByCardName(cardName);
                if (card.CardText != null)
                {

                    return View(card);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(Card card, FormCollection form)
        {
            string cardID = card.CardID;
            string cardName = card.CardName;
            string cardCategory = form["Card Category"].ToString();
            card.CardCategory = cardCategory;
            string cardType = form["Card Type"].ToString();
            card.CardType = cardType;
            string monsterType = form["Monster Type"].ToString();
            card.MonsterType = monsterType;
            string monsterSubType = form["Monster Sub-Type"].ToString();
            card.MonsterSubType = monsterSubType;
            string monsterAttribute = form["Monster Attribute"].ToString();
            card.MonsterAttribute = monsterAttribute;
            int levelRank = card.LevelRank;
            int atk = card.Attack;
            int def = card.Defense;
            int penScale = card.PendulumScale;
            int linkNumber = card.LinkNumber;
            string banlistPlacement = form["Banlist Placement"].ToString();
            card.BanlistPlacement = banlistPlacement;
            string cardText = card.CardText;

            try
            {
                cardManager.UpdateACard(card);
            }
            catch (Exception)
            {

                return View("Edit");
            }

            return View("Index");
        }
    }
}