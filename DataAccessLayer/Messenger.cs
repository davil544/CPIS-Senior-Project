using CPIS_Senior_Project.DataModels;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CPIS_Senior_Project.DataAccessLayer
{
    public class Messenger
    {
        private static SqlConnection conn; private static SqlCommand cmd;
        private static string connectionString, query;
        private static SqlDataReader reader;

        static Messenger()
        {
            //Instantiate creds here
            connectionString = ConfigurationManager.ConnectionStrings["SiteData"].ToString();
        }

        public static Message[] GetMessages(string Username)
        {
            //Gets number of messages to properly size array
            query = "SELECT COUNT(*) FROM Messages where Recipient = @Uname;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Uname", Username);
            int count;

            try
            {
                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            query = "SELECT MessageID, Sender, Recipient, Message, TimeStamp " +
                "FROM Messages where Recipient = @Uname;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Uname", Username);

            Message[] msgs = null;
            query = "SELECT * FROM Users WHERE Role = 'Theater';";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    msgs = new Message[count];
                    while (reader.Read())
                    {
                        msgs[i] = new Message();
                        if (reader["MessageID"] != DBNull.Value)
                        {
                            msgs[i].ID = int.Parse(reader["MessageID"].ToString());
                        }

                        if (reader["Sender"] != DBNull.Value)
                        {
                            msgs[i].Sender = reader["Sender"].ToString();
                        }

                        if (reader["Recipient"] != DBNull.Value)
                        {
                            msgs[i].Recipient = reader["Recipient"].ToString();
                        }

                        if (reader["Message"] != DBNull.Value)
                        {
                            msgs[i].MessageContents = reader["Message"].ToString();
                        }

                        if (reader["TimeStamp"] != DBNull.Value)
                        {
                            msgs[i].TimeStamp = (DateTime)reader["TimeStamp"];
                        }
                        i++;
                    }
                }
            }
            catch (SqlException)
            {
                //Do nothing here if there is no messages
            }
            finally
            {
                conn.Close();
            }
            return msgs;
        }

        public static string SendMessage(Message msg)
        {
            string status = "Failed!";
            if (msg.Sender != "" && msg.Recipient != "")
            {
                query = "INSERT INTO Messages (Sender, Recipient, Message, TimeStamp) " +
                    "VALUES (@Sender, @Recipient, @Msg, @Time)";

                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, conn);


                cmd.Parameters.AddWithValue("@Sender", msg.Sender);
                cmd.Parameters.AddWithValue("@Recipient", msg.Recipient);
                cmd.Parameters.AddWithValue("@Msg", msg.MessageContents);
                cmd.Parameters.AddWithValue("@Time", DateTime.Now);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows >= 1)
                    {
                        status = "Success!";
                    }
                }
                catch (SqlException ex)
                {
                    status = ErrorHandler.SQL(ex);
                }
                finally
                {
                    conn.Close();
                }

                return status;
            }
            else
            {
                return status;
            }
        }
    }
}