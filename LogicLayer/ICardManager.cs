/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This is an interface for manager of cards
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    public interface ICardManager
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
        List<Card> RetrieveCardsByBanlistPlacement(string banlistPlacement);

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// edits a card's banlist placemnet.
        /// </summary>
        /// 
        /// <param name="cardName"> The name of the card to be updated</param>
        /// <param name="newBanlistPlacement"> a new placement for the card</param>
        /// <param name="oldBanlistPlacement">the original placement for the card</param>
        /// <exception>card not updated</exception>
        /// <returns>a bool signifying that the performance was edited or not</returns>
        bool EditCardBanlistPlacement(string carName, 
            string oldBanlistPlacment, string newBanlistPlacement);

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
        List<Card> RetreiveAllCards();

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
        /// Creates a new card
        /// </summary>
        /// 
        /// <param name="card"> The card objec to be created</param>
        /// <exception>card was not added.</exception>
        /// <returns>a bool signifying that the card was created or not</returns>
        bool AddNewCard(Card card);
    }
}
