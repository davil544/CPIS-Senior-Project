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
                    while (reader.Read())
                    {
                        movieList = new List<Movie>();
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

                        //if (reader["Poster"] != DBNull.Value)
                        //{
                        //    movie.Poster = (byte[])reader["Poster"];
                        //}

                        movieList.Add(movie);
                    }
                }
            }
            catch (SqlException ex)
            {
                /* if (ex.Number == 11001)
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
                    //This runs when the user's IP has not been whitelisted on the SQL Server
                    status = unauthorized;
                } */
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return movieList;
        }

        public bool AddMovie (Movie movie)
        {
            if (movie.Title != "")
            {
                query = "INSERT INTO Movies (Title, Summary, ReleaseYear, Genre, MPA_Rating, Poster) " +
                    "VALUES (@Title, @Desc, @Year, @Genre, @Rating, @Poster)";

                //TODO:  Create theater object to pass this ID as a foreign key!
                //,@TheaterID  , TheaterID
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, conn);
                bool status = false;

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
                        status = true;
                    }
                } catch (SqlException ex)
                {
                    throw new Exception (ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                return status;
            }
            else
            {
                return false;
            }
            //TODO: Write code to make this upload data to SQL server
        }

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
                //TODO:  Implement this in a separate function for reuse between classes
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close ();
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
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return theImage;
        }
    }
    
}