using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using CPIS_Senior_Project.DataModels;

namespace CPIS_Senior_Project.DataAccessLayer
{
    public class Authentication
    {

        private SqlConnection conn; private SqlCommand cmd;
        private string connectionString, query;
        private SqlDataReader reader;

        public Authentication()
        {
            //Instantiate creds here and scrub them for SQL command
            connectionString = ConfigurationManager.ConnectionStrings["SiteData"].ToString();
        }
        
        public Account Login(Account auth)
        {
            if (auth.Username.Equals("") || auth.Password.Equals(""))
            {
                auth.status = ErrorHandler.empty;
                return auth;
            }

            string status = ErrorHandler.wrongPass;
            query = "SELECT Username, Password, Role, Name FROM Users where Username = @Uname AND Password = @PW;";
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
                        }
                    }
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

        public string Registration(Account auth)
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

            if (auth.Role.Equals("Customer") && auth.CC != null)
            {
                cmd.Parameters.AddWithValue("@CardNo", auth.CC.CardNumber);
                cmd.Parameters.AddWithValue("@ExpDate", auth.CC.ExpirationDate);
                cmd.Parameters.AddWithValue("@CVV", auth.CC.CVV);
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