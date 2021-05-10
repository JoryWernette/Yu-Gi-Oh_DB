/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This is an interface for data access of players
/// </summary>

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
        List<Player> SelectPlayersByActive(bool active = true);

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
        Player SelectPlayerByKonamiID(int id);

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
        List<string> SelectRolesByKonamiID(int konamiID);

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Selects the Roles Currently in the Database
        /// </summary>
        /// 
        /// <exception>No roles Found</exception>
        /// <returns>List of roles</returns>
        List<string> SelectAllRoles();

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
        int UpdatePlayerProfile(Player oldPlayer, Player newPlayer);

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
        int DeactivatePlayer(int konamiID);

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
        int ReactivatePlayer(int konamiID);

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
        int DeletePlayerRole(int konamiID, string role);

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
        int InsertPlayerRole(int konamiID, string role);

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
        int InsertNewPlayer(Player player);
    }
}
