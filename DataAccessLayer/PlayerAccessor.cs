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

        public List<PlayerViewModel> SelectPlayersByActive(bool active = true)
        {
            List<PlayerViewModel> players = new List<PlayerViewModel>();

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
                        var player = new PlayerViewModel()
                        {
                            KonamiID = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            LastName = reader.GetString(3),
                            PhoneNumber = reader.GetString(4),
                            Active = reader.GetBoolean(5),
                            Roles = null // lazy instantiation - wait until needed
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
    }

}
