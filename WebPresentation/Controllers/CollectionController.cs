/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
///     
/// The controller for the
/// Collection action methods.
/// </summary>

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

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        ///
        /// Shows a Player a list of their collection records in the DB
        /// </summary>
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

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        ///
        /// Allows a Player to get to the page to add to the list 
        /// of their collection records in the DB
        /// </summary>
        public ActionResult AddToCollection(string cardName)
        {
            Card cardToAdd = new Card();

            AddCardToCollectionModel cardToAddModel = new AddCardToCollectionModel();

            try
            {
                cardToAdd = cardManager.SelectCardByCardName(cardName);
                cardToAddModel.CardToAdd = cardToAdd;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(cardToAddModel);   
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        ///
        /// Allows a Player to add to the list 
        /// of their collection records in the DB
        /// </summary>
        [HttpPost]
        public ActionResult AddToCollection(AddCardToCollectionModel model)
        {
            bool result = false;
            try
            {
                result = collectionManager.AddCardToMyCollection(User.Identity.Name, model.CardToAdd.CardName, model.CardLocation);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return RedirectToAction("Index", "Collection");
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        ///
        /// Allows a Player to get to the page to edit a record in the list 
        /// of their collection records in the DB
        /// </summary>
        public ActionResult Edit(int collectionID, string email, string cardName, string cardLocation)
        {
            Collection model = new Collection();
            model.CollectionID = collectionID;
            model.Email = email;
            model.CardName = cardName;
            model.CardLocation = cardLocation;


            return View(model);
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        ///
        /// Allows a Player to edit a record in the list 
        /// of their collection records in the DB
        /// </summary>
        [HttpPost]
        public ActionResult Edit(Collection collection)
        {
            List<Collection> currentCollection = collectionManager.RetrieveMyCollection(collection.Email);
            string oldLocation = currentCollection.Find(x => x.CollectionID == collection.CollectionID).CardLocation;

            bool result = false;
            try
            {
                result = collectionManager.EditACardInMyCollection(collection.CollectionID, collection.CardLocation, oldLocation);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return RedirectToAction("Index", "Collection");
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        ///
        /// Allows a Player to remove a record in the list 
        /// of their collection records in the DB
        /// </summary>
        public ActionResult Delete(int collectionID)
        {
            bool result = false;
            try
            {
                result = collectionManager.RemoveACardFromMyCollection(collectionID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return RedirectToAction("Index", "Collection");
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        ///
        /// Links the player to yugipedia at the article for the selected card in their collection
        /// </summary>
        public ActionResult Link(string cardName)
        {
            string href = "https://yugipedia.com/wiki/";
            string url = href + cardName;
            return Redirect(url);
        }
    }
}