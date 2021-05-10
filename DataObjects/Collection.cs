/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// Class for the creation of Collection Objects with set data fields
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Collection
    {
        public int CollectionID { get; set; }
        public string Email { get; set; }
        public string CardName { get; set; }
        public string CardLocation { get; set; }

    }
}
