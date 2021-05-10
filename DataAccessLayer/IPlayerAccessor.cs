using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IPlayerAccessor
    {
        List<Player> SelectPlayersByActive(bool active = true);
        Player SelectPlayerByKonamiID(int id);
        List<string> SelectRolesByKonamiID(int konamiID);
        List<string> SelectAllRoles();
        int UpdatePlayerProfile(Player oldPlayer, Player newPlayer);
        int DeactivatePlayer(int konamiID);
        int ReactivatePlayer(int konamiID);
        int DeletePlayerRole(int konamiID, string role);
        int InsertPlayerRole(int konamiID, string role);
        int InsertNewPlayer(Player player);
    }
}
