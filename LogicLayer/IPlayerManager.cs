using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IPlayerManager
    {
        List<PlayerViewModel> RetrievePlayersByActive(bool active = true);
        List<string> RetreiveRolesByKonamiID(int konamiID);
        List<string> RetrieveAllRoles();
        bool EditPlayerProfile(PlayerViewModel oldPlayer, 
                                 PlayerViewModel newPlayer,
                                 List<string> oldUnassignedRoles, 
                                 List<string> newUnassignedRoles);
        bool AddNewPlayer(PlayerViewModel newPlayer);
    }
}
