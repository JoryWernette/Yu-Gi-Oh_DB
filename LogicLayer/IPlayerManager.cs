/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This is an interface for manager of player
/// </summary>

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
        List<Player> RetrievePlayersByActive(bool active = true);

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
        /// Selects the Player's records Currently in the Database under a certain id
        /// </summary>
        /// 
        /// <param name="id"> The KonamiID of a Player</param>
        /// <exception>No Collection Found</exception>
        /// <returns>a Player objects</returns>
        List<string> RetreiveRolesByKonamiID(int konamiID);

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Selects the Roles Currently in the Database
        /// </summary>
        /// 
        /// <exception>No roles Found</exception>
        /// <returns>List of roles</returns>
        List<string> RetrieveAllRoles();

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
        /// <returns>an bool signifying success or failure</returns>
        bool EditPlayerProfile(PlayerViewModel oldPlayer, 
                                 PlayerViewModel newPlayer,
                                 List<string> oldUnassignedRoles, 
                                 List<string> newUnassignedRoles);

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Creates a new Player record
        /// </summary>
        /// 
        /// <param name="player"> The Player object of the Player to be created</param>
        /// <exception>No Collection created</exception>
        /// <returns>an bool signifying success or failure</returns>
        bool AddNewPlayer(PlayerViewModel newPlayer);
    }
}
