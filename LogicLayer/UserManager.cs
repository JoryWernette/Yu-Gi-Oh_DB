/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// Implements the User Manager interface
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DataObjects;
using DataAccessLayer;

namespace LogicLayer
{
    public class UserManager : IUserManager
    {
        // constructors and dependency class
        private IUserAccessor userAccessor;

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Default constructor initializes an accessor
        /// </summary>
        public UserManager()
        {
            userAccessor = new UserAccessor();
        }
        public UserManager(IUserAccessor suppliedUserAccessor)
        {
            userAccessor = suppliedUserAccessor;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// a method to verify a user's password
        /// </summary>
        ///<param name="email">
        ///The user accounts email
        ///</param>
        ///<param name="passwordHash">The users password</param>
        ///<exception></exception>
        ///<returns>the users userID</returns>
        public User AuthenticateUser(string email, string password)
        {
            // method returns a user object or null
            User user = null;

            // hash the password
            password = hashSHA256(password);

            bool isNewUser = (password == "newuser");

            // this calls a method that throws exceptions
            try
            {
                // was the user found?
                if (1 == userAccessor.VerifyUserNameAndPassword(email, password))
                {
                    // if so, we need to get a user object
                    user = userAccessor.SelectUserByEmail(email);
                }
                else
                {
                    throw new ApplicationException("Bad Username or Password");
                }
                // return the user object
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Login Failed.", ex);
            }
            return user;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// a fake method for testing updating a password.
        /// </summary>
        ///<param name="email">
        ///The user accounts email
        ///</param>
        ///<param name="oldPasswordHash">The users original password</param>
        ///<param name="newPasswordHash">The users new password</param>
        ///<exception></exception>
        ///<returns>the users userID</returns>
        public bool UpdatePassword(User user, string oldPassword, string newPassword)
        {
            bool result = false;

            oldPassword = oldPassword.SHA256Value();
            newPassword = newPassword.SHA256Value();

            try
            {
                result = (1 == userAccessor.UpdatePasswordHash(
                    user.Email, newPassword, oldPassword));

                if(result == false)
                {
                    throw new ApplicationException("Update Failed.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Bad username or password.", ex);
            }

            return result;
        }

        // helper method to hash passwords
        private string hashSHA256(string source)
        {
            string result = "";

            // create a byte array - cryptography is byte oriented
            byte[] data;

            // create a .NET hash provider object
            using (SHA256 sha256hash = SHA256.Create())
            {
                // hash the source
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            // now to build the result string
            var s = new StringBuilder();

            // loop through the byte array
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            // convert the string builder to a string
            result = s.ToString();

            return result;
        }
    }
}
