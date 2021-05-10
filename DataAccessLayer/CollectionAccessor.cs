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
