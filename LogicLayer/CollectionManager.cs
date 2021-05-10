using DataAccessLayer;
using DataAccessFakes;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class CollectionManager : ICollectionManager
    {
        private ICollectionAccessor collectionAccessor = null;

        public CollectionManager()
        {
            collectionAccessor = new CollectionAccessor();
        }

        public List<Collection> RetrieveMyCollection(string email)
        {
            List<Collection> collection = null;

            try
            {
                collection = collectionAccessor.RetrieveMyCollection(email);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Collection Not Available.", ex);
            }

            return collection;
        }
    }
}
