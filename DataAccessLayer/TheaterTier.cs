using CPIS_Senior_Project.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CPIS_Senior_Project.DataAccessLayer
{
    public class TheaterTier
    {
        private SqlConnection conn; private SqlCommand cmd;
        private string connectionString, query;
        private SqlDataReader reader;

        public TheaterTier()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SiteData"].ToString();
        }

        public List<Movie> getMoviesList()
        {
            List<Movie> movieList = null;
            Movie movie = new Movie();

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
                    while (reader.Read())
                    {
                        //movie.ID = (int)reader["ID"];
                        if (reader["ID"] != DBNull.Value)
                        {
                            movie.ID = (int)reader["ID"];
                        }
                        else
                        {
                            //This will cause a SQL exception, will be handled below
                        }

                        if (reader["Title"] != DBNull.Value)
                        {
                            movie.Title = reader["Title"].ToString();
                        }
                        else
                        {
                            //This code probably won't run ever, DB
                            //doesn't allow null data in this field
                            movie.Title = "No Title Entered";
                        }

                        if (reader["Summary"] != DBNull.Value)
                        {
                            movie.Summary = reader["Summary"].ToString();
                        }
                        else
                        {
                            movie.Summary = "Summary goes here";
                        }

                        if (reader["ReleaseYear"] != DBNull.Value)
                        {
                            movie.ReleaseYear = reader["ReleaseYear"].ToString();
                        }
                        else
                        {
                            movie.ReleaseYear = "2024";
                        }

                        if (reader["Genre"] != DBNull.Value)
                        {
                            movie.Genre = reader["Genre"].ToString();
                        }
                        else
                        {
                            movie.Genre = "No Genre Selected";
                        }

                        if (reader["MPA_Rating"] != DBNull.Value)
                        {
                            movie.MPA_rating = reader["MPA_Rating"].ToString();
                        }
                        else
                        {
                            movie.MPA_rating = "Unrated";
                        }

                        //TODO:  Figure out way to set ticket price and pull from Users table

                        movieList.Add(movie);
                    }
                }
            }
            catch (SqlException ex)
            {
                movie.Title = ErrorHandler.SQL(ex);
                movieList.Add(movie);
            }
            finally
            {
                conn.Close();
            }
            return movieList;
        }

        public string AddMovie (Movie movie)
        {
            string status = "Failed!";
            if (movie.Title != "")
            {
                query = "INSERT INTO Movies (Title, Summary, ReleaseYear, Genre, MPA_Rating, Poster) " +
                    "VALUES (@Title, @Desc, @Year, @Genre, @Rating, @Poster)";

                //TODO:  Create theater object to pass this ID as a foreign key!
                //,@TheaterID  , TheaterID
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, conn);
                

                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Desc", movie.Summary);
                cmd.Parameters.AddWithValue("@Year", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                cmd.Parameters.AddWithValue("@Rating", movie.MPA_rating);
                cmd.Parameters.Add("@Poster", SqlDbType.Image).Value = movie.Poster;

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows >= 1)
                    {
                        status = "Success!";
                    }
                } catch (SqlException ex)
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

        //This is necessary for movie posters to load properly
        public int GetMovieCount()
        {
            query = "SELECT COUNT(*) FROM Movies;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);
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
            return count;
        }

        public byte[] GetPoster (int movieID)
        {
            byte[] theImage = null;

            if (movieID == -1)
            {
                return theImage;
            }
            else
            {
                query = "SELECT * FROM Movies " +
                "WHERE ID = @ID;";
            }
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            if (movieID == -1)
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = 1;
            }
            else
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = movieID;
            }

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    ///don't need a while statement if only pulling up 1 record
                    reader.Read();
                    if (reader["Poster"] != DBNull.Value)
                    {
                        theImage = (byte[])reader["Poster"];
                    }
                    else
                    {
                        theImage = null;
                    }
                }
            }
            catch (SqlException)
            {
                //On the off chance that this runs, it is better not to return a poster than to crash the web application
                theImage = null;
                //throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return theImage;
        }

        public string TruncateString(string str, int maxlength)
        {
            return str.Substring(0, Math.Min(str.Length, maxlength)) + "...";
        }
    }
    
}