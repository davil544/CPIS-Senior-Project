using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Collections;
using CPIS_Senior_Project.DataModels;

namespace CPIS_Senior_Project.DataAccessLayer
{
    public class UserAuth
    {

        private SqlConnection conn; private SqlCommand cmd;
        private SqlDataAdapter da; private SqlDataReader reader;
        private DataSet ds; private string query;
        private string connectionString; private bool success;
        public UserAuth()
        {
            //Instantiate creds here and scrub them for SQL command
            connectionString = ConfigurationManager.ConnectionStrings["SiteData"].ToString();
        }

        public bool Registration(Credentials auth)
        {
            bool success = false;
            int rows;
            string query = "INSERT INTO Users (Username, Password, " +
                "Role) VALUES (@Uname, @PW, @Role);";
            SqlConnection conn;
            SqlCommand cmd;

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@Uname", SqlDbType.VarChar, 50).Value = auth.username;
            cmd.Parameters.Add("@PW", SqlDbType.VarChar, 50).Value = auth.password;
            cmd.Parameters.Add("@Role", SqlDbType.NChar, 15).Value = auth.role;

            //add the rest of the necessary info here

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
                //conn.Close();
                //return false;
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        //Either get this working or change it to show the data instead!
        public String output()
        {
            return "";
        }

        public bool login(Credentials auth)
        {
            bool success = false;
            int rows;
            string query = "SELECT Username, Password FROM Users where Username = @Uname AND Password = @PW;";
            SqlConnection conn;
            SqlCommand cmd;
            //"SELECT Count(*) FROM Users where Username = @Uname AND Password = @PW;"

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            //This is causing issues showing the row results, works without the @ vars
            cmd.Parameters.Add("@Uname", SqlDbType.VarChar, 50).Value = auth.username;
            cmd.Parameters.Add("@PW", SqlDbType.VarChar, 50).Value = auth.password;

            //add the rest of the necessary info here

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
                //conn.Close();
                //return false;
            }
            finally
            {
                conn.Close();
            }

            return success;
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