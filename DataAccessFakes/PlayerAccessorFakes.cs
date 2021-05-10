/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This class is the 'fakes' class that I use
/// to test my Player Accessor code
/// </summary>

using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Jory A. Wernette
    /// Created: 2021/05/10
    /// 
    /// This class creates a 'fake' Collection to be used
    /// in the PlayerManagerTest class
    /// </summary>
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

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// This is the Fake PlayerAccessor so I can test to see if everything but the db is working
        /// </summary>
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

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// a fake method used to deactivate a Player's account.
        /// </summary>
        /// 
        /// <param name="konamiID"> The Konami ID of the Player whose account will be deactivated</param>
        /// <exception>Performance not reactivated or deactivated</exception>
        /// <returns>an int signifying the rows affected</returns>
        public int DeactivatePlayer(int konamiID)
        {
            newPlayer1.Active = false;
            if (newPlayer1.Active == false)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// a fake method used to deactivate a Player's account.
        /// </summary>
        /// 
        /// <param name="konamiID"> The Konami ID of the Player whose role will be removed</param>
        /// <param name="role"> The role that will be removed from a Player</param>
        /// <exception>Performance not reactivated or deactivated</exception>
        /// <returns>an int signifying the rows affected</returns>
        public int DeletePlayerRole(int konamiID, string role)
        {
            return newPlayer1.KonamiID;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Creates a new Player record
        /// </summary>
        /// 
        /// <param name="player"> The Player object of the Player to be created</param>
        /// <exception>No Collection created</exception>
        /// <returns>an int signifying the rows affected</returns>
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

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Creates a new PlayerRole record
        /// </summary>
        /// 
        /// <param name="konamiID"> The Konami ID of the Player whose role will be added</param>
        /// <param name="role"> The role that will be add to a Player</param>
        /// <exception>No Collection created</exception>
        /// <returns>an int signifying the rows affected</returns>
        public int InsertPlayerRole(int konamiID, string role)
        {
            return newPlayer1.KonamiID;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// a fake method used to reactivate a Player's account.
        /// </summary>
        /// 
        /// <param name="konamiID"> The Konami ID of the Player whose account will be reactivated</param>
        /// <exception>Performance not reactivated or reactivated</exception>
        /// <returns>an int signifying the rows affected</returns>
        public int ReactivatePlayer(int konamiID)
        {
            newPlayer1.Active = true;
            if (newPlayer1.Active == true)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Selects the Roles Currently in the Database
        /// </summary>
        /// 
        /// <exception>No roles Found</exception>
        /// <returns>List of roles</returns>
        public List<string> SelectAllRoles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Selects the Player's records Currently in the Database under a certain id
        /// </summary>
        /// 
        /// <param name="id"> The KonamiID of a Player</param>
        /// <exception>No Collection Found</exception>
        /// <returns>a Player objects</returns>
        public Player SelectPlayerByKonamiID(int id)
        {
            return newPlayer1;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Selects all Players' records Currently in the Database as active
        /// </summary>
        /// 
        /// <param name="active"> Status of a Player</param>
        /// <exception>No Players Found</exception>
        /// <returns>List of Player objects</returns>
        public List<Player> SelectPlayersByActive(bool active = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Selects the Player's roles Currently in the Database under a certain konamiID
        /// </summary>
        /// 
        /// <param name="konamiID"> The KonamiID of a Player</param>
        /// <exception>No Collection Found</exception>
        /// <returns>List of Roles</returns>
        public List<string> SelectRolesByKonamiID(int konamiID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// An abstract method for editing a Player.
        /// </summary>
        ///
        ///<param name="newPlayer">The new Player to be recorded</param>
        ///<param name="oldPlayer">The old Player record to be overwritten</param>
        ///<exception></exception>
        /// <returns>an int signifying the rows affected</returns>
        public int UpdatePlayerProfile(Player oldPlayer, Player newPlayer)
        {
            return rowsAffected;
        }
    }
}
