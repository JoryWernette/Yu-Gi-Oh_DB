/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This is an interface for manager of cards
/// </summary>

using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface ICollectionManager
    {
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
        List<Collection> RetrieveMyCollection(string email);

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
        bool AddCardToMyCollection(string email, string cardName, string cardLocation);

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
        bool EditACardInMyCollection(int collectionID, string cardLocation, string oldLocation);

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
        bool RemoveACardFromMyCollection(int collectionID);
    }
}
