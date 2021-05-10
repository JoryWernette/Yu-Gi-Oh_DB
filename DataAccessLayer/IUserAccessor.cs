/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This class accesses the user data through
/// the DBConnection class
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
    public interface IUserAccessor
    {
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
        int VerifyUserNameAndPassword(string email, string passwordHash);

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// a fake method used to reactivate a Player's account.
        /// </summary>
        /// 
        /// <param name="email"> The email of the Player whose account will be retrieved</param>
        /// <exception>User could not be retrieved</exception>
        /// <returns>a user object</returns>
        User SelectUserByEmail(string email);

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
        int UpdatePasswordHash(string email, string newPasswordHash,
            string oldPasswordHash);
    }
}
