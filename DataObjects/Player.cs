/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// Class for the creation of Player Objects with set data fields
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Player
    {
        public int KonamiID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
    }

    public class PlayerViewModel : Player
    {
        public List<string> Roles { get; set; }
    }
}
