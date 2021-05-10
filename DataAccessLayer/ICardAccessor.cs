/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This is an interface for data access of cards
/// </summary>

using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ICardAccessor
    {
        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// selects a cards' information based on its Banlist Placement
        /// </summary>
        /// 
        /// <param name="banlistPlacement"> the Banlist Placement of the card to be retrieved</param>
        /// <exception>Card not found</exception>
        /// <returns>List of Card objects</returns>
        List<Card> SelectCardsByBanlistPlacement(string banlistPlacement);

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// updates a card.
        /// </summary>
        /// 
        /// <param name="cardName"> The name of a card to have its Banlist Placement updated</param>
        /// <param name="oldBanlistPlacement"> The old data to be overwritten</param>
        /// <param name="newBanlistPlacement"> The new data to be saved</param>
        /// <exception>Card not updated</exception>
        /// <returns>an int signifying the rows affected</returns>
        int UpdateACardsBanlistPlacement(string cardName,
            string oldBanlistPlacement, string newBanlistPlacement);

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// updates a card.
        /// </summary>
        /// 
        /// <param name="newCard"> The updated card data</param>
        /// <param name="oldCard"> The old data to be overwritten</param>
        /// <exception>Card not updated</exception>
        /// <returns>an int signifying the rows affected</returns>
        int UpdateACard(Card newCard, Card oldCard);

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// selects all cards
        /// </summary>
        /// 
        /// <exception>Card list not found</exception>
        /// <returns>list of card objects</returns>
        List<Card> SelectAllCards();

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// selects a cards' information based on its name
        /// </summary>
        /// 
        /// <param name="cardName"> the name of the card to be retrieved</param>
        /// <exception>Card not found</exception>
        /// <returns>Card object</returns>
        Card SelectCardByCardName(string cardName);

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Inserts a new Card
        /// </summary>
        /// 
        /// <param name="card"> The Card object to be added</param>
        /// <exception>Card not inserted</exception>
        /// <returns>an Bool signifying success or failuere</returns>
        bool AddNewCard(Card card);
    }
}
