/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This is an interface for manager of users
/// </summary>

using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IUserManager
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
        User AuthenticateUser(string email, string password);

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
        bool UpdatePassword(User user, string oldPassword, string newPassword);
    }
}
