/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This class accesses the Player data through
/// the DBConnection class
/// </summary>

using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class PlayerAccessor : IPlayerAccessor
    {
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
            int result = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_safely_deactivate_player", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@KonamiID", konamiID);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();

                if(result != 1)
                {
                    throw new ApplicationException("Player could not be deactivated.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
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
            int result = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_safely_remove_playerrole", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@KonamiID", konamiID);
            cmd.Parameters.Add("@RoleID", SqlDbType.NVarChar, 6);
            cmd.Parameters["@RoleID"].Value = role;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();

                if (result != 1)
                {
                    throw new ApplicationException(role + " role could not be removed.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
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
            int result = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_add_playerrole", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@KonamiID", konamiID);
            cmd.Parameters.Add("@RoleID", SqlDbType.NVarChar, 6);
            cmd.Parameters["@RoleID"].Value = role;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();

                if (result != 1)
                {
                    throw new ApplicationException(role + " role could not be added.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
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
            int konamiID = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_insert_new_user", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@KonamiID", SqlDbType.Int);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 15);

            cmd.Parameters["@KonamiID"].Value = player.KonamiID;
            cmd.Parameters["@Email"].Value = player.Email;
            cmd.Parameters["@FirstName"].Value = player.FirstName;
            cmd.Parameters["@LastName"].Value = player.LastName;
            cmd.Parameters["@PhoneNumber"].Value = player.PhoneNumber;

            konamiID = player.KonamiID;

            try
            {
                conn.Open();
                konamiID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return konamiID;
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
            int result = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_reactivate_user", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@KonamiID", konamiID);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
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
        public List<string> SelectAllRoles()
        {
            List<string> roles = new List<string>();

            // get a connection
            var conn = DBConnection.GetDBConnection();

            // get a command
            var cmd = new SqlCommand("sp_select_all_roles", conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // execute the command
            try
            {
                // open the connection
                conn.Open();

                // execute the command
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString(0));
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
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
        public List<Player> SelectPlayersByActive(bool active = true)
        {
            List<Player> players = new List<Player>();

            // connection
            var conn = DBConnection.GetDBConnection();
            // command
            var cmd = new SqlCommand("sp_select_users_by_active", conn);
            // command type
            cmd.CommandType = CommandType.StoredProcedure;
            // parameters with value the shortcut way
            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var player = new Player()
                        {
                            KonamiID = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            LastName = reader.GetString(3),
                            PhoneNumber = reader.GetString(4),
                            Active = reader.GetBoolean(5),
                            //Roles = null // lazy instantiation - wait until needed
                        };
                        players.Add(player);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return players;
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
            List<string> roles = new List<string>();

            // get a connection
            var conn = DBConnection.GetDBConnection();

            // get a command
            var cmd = new SqlCommand("sp_select_roles_by_konamiID", conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@KonamiID", SqlDbType.Int);

            // values
            cmd.Parameters["@KonamiID"].Value = konamiID;

            // execute the command
            try
            {
                // open the connection
                conn.Open();

                // execute the command
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString(0));
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return roles;
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
            int result = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_update_player_profile_data", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@KonamiID",SqlDbType.Int);
            cmd.Parameters.Add("@NewEmail",SqlDbType.NVarChar,100);
            cmd.Parameters.Add("@NewFirstName", SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@NewLastName", SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@NewPhoneNumber", SqlDbType.NVarChar,15);
            cmd.Parameters.Add("@OldEmail", SqlDbType.NVarChar,100);
            cmd.Parameters.Add("@OldFirstName", SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@OldLastName", SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@OldPhoneNumber", SqlDbType.NVarChar,15);

            cmd.Parameters["@KonamiID"].Value = oldPlayer.KonamiID;
            cmd.Parameters["@NewEmail"].Value = newPlayer.Email;
            cmd.Parameters["@NewFirstName"].Value = newPlayer.FirstName;
            cmd.Parameters["@NewLastName"].Value = newPlayer.LastName;
            cmd.Parameters["@NewPhoneNumber"].Value = newPlayer.PhoneNumber;
            cmd.Parameters["@OldEmail"].Value = oldPlayer.Email;
            cmd.Parameters["@OldFirstName"].Value = oldPlayer.FirstName;
            cmd.Parameters["@OldLastName"].Value = oldPlayer.LastName;
            cmd.Parameters["@OldPhoneNumber"].Value = oldPlayer.PhoneNumber;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
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
            Player player = new Player();

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_select_players_by_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@KonamiID", SqlDbType.Int);
            cmd.Parameters["@KonamiID"].Value = id;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        player.KonamiID = reader.GetInt32(0);
                        player.Email = reader.GetString(1);
                        player.FirstName = reader.GetString(2);
                        player.LastName = reader.GetString(3);
                        player.PhoneNumber = reader.GetString(4);
                        player.Active = reader.GetBoolean(5);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return player;
        }
    }

}
