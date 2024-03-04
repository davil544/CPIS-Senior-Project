using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using CPIS_Senior_Project.DataModels;

namespace CPIS_Senior_Project.DataAccessLayer
{
    public class UserAuth
    {

        private SqlConnection conn; private SqlCommand cmd;
        private string connectionString, query;
        private SqlDataReader reader;
        private const string sql404 = "SQL Server unavailable, contact DB admin for assistance!", 
            unauthorized = "You do not have permission to access the database!  Contact the DB admin for assistance!",
            empty = "Reqired field is empty, try again!", exists = "Account Already Exists!",
            wakingUp = "SQL Server is still starting up, try again in a few seconds!",
            wrongPass = "Username or Password is incorrect, please try again!",
            failed = "Registration Failed! An unknown error has occured!";

        public UserAuth()
        {
            //Instantiate creds here and scrub them for SQL command
            connectionString = ConfigurationManager.ConnectionStrings["SiteData"].ToString();
        }
        //TODO:  Change if else statements for errors to switch case statements in Login and Registration functions
        public string Login(Account auth)
        {
            if (auth.Username.Equals("") || auth.Password.Equals(""))
            {
                return empty;
            }

            string status = wrongPass;
            query = "SELECT Username, Password FROM Users where Username = @Uname AND Password = @PW;";
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
                            status = "true";
                        }
                    }
                }
                else
                {
                    //Not sure if this is necessary, redundant code?
                    status = wrongPass;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 11001)
                {
                    //This runs when the web server is unable to connect to the SQL Server
                    status = sql404;
                }
                else if (ex.Number == 40613)
                {
                    //This runs if the query has timed out before the SQL server could start
                    status = wakingUp;
                }
                else if(ex.Number == 40615)
                {
                    //This runs when the user has not been whitelisted on the SQL Server
                    status = unauthorized;
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
            finally
            {
                conn.Close();
            }

            return status;
        }

        public string Registration(Account auth)
        {
            //Checks if fields contain data, prevents blank usernames or passwords
            if (auth.Username.Equals("") || auth.Password.Equals(""))
            {
                return empty;
            }

            int rows;
            string status = failed;
            query = "INSERT INTO Users (Username, Password, Role) VALUES (@Uname, @PW, @Role);";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);
            //TODO:  Create DB and foreign key setups to make account with necessary info
            

            //Old method of inserting parameters
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar, 50).Value = auth.Username;
            cmd.Parameters.Add("@PW", SqlDbType.NVarChar, 50).Value = auth.Password;
            cmd.Parameters.Add("@Role", SqlDbType.NChar, 15).Value = auth.Role;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    status = "success";
                }
                else
                {
                    //Not sure if this is necessary, redundant code?
                    status = failed;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    //This runs if the account already exists in the database
                    status = exists;
                }
                else if (ex.Number == 11001)
                {
                    //This runs when the web server is unable to connect to the SQL Server
                    status = sql404;
                }
                else if (ex.Number == 40613)
                {
                    //This runs if the query has timed out before the SQL server could start
                    status = wakingUp;
                }
                else if (ex.Number == 40615)
                {
                    //This runs when the user has not been whitelisted on the SQL Server
                    status = unauthorized;
                }
                else
                {
                    throw new Exception(ex.Message);
                }
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