/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// Class for the creation of User Objects with set data fields
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class User
    {
        public int UserID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public List<string> Roles { get; private set; }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Constructor for the creation of User Objects with set data fields
        /// </summary>
        public User(int userID, string firstName, string lastName, 
            string phoneNumber, string email, List<string> roles)
        {
            this.UserID = userID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Roles = roles;
        }
    }
}
