using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPresentation.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        private CollectionManager collectionManager = new CollectionManager();
        private CardManager cardManager = new CardManager();

        // GET: Collection
        public ActionResult Index()
        {
            string email = User.Identity.Name;
            List<Collection> myCollection = new List<Collection>();
            try
            {
                myCollection = collectionManager.RetrieveMyCollection(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(myCollection);
        }

        public ActionResult AddToCollection(string cardName)
        {
            Card cardToAdd = new Card();
            try
            {
                cardToAdd = cardManager.SelectCardByCardName(cardName);
            }
            catch (Exception ex)
            {

                throw;
            }

            return View(cardToAdd);   
        }
    }
}