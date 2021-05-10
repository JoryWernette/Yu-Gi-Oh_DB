using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class CollectionAccessorFakes : ICollectionAccessor
    {

        int rowsAffected;

        private List<Collection> myCollection = new List<Collection>();
        private Collection collection = new Collection();

        public CollectionAccessorFakes()
        {
            myCollection.Add(new Collection()
            {
              CollectionID = 1,  
              Email = "joryawernette@gmail.com",
              CardName = "Blue-Eyes White Dragon",
              CardLocation = "Blue-Eyes Deck"
            }); 
            myCollection.Add(new Collection()
            {
                CollectionID = 2,
                Email = "joryawernette@gmail.com",
                CardName = "Pot of Greed",
                CardLocation = "Collector's Binder"
            });
            myCollection.Add(new Collection()
            {
                CollectionID = 3,
                Email = "joryawernette@gmail.com",
                CardName = "Raigeki",
                CardLocation = "Collector's Binder"
            });
            myCollection.Add(new Collection()
            {
                CollectionID = 4,
                Email = "youcantsitwithus3030@icloud.com",
                CardName = "Watt Giraffe",
                CardLocation = "Watt Deck"
            });
        }

        public List<Collection> RetrieveMyCollection(string email)
        {
            List<Collection> jorysCollection = new List<Collection>();

            foreach (Collection collection in myCollection)
            {
                if (collection.Email == email)
                {
                    jorysCollection.Add(collection);
                }
            }

            return jorysCollection;
        }
    }
}
