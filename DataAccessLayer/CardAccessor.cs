/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This class accesses the Card data through
/// the DBConnection class
/// </summary>

using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class CardAccessor : ICardAccessor
    {
        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// Inserts a new Card
        /// </summary>
        /// 
        /// <param name="card"> The Card object to be added</param>
        /// <exception>Card not inserted</exception>
        /// <returns>an Bool signifying success or failuere</returns>
        public bool AddNewCard(Card card)
        {
            bool result = false;
            int rows;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_add_new_card", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CardID", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@CardName", SqlDbType.NVarChar, 75);
            cmd.Parameters.Add("@CardCategory", SqlDbType.NVarChar, 7);
            cmd.Parameters.Add("@CardType", SqlDbType.NVarChar, 12);
            cmd.Parameters.Add("@MonsterType", SqlDbType.NVarChar, 13);
            cmd.Parameters.Add("@MonsterSubType", SqlDbType.NVarChar, 8);
            cmd.Parameters.Add("@MonsterAttribute", SqlDbType.NVarChar, 6);
            cmd.Parameters.Add("@LevelRank", SqlDbType.Int);
            cmd.Parameters.Add("@Attack", SqlDbType.Int);
            cmd.Parameters.Add("@Defense", SqlDbType.Int);
            cmd.Parameters.Add("@PendulumScale", SqlDbType.Int);
            cmd.Parameters.Add("@LinkNumber", SqlDbType.Int);
            cmd.Parameters.Add("@BanlistPlacement", SqlDbType.NVarChar, 12);
            cmd.Parameters.Add("@CardText", SqlDbType.NVarChar, 1000);

            cmd.Parameters["@CardID"].Value = card.CardID;
            cmd.Parameters["@CardName"].Value = card.CardName;
            cmd.Parameters["@CardCategory"].Value = card.CardCategory;
            cmd.Parameters["@CardType"].Value = card.CardType;
            cmd.Parameters["@MonsterType"].Value = card.MonsterType;
            cmd.Parameters["@MonsterSubType"].Value = card.MonsterSubType;
            cmd.Parameters["@MonsterAttribute"].Value = card.MonsterAttribute;
            cmd.Parameters["@LevelRank"].Value = card.LevelRank;
            cmd.Parameters["@Attack"].Value = card.Attack;
            cmd.Parameters["@Defense"].Value = card.Defense;
            cmd.Parameters["@PendulumScale"].Value = card.PendulumScale;
            cmd.Parameters["@LinkNumber"].Value = card.LinkNumber;
            cmd.Parameters["@BanlistPlacement"].Value = card.BanlistPlacement;
            cmd.Parameters["@CardText"].Value = card.CardText;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            if (rows > 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// selects all cards
        /// </summary>
        /// 
        /// <exception>Card list not found</exception>
        /// <returns>list of card objects</returns>
        public List<Card> SelectAllCards()
        {
            List<Card> cards = new List<Card>();

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_select_all_cards", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cards.Add(new Card()
                        {
                            CardID = reader.GetString(0),
                            CardName = reader.GetString(1),
                            CardCategory = reader.GetString(2),
                            CardType = reader.GetString(3),
                            MonsterType = reader.GetString(4),
                            MonsterSubType = reader.GetString(5),
                            MonsterAttribute = reader.GetString(6),
                            LevelRank = reader.GetInt32(7),
                            Attack = reader.GetInt32(8),
                            Defense = reader.GetInt32(9),
                            PendulumScale = reader.GetInt32(10),
                            LinkNumber = reader.GetInt32(11),
                            BanlistPlacement = reader.GetString(12),
                            CardText = reader.GetString(13)
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
            return cards;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// selects a cards' information based on its name
        /// </summary>
        /// 
        /// <param name="cardName"> the name of the card to be retrieved</param>
        /// <exception>Card not found</exception>
        /// <returns>Card object</returns>
        public Card SelectCardByCardName(string cardName)
        {
            Card card = new Card();

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_select_card_by_card_name", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CardName", SqlDbType.NVarChar, 75);
            cmd.Parameters["@CardName"].Value = cardName;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        card.CardID = reader.GetString(0);
                        card.CardName = reader.GetString(1);
                        card.CardCategory = reader.GetString(2);
                        card.CardType = reader.GetString(3);
                        card.MonsterType = reader.GetString(4);
                        card.MonsterSubType = reader.GetString(5);
                        card.MonsterAttribute = reader.GetString(6);
                        card.LevelRank = reader.GetInt32(7);
                        card.Attack = reader.GetInt32(8);
                        card.Defense = reader.GetInt32(9);
                        card.PendulumScale = reader.GetInt32(10);
                        card.LinkNumber = reader.GetInt32(11);
                        card.BanlistPlacement = reader.GetString(12);
                        card.CardText = reader.GetString(13);
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
            return card;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// selects a cards' information based on its Banlist Placement
        /// </summary>
        /// 
        /// <param name="banlistPlacement"> the Banlist Placement of the card to be retrieved</param>
        /// <exception>Card not found</exception>
        /// <returns>List of Card objects</returns>
        public List<Card> SelectCardsByBanlistPlacement(string banlistPlacement)
        {
            List<Card> cards = new List<Card>();

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_select_cards_by_banlist_placement", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@BanlistPlacement", SqlDbType.NVarChar, 12);
            cmd.Parameters["@BanlistPlacement"].Value = banlistPlacement;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cards.Add(new Card()
                        {
                            CardID = reader.GetString(0),
                            CardName = reader.GetString(1),
                            CardCategory = reader.GetString(2),
                            CardType = reader.GetString(3),
                            MonsterType = reader.GetString(4),
                            MonsterSubType = reader.GetString(5),
                            MonsterAttribute = reader.GetString(6),
                            LevelRank = reader.GetInt32(7),
                            Attack = reader.GetInt32(8),
                            Defense = reader.GetInt32(9),
                            PendulumScale = reader.GetInt32(10),
                            LinkNumber = reader.GetInt32(11),
                            BanlistPlacement = reader.GetString(12),
                            CardText = reader.GetString(13)
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
            return cards;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// updates a card.
        /// </summary>
        /// 
        /// <param name="newCard"> The updated card data</param>
        /// <param name="oldCard"> The old data to be overwritten</param>
        /// <exception>Card not updated</exception>
        /// <returns>an int signifying the rows affected</returns>
        public int UpdateACard(Card newCard, Card oldCard)
        {
            int rowsAffected;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_update_a_card", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CardID", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@NewCardName", SqlDbType.NVarChar, 75);
            cmd.Parameters.Add("@NewCardCategory", SqlDbType.NVarChar, 7);
            cmd.Parameters.Add("@NewCardType", SqlDbType.NVarChar, 12);
            cmd.Parameters.Add("@NewMonsterType", SqlDbType.NVarChar, 13);
            cmd.Parameters.Add("@NewMonsterSubType", SqlDbType.NVarChar, 8);
            cmd.Parameters.Add("@NewMonsterAttribute", SqlDbType.NVarChar, 6);
            cmd.Parameters.Add("@NewLevelRank", SqlDbType.Int);
            cmd.Parameters.Add("@NewAttack", SqlDbType.Int);
            cmd.Parameters.Add("@NewDefense", SqlDbType.Int);
            cmd.Parameters.Add("@NewPendulumScale", SqlDbType.Int);
            cmd.Parameters.Add("@NewLinkNumber", SqlDbType.Int);
            cmd.Parameters.Add("@NewBanlistPlacement", SqlDbType.NVarChar, 12);
            cmd.Parameters.Add("@NewCardText", SqlDbType.NVarChar, 1000);

            cmd.Parameters["@CardID"].Value = newCard.CardID;
            cmd.Parameters["@NewCardName"].Value = newCard.CardName;
            cmd.Parameters["@NewCardCategory"].Value = newCard.CardCategory;
            cmd.Parameters["@NewCardType"].Value = newCard.CardType;
            cmd.Parameters["@NewMonsterType"].Value = newCard.MonsterType;
            cmd.Parameters["@NewMonsterSubType"].Value = newCard.MonsterSubType;
            cmd.Parameters["@NewMonsterAttribute"].Value = newCard.MonsterAttribute;
            cmd.Parameters["@NewLevelRank"].Value = newCard.LevelRank;
            cmd.Parameters["@NewAttack"].Value = newCard.Attack;
            cmd.Parameters["@NewDefense"].Value = newCard.Defense;
            cmd.Parameters["@NewPendulumScale"].Value = newCard.PendulumScale;
            cmd.Parameters["@NewLinkNumber"].Value = newCard.LinkNumber;
            cmd.Parameters["@NewBanlistPlacement"].Value = newCard.BanlistPlacement;
            cmd.Parameters["@NewCardText"].Value = newCard.CardText;


            cmd.Parameters.Add("@OldCardName", SqlDbType.NVarChar, 75);
            cmd.Parameters.Add("@OldCardCategory", SqlDbType.NVarChar, 7);
            cmd.Parameters.Add("@OldCardType", SqlDbType.NVarChar, 12);
            cmd.Parameters.Add("@OldMonsterType", SqlDbType.NVarChar, 13);
            cmd.Parameters.Add("@OldMonsterSubType", SqlDbType.NVarChar, 8);
            cmd.Parameters.Add("@OldMonsterAttribute", SqlDbType.NVarChar, 6);
            cmd.Parameters.Add("@OldLevelRank", SqlDbType.Int);
            cmd.Parameters.Add("@OldAttack", SqlDbType.Int);
            cmd.Parameters.Add("@OldDefense", SqlDbType.Int);
            cmd.Parameters.Add("@OldPendulumScale", SqlDbType.Int);
            cmd.Parameters.Add("@OldLinkNumber", SqlDbType.Int);
            cmd.Parameters.Add("@OldBanlistPlacement", SqlDbType.NVarChar, 12);
            cmd.Parameters.Add("@OldCardText", SqlDbType.NVarChar, 1000);

            cmd.Parameters["@OldCardName"].Value = oldCard.CardName;
            cmd.Parameters["@OldCardCategory"].Value = oldCard.CardCategory;
            cmd.Parameters["@OldCardType"].Value = oldCard.CardType;
            cmd.Parameters["@OldMonsterType"].Value = oldCard.MonsterType;
            cmd.Parameters["@OldMonsterSubType"].Value = oldCard.MonsterSubType;
            cmd.Parameters["@OldMonsterAttribute"].Value = oldCard.MonsterAttribute;
            cmd.Parameters["@OldLevelRank"].Value = oldCard.LevelRank;
            cmd.Parameters["@OldAttack"].Value = oldCard.Attack;
            cmd.Parameters["@OldDefense"].Value = oldCard.Defense;
            cmd.Parameters["@OldPendulumScale"].Value = oldCard.PendulumScale;
            cmd.Parameters["@OldLinkNumber"].Value = oldCard.LinkNumber;
            cmd.Parameters["@OldBanlistPlacement"].Value = oldCard.BanlistPlacement;
            cmd.Parameters["@OldCardText"].Value = oldCard.CardText;

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected;
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/05/10
        /// 
        /// updates a card.
        /// </summary>
        /// 
        /// <param name="cardName"> The name of a card to have its Banlist Placement updated</param>
        /// <param name="oldBanlistPlacement"> The old data to be overwritten</param>
        /// <param name="newBanlistPlacement"> The new data to be saved</param>
        /// <exception>Card not updated</exception>
        /// <returns>an int signifying the rows affected</returns>
        public int UpdateACardsBanlistPlacement(string cardName, string oldBanlistPlacement, string newBanlistPlacement)
        {
            int rows = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_update_a_cards_banlistplacement", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CardName", cardName);

            cmd.Parameters.Add("@OldBanlistPlacement", SqlDbType.NVarChar, 12);
            cmd.Parameters["@OldBanlistPlacement"].Value = oldBanlistPlacement;

            cmd.Parameters.Add("@NewBanlistPlacement", SqlDbType.NVarChar, 12);
            cmd.Parameters["@NewBanlistPlacement"].Value = newBanlistPlacement;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }
    }
}
