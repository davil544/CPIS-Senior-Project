using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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
        }

        

        public bool login()
        {
            //Create login function here that uses the SQL server
            return true;
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