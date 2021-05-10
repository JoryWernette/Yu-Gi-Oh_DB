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
            catch (Exception ex)
            {
                return View("Create");
            }

            return RedirectToAction("Index");
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
        public ActionResult Edit(Card newCard, FormCollection form)
        {
            Card oldCard = new Card();
            oldCard = cardManager.SelectCardByCardName(newCard.CardName);

            string cardID = newCard.CardID;
            string cardName = newCard.CardName;
            string cardCategory = form["Card Category"].ToString();
            newCard.CardCategory = cardCategory;
            string cardType = form["Card Type"].ToString();
            newCard.CardType = cardType;
            string monsterType = form["Monster Type"].ToString();
            newCard.MonsterType = monsterType;
            string monsterSubType = form["Monster Sub-Type"].ToString();
            newCard.MonsterSubType = monsterSubType;
            string monsterAttribute = form["Monster Attribute"].ToString();
            newCard.MonsterAttribute = monsterAttribute;
            int levelRank = newCard.LevelRank;
            int atk = newCard.Attack;
            int def = newCard.Defense;
            int penScale = newCard.PendulumScale;
            int linkNumber = newCard.LinkNumber;
            string banlistPlacement = form["Banlist Placement"].ToString();
            newCard.BanlistPlacement = banlistPlacement;
            string cardText = newCard.CardText;

            try
            {
                cardManager.UpdateACard(newCard, oldCard);
            }
            catch (Exception ex)
            {

                return View("Edit");
            }

            return RedirectToAction("Index");
        }
    }
}