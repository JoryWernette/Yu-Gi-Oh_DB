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

        public CardManager()
        {
            _cardAccessor = new CardAccessor();
        }
        public CardManager(ICardAccessor cardAccessor)
        {
            _cardAccessor = cardAccessor;
        }

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

        public int UpdateACard(Card card)
        {
            try
            {
                return (_cardAccessor.UpdateACard(card));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Updating card failed.", ex);
            }
        }
    }
}
