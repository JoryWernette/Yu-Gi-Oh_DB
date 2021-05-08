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

        public PlayerManager()
        {
            _playerAccessor = new PlayerAccessor();
        }
        public PlayerManager(IPlayerAccessor playerAccessor)
        {
            _playerAccessor = playerAccessor;
        }

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

        public List<PlayerViewModel> RetrievePlayersByActive(bool active = true)
        {
            List<PlayerViewModel> players = null;

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
    }
}
