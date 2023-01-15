/***************************************************************************************
 *      Copyright (C) 2021 Fran Vojković, Martina Gaćina, Matea Čotić, Mirna Keser     *
 *                                                                                     *
 *              This file is part of the RP3_Projekt project.                          *
 *                                                                                     *
 ***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CaffeBar
{
    /// <summary>
    /// Database CRUD operation class.
    /// </summary>
    internal class Service
    {
        //  Get items on Caffe's menu
        internal static List<Tuple<int, String>> getMenuItems(out String errorMessage)
        {
            var list = new List<Tuple<int, String>>();
            var connection = DB.getConnection();
            var command = new SqlCommand("SELECT Id, Item FROM dbo.Storage", connection);
            errorMessage = "";

            try
            {
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    list.Add(Tuple.Create(dataReader.GetInt32(0), dataReader.GetString(1)));
            }
            catch (Exception ex)
            {
                errorMessage = "ERROR: Database error! " + ex.Message;
            }
            finally
            {
                DB.closeConnection();
            }
            return list;
        }

        //  Get item details for new receipt from STORAGE --- (coolerAmount,price)
        internal static Tuple<int, decimal> getPriceCooler(in int id, out String errorMessage)
        {
            SqlConnection connection = DB.getConnection();
            SqlCommand command = new SqlCommand("SELECT Cooler, Price FROM dbo.Storage WHERE Id=@id;", connection);
            errorMessage = "";
            Tuple<int, decimal> tuple;
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = id;

            try
            {
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                tuple = Tuple.Create<int, decimal>(dataReader.GetInt32(0), dataReader.GetDecimal(1));
            }
            catch (Exception ex)
            {
                tuple = Tuple.Create<int, decimal>(0, (decimal)0.0);
                errorMessage = "ERROR: Database error! " + ex.Message;
            }
            finally
            {
                DB.closeConnection();
            }
            return tuple;
        }

        //  Insert new receipt
        internal static String newReceipt(DataTable dataTableReceipt, String PaymentMethod, out Double total, out Int32 receiptId, double discount)
        {
            String errorMessage = "";
            //SqlTransaction transaction = null;
            total = 0.0;
            Double amount, price;
            receiptId = 0;

            foreach (DataRow item in dataTableReceipt.Rows)
            {
                Double.TryParse(item["Amount"].ToString(), out amount); Double.TryParse(item["Price per unit"].ToString(), out price);
                total += amount * price;
            }

            //total = (discount > 0.00) ? ((Double)Math.Round( total * (Double)discount / (Double)100, 2)) : total;
            if (discount != 0.0)
                total = Math.Round((100 - discount) / 100 * total, 2);

            SqlConnection connection = DB.getConnection();

            SqlCommand command = new SqlCommand("INSERT INTO dbo.Receipts(Total,Payment_method, Discount,Waiter_id) output INSERTED.ID VALUES(@total,@payment_method,@discount,@waiter_id)", connection);
            SqlCommand command2 = new SqlCommand("INSERT INTO dbo.Receipts_item(Id_ItemFK,Id_receiptFK,Amount,Price) VALUES(@id_ItemFK,@id_receiptFK,@amount,@price)", connection);
            SqlCommand command3 = new SqlCommand("UPDATE dbo.Storage SET Cooler = Cooler - @times WHERE Id=@id", connection);

            command.Parameters.Add("@total", SqlDbType.Decimal);
            command.Parameters["@total"].Value = decimal.Parse(total.ToString());
            command.Parameters.AddWithValue("@payment_method", PaymentMethod);
            command.Parameters.AddWithValue("@discount", decimal.Parse(Math.Round(discount, 2).ToString()));
            command.Parameters.AddWithValue("@waiter_id", User.id);

            command3.Parameters.Add("@id", SqlDbType.Int);
            command3.Parameters.Add("@times", SqlDbType.Int);

            try
            {

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                receiptId = reader.GetInt32(0);
                reader.Close();
                foreach (DataRow item in dataTableReceipt.Rows)
                {
                    command2.Parameters.AddWithValue("@id_ItemFK", item["Id"]);
                    command2.Parameters.AddWithValue("@id_receiptFK", receiptId);
                    command2.Parameters.AddWithValue("@amount", item["Amount"]);
                    command2.Parameters.AddWithValue("@price", item["Price per unit"]);
                    command3.Parameters["@id"].Value = int.Parse(item["id"].ToString());
                    command3.Parameters["@times"].Value = int.Parse(item["Amount"].ToString());
                    command2.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                    command2.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                errorMessage = discount.ToString() + "ERROR: Database error! " + ex.Message;
            }
            finally
            {
                DB.closeConnection();
            }
            return errorMessage;
        }

        //  Get receipt atributes
        internal static List<String> getReceiptDetails(int receiptID, out String errorMessage)
        {
            SqlConnection connection = DB.getConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.Receipts WHERE Id=@id;", connection);
            errorMessage = "";
            var list = new List<String>();
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = receiptID;

            try
            {
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                for (var i = 0; i < 7; ++i)
                    list.Add(dataReader.GetValue(i).ToString());
            }
            catch (Exception ex)
            {
                errorMessage = "ERROR: Database error! " + ex.Message;
            }
            finally
            {
                DB.closeConnection();
            }
            return list;
        }
        //  Get list of all empoyes
        public static List<Tuple<String, String>> getAllEmployeData(out String errorMessage)
        {
            SqlConnection connection = DB.getConnection();
            SqlCommand command = new SqlCommand("SELECT Id, Username FROM [User] WHERE Deleted=@deleted;", connection);
            errorMessage = "";
            var list = new List<Tuple<String, String>>();
            command.Parameters.Add("@deleted", SqlDbType.Int);
            command.Parameters["@deleted"].Value = 0;

            try
            {
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                    list.Add(Tuple.Create(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString()));
            }
            catch (Exception ex)
            {
                errorMessage = "ERROR: Database error! " + ex.Message;
            }
            finally
            {
                DB.closeConnection();
            }
            return list;
        }

        #region HappyHour
        //  Check if item is on HappyHour 
        internal static bool onHappyHour(in int itemId, out decimal newPrice, out String errorMessage) //AKO NIJE I NALAZI SE TU POZAVAT OD TU DELETE
        {

            SqlConnection connection = DB.getConnection();
            SqlCommand command = new SqlCommand("select IdItem_FK, From_, Untill, Newprice from Happyhour Where IdItem_FK = @idItem", connection);
            var onSale = false;
            errorMessage = ""; newPrice = decimal.Parse("-1");
            command.Parameters.AddWithValue("@idItem", itemId);

            try
            {
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    var untill = dataReader.GetDateTime(2);
                    var from = dataReader.GetDateTime(1);
                    if (DateTime.Compare(from, DateTime.Now) <= 0 && !(DateTime.Compare(untill, DateTime.Now) <= 0))
                    {
                        //akcija je krenula i nije prošla akcija
                        onSale = true;
                        newPrice = dataReader.GetDecimal(3);
                    }
                    else if (DateTime.Compare(untill, DateTime.Now) <= 0)    // prošla akcija
                    {
                        dataReader.Close();
                        removeExpiredFromHappyHour(itemId, out errorMessage);
                    }
                    //else akcija nije krenula pa ništa
                }
            }
            catch (Exception ex)
            {
                errorMessage += "ERROR: Database error! " + ex.Message;
            }
            finally
            {
                DB.closeConnection();
            }

            return onSale;
        }

        internal static void removeExpiredFromHappyHour(in int itemId, out String errorMessage)
        {
            SqlConnection connection = DB.getConnection();
            SqlCommand command3 = new SqlCommand("Delete from Happyhour WHERE IdItem_FK = @idItem", connection);
            errorMessage = "";
            command3.Parameters.AddWithValue("@idItem", itemId);

            try
            {
                command3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMessage += "ERROR: Database error! " + ex.Message;
            }
            finally
            {
                DB.closeConnection();
            }
            return;
        }
        //->     // not done -- not tested
        internal static String addToHappyHour(int itemId, in DateTime from_, in DateTime untill, decimal price) 
        {
            SqlConnection connection = DB.getConnection();
            SqlCommand command = new SqlCommand("INSERT INTO dbo.Happyhour(IdItem_FK, From_, Untill, Newprice)  VALUES(@idItem_FK, @from_, @untill, @Newprice)", connection);
            String errorMessage = "";

            command.Parameters.Add("@idItem_FK", SqlDbType.Int);
            command.Parameters["@idItem_FK"].Value = itemId;
            command.Parameters.Add("@from_", SqlDbType.DateTime2);
            command.Parameters["@from_"].Value = from_;
            command.Parameters.Add("@untill", SqlDbType.DateTime2);
            command.Parameters["@untill"].Value = untill;
            command.Parameters.Add("@Newprice", SqlDbType.Decimal);
            command.Parameters["@Newprice"].Value = price;

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMessage = "ERROR: Database error! " + ex.Message;
            }
            finally
            {
                DB.closeConnection();
            }
            return errorMessage;
        }
        #endregion

        #region Move to & from Cooler and Backstorage
        // add amount to cooler
        internal static void addAmount(int id, int addAmount, string column, out String errorMessage)
        {
            errorMessage = "";
            SqlConnection connection = DB.getConnection();
            SqlCommand sqlcommand2 = new SqlCommand("UPDATE dbo.Storage SET [Backstorage]= [Backstorage] - @amount WHERE Id = @id", connection);
            SqlCommand sqlcommand = new SqlCommand("UPDATE dbo.Storage SET [" + column + "]=" + column + " + @amount WHERE Id = @id", connection);
            sqlcommand.Parameters.AddWithValue("@id", id);
            sqlcommand.Parameters.AddWithValue("@amount", addAmount);
            sqlcommand2.Parameters.AddWithValue("@id", id);
            sqlcommand2.Parameters.AddWithValue("@amount", addAmount);

            try
            {
                sqlcommand.ExecuteNonQuery();
                if (column == "Cooler")
                    sqlcommand2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMessage += ("ERROR:" + ex.Message);
            }
            finally
            {
                DB.closeConnection();
            }
        }
        #endregion

        #region Discount for employes
        //  Get discount for employee
        internal static Tuple<int, int> getDiscount(string employes, out string errorMessage)
        {
            SqlConnection connection = DB.getConnection();
            SqlCommand command2 = new SqlCommand("SELECT Caffe, Juice, State_on_date FROM [User] WHERE Username=@username;", connection);
            SqlCommand command1 = new SqlCommand("UPDATE [User] SET [Caffe] = 2, [Juice] = 1  WHERE Username=@username;", connection);
            Tuple<int, int> tuple;
            errorMessage = "";
            command2.Parameters.AddWithValue("@username", employes);
            command1.Parameters.AddWithValue("@username", employes);

            try
            {
                SqlDataReader dataReader = command2.ExecuteReader();
                dataReader.Read();
                if (dataReader.GetDateTime(2).Date != DateTime.Now.Date)
                {
                    dataReader.Close();
                    command1.ExecuteNonQuery();
                    tuple = Tuple.Create(2, 1);
                }
                else
                {
                    tuple = Tuple.Create(dataReader.GetInt32(0), dataReader.GetInt32(0));
                }
            }
            catch (Exception ex)
            {
                errorMessage += "ERROR: Database error! " + ex.Message;
                tuple = Tuple.Create(-2, -1);
            }
            finally
            {
                DB.closeConnection();
            }
            return tuple;
        }
        //  Use discount for employee
        internal static void useDiscount(string employes, out string errorMessage, string item, int times)
        {
            SqlConnection connection = DB.getConnection();
            SqlCommand caffe = new SqlCommand("UPDATE [User] SET [Caffe] = [Caffe] - @times  WHERE Username=@username;", connection);
            SqlCommand juice = new SqlCommand("UPDATE [User] SET [Juice] = 0  WHERE Username=@username;", connection);
            errorMessage = "";

            caffe.Parameters.AddWithValue("@username", employes);
            caffe.Parameters.AddWithValue("@times", times);
            juice.Parameters.AddWithValue("@username", employes);


            try
            {
                if (item == "Caffe")
                    caffe.ExecuteNonQuery();
                else if (item == "Juice")
                    juice.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMessage += "ERROR: Database error! " + ex.Message;
            }
            finally
            {
                DB.closeConnection();
            }
            return;
        }
        #endregion


        #region Notifications for low item count
        internal static DataSet getItemCount()
        {
            SqlConnection connection = DB.getConnection();
            DataSet dataset = new DataSet();

            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT Item, Cooler, Backstorage FROM Storage WHERE Cooler < 5 OR Backstorage < 10 ORDER BY Cooler ", connection))
            {
                adapter.Fill(dataset);//, "Storage");
            }
            return dataset;
        }
        #endregion
        //  Get items on past receipt
        internal static DataSet getReceiptItems(in int id)
        {
            SqlConnection connection = DB.getConnection();
            DataSet dataset = new DataSet();

            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT RI.Id_itemFK AS Id, S.Item, RI.Amount, RI.Price AS Price_per_unit  FROM [Receipts_item] RI, [Storage] S WHERE RI.Id_receiptFK =@id AND S.Id=Id_itemFK", connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@id", id);
                adapter.Fill(dataset);
            }
            return dataset;
        }
        //  Delete past receipt
        internal static void deleteReceipt(in string id, out string errorMsg)
        {
            SqlConnection connection = DB.getConnection();
            SqlCommand sqlcommand = new SqlCommand("update dbo.Receipts set Deleted = 1 where Id =@id", connection);

            sqlcommand.Parameters.AddWithValue("@id", id);
            errorMsg = "Receipt deleted!";
            try
            {
                sqlcommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMsg = "ERROR:" + ex.Message;
            }
            finally
            {
                DB.closeConnection();
            }
        }
    }
}
