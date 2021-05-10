/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// Implements the Player Manager interface
/// </summary>

using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace LogicLayer
{
    public class PlayerManager : IPlayerManager
    {
        private IPlayerAccessor _playerAccessor;

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Default constructor initializes an accessor
        /// </summary>
        public PlayerManager()
        {
            _playerAccessor = new PlayerAccessor();
        }
        public PlayerManager(IPlayerAccessor playerAccessor)
        {
            _playerAccessor = playerAccessor;
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
        /// <returns>an bool signifying success or failure</returns>
        public bool AddNewPlayer(PlayerViewModel newPlayer)
        {
            bool result = false;
            int newKonamiID = 0; // invalid konamiID
            try
            {
                newKonamiID = _playerAccessor.InsertNewPlayer(newPlayer);
                if (newKonamiID == 0)
                {
                    throw new ApplicationException("New player was not added.");
                }
                // add newly assigned roles
                foreach (var role in newPlayer.Roles)
                {
                    _playerAccessor.InsertPlayerRole(newKonamiID, role);
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Add Player Failed.", ex);
            }
            return result;
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
        /// <returns>an bool signifying success or failure</returns>
        public bool EditPlayerProfile(PlayerViewModel oldPlayer,
                                        PlayerViewModel newPlayer,
                                        List<string> oldUnassignedRoles,
                                        List<string> newUnassignedRolesoles)
        {
            bool result = false;
            try
            {
                result = (1 == _playerAccessor.UpdatePlayerProfile(oldPlayer, newPlayer));
                if (result == false)
                {
                    throw new ApplicationException("Profile data not changed.");
                }
                // remove newly removed roles
                foreach (var role in newUnassignedRolesoles)
                {
                    if (!oldUnassignedRoles.Contains((role)))
                    {
                        _playerAccessor.DeletePlayerRole(oldPlayer.KonamiID, role);
                    }
                }
                // add newly assigned roles
                foreach (var role in newPlayer.Roles)
                {
                    if (!oldPlayer.Roles.Contains(role))
                    {
                        _playerAccessor.InsertPlayerRole(oldPlayer.KonamiID, role);
                    }
                }


                if (oldPlayer.Active != newPlayer.Active)
                {
                    if (newPlayer.Active == true)
                    {
                        _playerAccessor.ReactivatePlayer(oldPlayer.KonamiID);
                    }
                    else
                    {
                        _playerAccessor.DeactivatePlayer(oldPlayer.KonamiID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed.", ex);
            }
            return result;
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
        public List<string> RetrieveAllRoles()
        {
            List<string> roles = null;

            try
            {
                roles = _playerAccessor.SelectAllRoles();

                if (roles == null)
                {
                    roles = new List<string>();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data Unavailable.", ex);
            }
            return roles;
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
        public List<Player> RetrievePlayersByActive(bool active = true)
        {
            List<Player> players = null;

            try
            {
                players = _playerAccessor.SelectPlayersByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("User list not available.", ex);
            }

            return players;
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
        public List<string> RetreiveRolesByKonamiID(int konamiID)
        {
            List<string> roles = null;

            try
            {
                roles = _playerAccessor.SelectRolesByKonamiID(konamiID);

                if (roles == null)
                {
                    roles = new List<string>();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data Unavailable.", ex);
            }

            return roles;
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
            try
            {
                return _playerAccessor.SelectPlayerByKonamiID(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data unavailable.", ex);
            }
        }
    }
}
