/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This class is the 'fakes' class that I use
/// to test my Collection Accessor code
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
    /// This class creates a 'fake' Collection to be used
    /// in the CollectionManagerTest class
    /// </summary>
    public class CollectionAccessorFakes : ICollectionAccessor
    {

        int rowsAffected;

        private List<Collection> myCollection = new List<Collection>();
        private Collection collection = new Collection();

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the Fake CollectionAccessor so I can test to see if everything but the db is working
        /// </summary>
        public CollectionAccessorFakes()
        {
            myCollection.Add(new Collection()
            {
              CollectionID = 1,  
              Email = "joryawernette@gmail.com",
              CardName = "Blue-Eyes White Dragon",
              CardLocation = "Blue-Eyes Deck"
            }); 
            myCollection.Add(new Collection()
            {
                CollectionID = 2,
                Email = "joryawernette@gmail.com",
                CardName = "Pot of Greed",
                CardLocation = "Collector's Binder"
            });
            myCollection.Add(new Collection()
            {
                CollectionID = 3,
                Email = "joryawernette@gmail.com",
                CardName = "Raigeki",
                CardLocation = "Collector's Binder"
            });
            myCollection.Add(new Collection()
            {
                CollectionID = 4,
                Email = "youcantsitwithus3030@icloud.com",
                CardName = "Watt Giraffe",
                CardLocation = "Watt Deck"
            });
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Creates a new Collection record
        /// </summary>
        /// 
        /// <param name="email"> The email of the Player creating the collection record</param>
        /// <param name="cardName"> The name of the card to be added to the collection</param>
        /// <param name="cardLocation"> The location where the card will be stored/used</param>
        /// <exception>No Collection created</exception>
        /// <returns>Bool denoting success or failure</returns>
        public bool AddCardToMyCollection(string email, string cardName, string cardLocation)
        {
            int ListCount = myCollection.Count;
            myCollection.Add(new Collection()
            {
                CollectionID = ListCount + 1,
                Email = email,
                CardName = cardName,
                CardLocation = cardLocation
            });
            if (myCollection.Count > ListCount)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// An abstract method for editing a collection.
        /// </summary>
        /// 
        ///<param name="collectionID">The Collection record ID to be updated</param>
        ///<param name="cardLocation">The new location for the collection record</param>
        ///<param name="oldLocation">The old location record to be overwritten</param>
        ///<exception></exception>
        ///<returns>Bool denoting success or failure</returns>
        public bool EditACardInMyCollection(int collectionID, string cardLocation, string oldLocation)
        {
            bool result = false;
            Collection oldCollection = new Collection();
            Collection editedCollection = new Collection();
            foreach (Collection collection in myCollection)
            {
                if (collection.CollectionID == collectionID
                    && collection.CardLocation == oldLocation)
                {
                    oldCollection = collection;
                }
            }
            if (oldCollection != null)
            {
                editedCollection = oldCollection;
                editedCollection.CardLocation = cardLocation;
                myCollection.Remove(oldCollection);
                myCollection.Add(editedCollection);
            }
            if (myCollection.Contains(editedCollection))
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// An abstract method for deleting a collection record.
        /// </summary>
        /// 
        ///<param name="collectionID">The id of the collection record to be deleted</param>
        ///<exception></exception>
        ///<returns>Bool denoting success or failure</returns>
        public bool RemoveACardFromMyCollection(int collectionID)
        {
            bool result = false;
            int currentCollectionCount = myCollection.Count;
            myCollection.RemoveAt(collectionID);

            if (myCollection.Count < currentCollectionCount)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Selects the Collection records Currently in the Database under a certain email
        /// </summary>
        /// 
        /// <param name="email"> The name of a Player</param>
        /// <exception>No Collection Found</exception>
        /// <returns>List of Collection objects</returns>
        public List<Collection> RetrieveMyCollection(string email)
        {
            List<Collection> jorysCollection = new List<Collection>();

            foreach (Collection collection in myCollection)
            {
                if (collection.Email == email)
                {
                    jorysCollection.Add(collection);
                }
            }

            return jorysCollection;
        }
    }
}
