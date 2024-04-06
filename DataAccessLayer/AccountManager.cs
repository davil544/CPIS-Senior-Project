using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using CPIS_Senior_Project.DataModels;

namespace CPIS_Senior_Project.DataAccessLayer
{
    public class AccountManager
    {

        private static SqlConnection conn; private static SqlCommand cmd;
        private static string connectionString, query;
        private static SqlDataReader reader;

        static AccountManager()
        {
            //Instantiate creds here and scrub them for SQL command
            connectionString = ConfigurationManager.ConnectionStrings["SiteData"].ToString();
        }
        
        public static Account Login(Account auth)
        {
            if (auth.Username.Equals("") || auth.Password.Equals(""))
            {
                auth.status = ErrorHandler.empty;
                return auth;
            }

            string status = ErrorHandler.wrongPass;
            query = "SELECT Username, Password, Role, Name, Address1, Address2, City, State, Zip, Country, Hours, TicketPrice " +
                "FROM Users where Username = @Uname AND Password = @PW;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            //New method of inserting parameters
            cmd.Parameters.AddWithValue("@Uname", auth.Username);
            cmd.Parameters.AddWithValue("@PW", auth.Password);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["Username"].ToString() == auth.Username && reader["password"].ToString() == auth.Password)
                        {
                            //This runs when a valid match is found in the database
                            status = "valid";

                            //This will run to retrieve the user's relevant data
                            auth.Role = reader["Role"].ToString();
                            auth.FullName = reader["Name"].ToString();
                            auth.MyTheater = new Theater();
                            auth.MyTheater.Address1 = reader["Address1"].ToString();
                            auth.MyTheater.Address2 = reader["Address2"].ToString();
                            auth.MyTheater.City = reader["City"].ToString();
                            auth.MyTheater.State = reader["State"].ToString();
                            auth.MyTheater.PostalCode = reader["Zip"].ToString();
                            auth.MyTheater.Country = reader["Country"].ToString();
                            auth.MyTheater.Hours = reader["Hours"].ToString();
                            try
                            {
                                auth.MyTheater.TicketPrice = float.Parse(reader["TicketPrice"].ToString());
                            }
                            catch (FormatException)
                            {
                                auth.MyTheater.TicketPrice = 0;
                            }
                        }
                    }

                    auth.CC = GetCreditCards(auth);
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

            auth.status = status;   
            return auth;
        }

        public static string Register(Account auth)
        {
            //Checks if fields contain data, prevents blank usernames or passwords
            if (auth.Username.Equals("") || auth.Password.Equals("") || auth.FullName.Equals(""))
            {
                return ErrorHandler.empty;
            }

            if (auth.Role.Equals("Customer"))
            {
                query = "INSERT INTO Users (Username, Password, Role, Name) VALUES (@Uname, @PW, @Role, @Name);";
                if (auth.CC != null)
                {
                    query += "INSERT INTO CreditCards (CardNumber, ExpirationDate, CVV, CardOwner) VALUES (@CardNo, @ExpDate, @CVV, @Uname);";
                }
            }
            else if (auth.Role.Equals("Theater"))
            {
                query = "INSERT INTO Users (Username, Password, Role, Name, Address1, Address2, City, State, Zip, Country, Hours) " +
                    "VALUES (@Uname, @PW, @Role, @Name, @Add1, @Add2, @City, @State, @Zip, @Country, @Hours);";
            }
            else
            {
                return ErrorHandler.roleMismatch;
            }

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);
            string status = ErrorHandler.failed;
            int rows;

            //TODO:  Add for loop to pull all available credit cards available for use by customers
            if (auth.Role.Equals("Customer") && auth.CC != null)
            {
                cmd.Parameters.AddWithValue("@CardNo", auth.CC[0].CardNumber);
                cmd.Parameters.AddWithValue("@ExpDate", auth.CC[0].ExpirationDate);
                cmd.Parameters.AddWithValue("@CVV", auth.CC[0].CVV);
            }
            else
            {
                cmd.Parameters.Add("@Add1", SqlDbType.NVarChar, 50).Value = auth.MyTheater.Address1;
                cmd.Parameters.Add("@Add2", SqlDbType.NVarChar, 50).Value = auth.MyTheater.Address2;
                cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = auth.MyTheater.City;
                cmd.Parameters.Add("@State", SqlDbType.NChar, 2).Value = auth.MyTheater.State;
                cmd.Parameters.Add("@Zip", SqlDbType.NVarChar, 10).Value = auth.MyTheater.PostalCode;
                cmd.Parameters.Add("@Country", SqlDbType.NVarChar, 50).Value = auth.MyTheater.Country;
                cmd.Parameters.Add("@Hours", SqlDbType.NVarChar, 17).Value = auth.MyTheater.Hours;
            }

            //Old method of inserting parameters
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar, 50).Value = auth.Username;
            cmd.Parameters.Add("@PW", SqlDbType.NVarChar, 50).Value = auth.Password;
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar, 15).Value = auth.Role;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = auth.FullName;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    status = "success";
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

        public static string UpdateAccount(Account auth)
        { //TODO:  Update this function to update CC info for customers as well
            // Checks if fields contain data, prevents blank usernames or full names
            if (auth.Username.Equals("") || auth.FullName.Equals(""))
            {
                return ErrorHandler.empty;
            }

            if (auth.Role.Equals("Theater"))
            {
                query = "UPDATE Users " +
                     "SET Name = @Name, Address1 = @Add1, Address2 = @Add2, City = @City, State = @State, Zip = @Zip, Country = @Country, Hours = @Hours, TicketPrice = @Price " +
                     "WHERE Username = @Uname;";
            }
            else
            {
                return ErrorHandler.roleMismatch;
            }

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);
            auth.status = ErrorHandler.failed;
            int rows;

            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar, 50).Value = auth.Username;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = auth.FullName;
            cmd.Parameters.Add("@Add1", SqlDbType.NVarChar, 50).Value = auth.MyTheater.Address1;
            cmd.Parameters.Add("@Add2", SqlDbType.NVarChar, 50).Value = auth.MyTheater.Address2;
            cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = auth.MyTheater.City;
            cmd.Parameters.Add("@State", SqlDbType.NChar, 2).Value = auth.MyTheater.State;
            cmd.Parameters.Add("@Zip", SqlDbType.NVarChar, 10).Value = auth.MyTheater.PostalCode;
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar, 50).Value = auth.MyTheater.Country;
            cmd.Parameters.Add("@Hours", SqlDbType.NVarChar, 17).Value = auth.MyTheater.Hours;
            cmd.Parameters.Add("@Price", SqlDbType.Float).Value = auth.MyTheater.TicketPrice;


            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    auth.status = "success";
                }
            }
            catch (SqlException ex)
            {
                auth.status = ErrorHandler.SQL(ex);
            }
            finally
            {
                conn.Close();
            }

            return auth.status;
        }

        public static CreditCard[] GetCreditCards(Account account)
        {
            if (account.Role == "Customer")
            {
                string countQuery = "SELECT COUNT(*) FROM CreditCards " +
                    "where CardOwner = @Uname;";
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand(countQuery, conn);
                cmd.Parameters.AddWithValue("@Uname", account.Username);

                int cardCount;
                try
                {
                    conn.Open();
                    cardCount = (int)cmd.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                query = "SELECT ID, CardNumber, ExpirationDate, CVV " +
                "FROM CreditCards where CardOwner = @Uname;";
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Uname", account.Username);
                CreditCard[] cc = new CreditCard[0];

                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        int i = 0;
                        cc = new CreditCard[cardCount];
                        while (reader.Read())
                        {
                            cc[i] = new CreditCard();
                            if (reader["ID"] != DBNull.Value)
                            {
                                cc[i].CardID = (int)reader["ID"];
                            }
                            if (reader["CardNumber"] != DBNull.Value)
                            {
                                cc[i].CardNumber = (string)reader["CardNumber"];
                            }

                            if (reader["ExpirationDate"] != DBNull.Value)
                            {
                                cc[i].ExpirationDate = reader["ExpirationDate"].ToString();
                            }

                            if (reader["CVV"] != DBNull.Value)
                            {
                                cc[i].CVV = reader["CVV"].ToString();
                            }
                            i++;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();

                }
                return cc;
            }
            else
            {
                return null;
            }
        }

        //Will eventually use this for password hashing
        public void Password_Hash()
        {
            //Hashing function for password, will likely move this out of the main soon
            Console.Write("Enter a password: ");
            string password = Console.ReadLine();

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");
        } 
    }
}