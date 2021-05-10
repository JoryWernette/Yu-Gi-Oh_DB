using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class PlayerAccessorFakes : IPlayerAccessor
    {
        int rowsAffected;

        private List<Player> playerList = new List<Player>();

        Player newPlayer1 = new Player()
        {
            KonamiID = 99999999,
            Email = "TEST@TEST.COM",
            FirstName = "Test",
            LastName = "Player",
            PhoneNumber = "8675309",
            Active = true
        };

        public PlayerAccessorFakes() {
            playerList.Add(new Player()
            {
                KonamiID = 8888888,
                Email = "TEST@TEST.COM",
                FirstName = "Test1",
                LastName = "Player1",
                PhoneNumber = "8675309",
                Active = true
            });
            playerList.Add(new Player()
            {
                KonamiID = 7777777,
                Email = "TEST@TEST.COM",
                FirstName = "Test2",
                LastName = "Player2",
                PhoneNumber = "8675309",
                Active = true
            });
        }

        public int DeactivatePlayer(int konamiID)
        {
            newPlayer1.Active = false;
            if (newPlayer1.Active == false)
            {
                return 1;
            }
            return 0;
        }

        public int DeletePlayerRole(int konamiID, string role)
        {
            return newPlayer1.KonamiID;
        }

        public int InsertNewPlayer(Player player)
        {
            int startCount = playerList.Count;
            playerList.Add(player);
            int endCount = playerList.Count;

            if (endCount > startCount)
            {
                return 1;
            }
            return 0;
        }

        public int InsertPlayerRole(int konamiID, string role)
        {
            return newPlayer1.KonamiID;
        }

        public int ReactivatePlayer(int konamiID)
        {
            newPlayer1.Active = true;
            if (newPlayer1.Active == true)
            {
                return 1;
            }
            return 0;
        }

        public List<string> SelectAllRoles()
        {
            throw new NotImplementedException();
        }

        public Player SelectPlayerByKonamiID(int id)
        {
            return newPlayer1;
        }

        public List<Player> SelectPlayersByActive(bool active = true)
        {
            throw new NotImplementedException();
        }

        public List<string> SelectRolesByKonamiID(int konamiID)
        {
            throw new NotImplementedException();
        }

        public int UpdatePlayerProfile(Player oldPlayer, Player newPlayer)
        {
            return rowsAffected;
        }
    }
}
