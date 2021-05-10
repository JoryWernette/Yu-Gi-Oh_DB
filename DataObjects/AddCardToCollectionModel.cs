/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// Class for the creation of AddCardToCollectionModel Objects with set data fields
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class AddCardToCollectionModel
    {
        public Card CardToAdd { get; set; }
        public string CardLocation { get; set; }
    }
}
