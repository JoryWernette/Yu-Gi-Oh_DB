/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// Implements the Card Manager interface
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;

namespace LogicLayer
{
    public class CardManager : ICardManager
    {
        private ICardAccessor _cardAccessor = null;

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Default constructor initializes an accessor
        /// </summary>
        public CardManager()
        {
            _cardAccessor = new CardAccessor();
        }
        public CardManager(ICardAccessor cardAccessor)
        {
            _cardAccessor = cardAccessor;
        }

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
        public bool AddNewCard(Card card)
        {
            bool result = false;

            try
            {
                result = _cardAccessor.AddNewCard(card);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Adding " + card.CardName + " failed. Exception: ", ex);
            }

            return result;
        }

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
        public bool EditCardBanlistPlacement(string cardName, string oldBanlistPlacement, string newBanlistPlacement)
        {
            try
            {
                return (1 == _cardAccessor.UpdateACardsBanlistPlacement(cardName,
                            oldBanlistPlacement, newBanlistPlacement));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Change Banlist Placement to '" +
                    newBanlistPlacement + "' failed.", ex);
            }
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// selects all cards
        /// </summary>
        /// 
        /// <exception>Card list not found</exception>
        /// <returns>list of card objects</returns>
        public List<Card> RetreiveAllCards()
        {
            try
            {
                return _cardAccessor.SelectAllCards();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data unavailable.", ex);
            }
        }

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
        public List<Card> RetrieveCardsByBanlistPlacement(string banlistPlacement)
        {
            try
            {
                return _cardAccessor.SelectCardsByBanlistPlacement(banlistPlacement);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data unavailable.", ex);
            }
        }

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
        public Card SelectCardByCardName(string cardName)
        {
            try
            {
                return _cardAccessor.SelectCardByCardName(cardName);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data unavailable.", ex);
            }
        }

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
        public int UpdateACard(Card newCard, Card oldCard)
        {
            try
            {
                return (_cardAccessor.UpdateACard(newCard, oldCard));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Updating card failed.", ex);
            }
        }
    }
}
