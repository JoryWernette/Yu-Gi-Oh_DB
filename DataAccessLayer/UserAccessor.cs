using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataObjects;

namespace DataAccessLayer
{
    public class UserAccessor : IUserAccessor
    {
        public User SelectUserByEmail(string email)
        {
            User user = null;

            // get a connection
            var conn = DBConnection.GetDBConnection();

            // create a command
            var cmd = new SqlCommand("sp_select_user_by_email", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            // create parameters
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);

            // set parameter values
            cmd.Parameters["@Email"].Value = email;

            // execute the command
            try
            {
                // open the connection
                conn.Open();

                // execute the command
                var reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    reader.Read();
                    var userID = reader.GetInt32(0);
                    var firstName = reader.GetString(2);
                    var lastName = reader.GetString(3);
                    var phoneNumber = reader.GetString(4);
                    var active = reader.GetBoolean(5);
                    reader.Close();

                    // get the user roles
                    var playerAccessor = new PlayerAccessor();
                    var roles = playerAccessor.SelectRolesByKonamiID(userID);
                    
                    // add to a user object
                    user = new User(userID, firstName, lastName, phoneNumber, email, roles);

                }
                else
                {
                    throw new ApplicationException("User not found.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return user;
        }

        public int VerifyUserNameAndPassword(string email, string passwordHash)
        {
            int result = 0; // verification will falsify this

            // we need to start with a connection
            var conn = DBConnection.GetDBConnection();

            // next, we need a command object
            var cmd = new SqlCommand("sp_authenticate_user", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add any needed parameters
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            // set the parameter values
            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            // now that the operation is set up, we need to execute it
            // this is unsafe code, so it always goes in a try block
            try
            {
                // open the connection
                conn.Open();

                // execute the command
                result = Convert.ToInt32(cmd.ExecuteScalar());
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

        public int UpdatePasswordHash(string email, string newPasswordHash, string oldPasswordHash)
        {
            int result = 0;

            // connection
            var conn = DBConnection.GetDBConnection();
            // command
            var cmd = new SqlCommand("sp_update_passwordhash", conn);
            // command type
            cmd.CommandType = CommandType.StoredProcedure;
            // parameters
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@OldPasswordHash", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NewPasswordHash", SqlDbType.NVarChar, 100);
            // values
            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@OldPasswordHash"].Value = oldPasswordHash;
            cmd.Parameters["@NewPasswordHash"].Value = newPasswordHash;

            // execute
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
