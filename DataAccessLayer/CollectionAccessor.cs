/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This class accesses the Collection data through
/// the DBConnection class
/// </summary>

using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CollectionAccessor : ICollectionAccessor
    {
        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Creates a new Collection record
        /// </summary>
        /// 
        /// <param name="email"> The email of the Player creating the collection record</param>
        /// <param name="cardName"> The name of the card to be added to the collection</param>
        /// <param name="cardLocation"> The location where the card will be stored/used</param>
        /// <exception>No Collection created</exception>
        /// <returns>Bool denoting success or failure</returns>
        public bool AddCardToMyCollection(string email, string cardName, string cardLocation)
        {
            int result = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_insert_card_to_collection", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@CardName", cardName);
            cmd.Parameters.AddWithValue("@CardLocation", cardLocation);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();

                if (result != 1)
                {
                    throw new ApplicationException("The '" + cardName + "' could not be added to the collection.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// An abstract method for editing a collection.
        /// </summary>
        /// 
        ///<param name="collectionID">The Collection record ID to be updated</param>
        ///<param name="cardLocation">The new location for the collection record</param>
        ///<param name="oldLocation">The old location record to be overwritten</param>
        ///<exception></exception>
        ///<returns>Bool denoting success or failure</returns>
        public bool EditACardInMyCollection(int collectionID, string cardLocation, string oldLocation)
        {
            int result = 0;
            bool boolResult = false;


            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_edit_card_in_my_collection", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CollectionID", SqlDbType.Int);
            cmd.Parameters.Add("@NewCardLocation", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@OldCardLocation", SqlDbType.NVarChar, 250);

            cmd.Parameters["@CollectionID"].Value = collectionID;
            cmd.Parameters["@NewCardLocation"].Value = cardLocation;
            cmd.Parameters["@OldCardLocation"].Value = oldLocation;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new ApplicationException("The collection could not be updated.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            if (result == 1)
            {
                boolResult = true;
            }
            return boolResult;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// An abstract method for deleting a collection record.
        /// </summary>
        /// 
        ///<param name="collectionID">The id of the collection record to be deleted</param>
        ///<exception></exception>
        ///<returns>Bool denoting success or failure</returns>
        public bool RemoveACardFromMyCollection(int collectionID)
        {
            bool boolResult = false;
            int result;
            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_delete_card_from_my_collection", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CollectionID", collectionID);

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
            if (result == 1)
            {
                boolResult = true;
            }
            return boolResult;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Selects the Collection records Currently in the Database under a certain email
        /// </summary>
        /// 
        /// <param name="email"> The name of a Player</param>
        /// <exception>No Collection Found</exception>
        /// <returns>List of Collection objects</returns>
        public List<Collection> RetrieveMyCollection(string email)
        {
            List<Collection> myCollection = new List<Collection>();

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_select_my_collection_by_email", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", email);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        myCollection.Add(new Collection()
                        {
                            CollectionID = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            CardName = reader.GetString(2),
                            CardLocation = reader.GetString(3)
                        });
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return myCollection;
        }
    }
}
