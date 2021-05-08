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
        List<Card> RetrieveCardsByBanlistPlacement(string banlistPlacement);

        bool EditCardBanlistPlacement(string carName, 
            string oldBanlistPlacment, string newBanlistPlacement);

        int UpdateACard(Card card);

        List<Card> RetreiveAllCards();

        Card SelectCardByCardName(string cardName);

        bool AddNewCard(Card card);
    }
}
