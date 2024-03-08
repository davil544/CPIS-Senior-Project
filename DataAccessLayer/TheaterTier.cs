using CPIS_Senior_Project.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CPIS_Senior_Project.DataAccessLayer
{
    public class TheaterTier
    {
        private SqlConnection conn; private SqlCommand cmd;
        private string connectionString, query;
        private SqlDataReader reader;

        public List<Movie> getMoviesList()
        {
            List<Movie> movieList = null;
            Movie movie = null;

            query = "SELECT * FROM Movies;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    movieList = new List<Movie>();
                    movie.ID = (int)reader["ID"];
                    if (reader["ID"] != DBNull.Value)
                    {
                        movie.title = reader["Title"].ToString();
                    }
                }
            }
            catch { }
            return movieList;
        }
    }
}