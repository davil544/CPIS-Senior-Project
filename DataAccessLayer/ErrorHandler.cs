using System;
using System.Data.SqlClient;

namespace CPIS_Senior_Project.DataAccessLayer
{
    public class ErrorHandler
    {
        public const string empty = "Reqired field is empty, try again!",
            wrongPass = "Username or Password is incorrect, please try again!",
            failed = "Registration Failed! An unknown error has occured!",
            roleMismatch = "Role Mismatch, Registration Failed!";

        public static string SQL(SqlException ex)
        {
            switch(ex.Number)
            {
                case 2627:
                    return "Account Already Exists!";

                case 11001:
                    return "SQL Server unavailable, contact DB admin for assistance!";

                case 40613:
                    return "SQL Server is still starting up, try again in a few seconds!";

                case 40615:
                    return "You do not have permission to access the database!  Contact the DB admin for assistance!";
            }
            
            //This runs if a new code is found that has not been handled yet
            throw new Exception(ex.Message);
        }
    }
}