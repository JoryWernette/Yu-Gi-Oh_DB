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
        List<Card> SelectCardsByBanlistPlacement(string banlistPlacement);
        int UpdateACardsBanlistPlacement(string cardName,
            string oldBanlistPlacement, string newBanlistPlacement);

        int UpdateACard(Card newCard, Card oldCard);

        List<Card> SelectAllCards();

        Card SelectCardByCardName(string cardName);

        bool AddNewCard(Card card);
    }
}
