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
        private String connectionString, query;
        private SqlDataReader reader;

        public UserAuth()
        {
            //Instantiate creds here and scrub them for SQL command
            connectionString = ConfigurationManager.ConnectionStrings["SiteData"].ToString();
        }

        public String Login(Credentials auth)
        {
            String status = "false";
            query = "SELECT Username, Password FROM Users where Username = @Uname AND Password = @PW;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);
            
            //New method of inserting parameters
            cmd.Parameters.AddWithValue("@Uname", auth.username);
            cmd.Parameters.AddWithValue("@PW", auth.password);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["Username"].ToString() == auth.username && reader["password"].ToString() == auth.password)
                        {
                            //This runs when a valid match is found in the database
                            status = "true";
                        }
                    }
                }
                else
                {
                    status = "false";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 11001 || ex.Number == 40613)
                {
                    //This runs when the web server is unable to connect to the SQL Server
                    status = "404";
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

        public String Registration(Credentials auth)
        {
            int rows;
            String status = "false";
            query = "INSERT INTO Users (Username, Password, Role) VALUES (@Uname, @PW, @Role);";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            //Old method of inserting parameters
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar, 50).Value = auth.username;
            cmd.Parameters.Add("@PW", SqlDbType.NVarChar, 50).Value = auth.password;
            cmd.Parameters.Add("@Role", SqlDbType.NChar, 15).Value = auth.role;

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
                    status = "fail";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    //This runs if the account already exists in the database
                    status = "exists";
                }
                else if (ex.Number == 11001 || ex.Number == 40613)
                {
                    //This runs when the web server is unable to connect to the SQL Server
                    status = "404";
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