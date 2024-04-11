using CPIS_Senior_Project.DataModels;
using System;
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

        public Movie[] GetMovies()
        {
            Movie[] movies = null;

            query = "SELECT * FROM Movies;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    movies = new Movie[GetMovieCount()];
                    while (reader.Read())
                    {
                        movies[i] = new Movie();
                        if (reader["ID"] != DBNull.Value)
                        {
                            movies[i].ID = (int)reader["ID"];
                        }
                        else
                        {
                            //This will cause a SQL exception, will be handled below
                        }

                        if (reader["Title"] != DBNull.Value)
                        {
                            movies[i].Title = reader["Title"].ToString();
                        }
                        else
                        {
                            //This code probably won't run ever, DB
                            //doesn't allow null data in this field
                            movies[i].Title = "No Title Entered";
                        }

                        if (reader["Summary"] != DBNull.Value)
                        {
                            movies[i].Summary = reader["Summary"].ToString();
                        }
                        else
                        {
                            movies[i].Summary = "Summary goes here";
                        }

                        if (reader["ReleaseYear"] != DBNull.Value)
                        {
                            movies[i].ReleaseYear = reader["ReleaseYear"].ToString();
                        }
                        else
                        {
                            movies[i].ReleaseYear = "2024";
                        }

                        if (reader["Genre"] != DBNull.Value)
                        {
                            movies[i].Genre = reader["Genre"].ToString();
                        }
                        else
                        {
                            movies[i].Genre = "No Genre Selected";
                        }

                        if (reader["MPA_Rating"] != DBNull.Value)
                        {
                            movies[i].MPA_rating = reader["MPA_Rating"].ToString();
                        }
                        else
                        {
                            movies[i].MPA_rating = "Unrated";
                        }
                        i++;
                    }
                }
            }
            catch (SqlException ex)
            {
                movies[0].Title = ErrorHandler.SQL(ex);
            }
            finally
            {
                conn.Close();
            }
            return movies;
        }

        public Movie[] GetMovies(string searchQuery)
        {
            Movie[] movies = null;

            query = "SELECT * FROM Movies WHERE Title LIKE @Title;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Title", "%" + searchQuery + "%");

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    movies = new Movie[GetMovieCount(searchQuery)];
                    while (reader.Read())
                    {
                        movies[i] = new Movie();
                        if (reader["ID"] != DBNull.Value)
                        {
                            movies[i].ID = (int)reader["ID"];
                        }

                        if (reader["Title"] != DBNull.Value)
                        {
                            movies[i].Title = reader["Title"].ToString();
                        }

                        if (reader["Summary"] != DBNull.Value)
                        {
                            movies[i].Summary = reader["Summary"].ToString();
                        }

                        if (reader["ReleaseYear"] != DBNull.Value)
                        {
                            movies[i].ReleaseYear = reader["ReleaseYear"].ToString();
                        }

                        if (reader["Genre"] != DBNull.Value)
                        {
                            movies[i].Genre = reader["Genre"].ToString();
                        }

                        if (reader["MPA_Rating"] != DBNull.Value)
                        {
                            movies[i].MPA_rating = reader["MPA_Rating"].ToString();
                        }
                        else
                        {
                            movies[i].MPA_rating = "Unrated";
                        }
                        i++;
                    }
                }
            }
            catch (SqlException ex)
            {
                movies[0].Title = ErrorHandler.SQL(ex);
            }
            finally
            {
                conn.Close();
            }
            return movies;
        }

        public Movie GetMovie(int movieID)
        {
            query = "SELECT * FROM Movies WHERE ID=" + movieID + ";";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);
            Movie movie = new Movie();

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
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
                    }
                }
            }
            catch (SqlException ex)
            {
                movie.Title = ErrorHandler.SQL(ex);
            }
            finally
            {
                conn.Close();
            }
            return movie;
        }

        public string AddMovie(Movie movie)
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

        public string UpdateMovie(Movie movie)
        {
            string status = "Failed!";
            if (movie.ID.ToString() != "")
            {
                query = "UPDATE Movies " +
                    "SET Title = @Title, Summary = @Desc, ReleaseYear = @Year, Genre = @Genre, MPA_Rating = @Rating";
                if (movie.Poster != null)
                {
                    query += ", Poster = @Poster";
                }
                query += " WHERE ID=@movieID;";

                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@movieID", movie.ID);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Desc", movie.Summary);
                cmd.Parameters.AddWithValue("@Year", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                cmd.Parameters.AddWithValue("@Rating", movie.MPA_rating);
                if (movie.Poster != null) {
                    cmd.Parameters.Add("@Poster", SqlDbType.Image).Value = movie.Poster;
                }

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows >= 1)
                    {
                        status = "Success!";
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
            else
            {
                return status;
            }
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
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public int GetMovieCount(string searchQuery)
        {
            query = "SELECT COUNT(*) FROM Movies WHERE Title LIKE @Title;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Title", "%" + searchQuery + "%");
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

        public byte[] GetPoster(int movieID)
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

        public Theater[] GetTheaters()
        {
            //Gets number of theaters to properly size array
            query = "SELECT COUNT(*) FROM Users WHERE Role = 'Theater';";
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

            Theater[] theater = null;
            query = "SELECT * FROM Users WHERE Role = 'Theater';";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    theater = new Theater[count];
                    while (reader.Read())
                    {
                        theater[i] = new Theater();
                        if (reader["Name"] != DBNull.Value)
                        {
                            theater[i].ID = reader["Name"].ToString();
                        }

                        if (reader["Address1"] != DBNull.Value)
                        {
                            theater[i].Address1 = reader["Address1"].ToString();
                        }

                        if (reader["Address2"] != DBNull.Value)
                        {
                            theater[i].Address2 = reader["Address2"].ToString();
                        }

                        if (reader["City"] != DBNull.Value)
                        {
                            theater[i].City = reader["City"].ToString();
                        }
                        
                        if (reader["State"] != DBNull.Value)
                        {
                            theater[i].State = reader["State"].ToString();
                        }

                        if (reader["Zip"] != DBNull.Value)
                        {
                            theater[i].PostalCode = reader["Zip"].ToString();
                        }

                        if (reader["Hours"] != DBNull.Value)
                        {
                            theater[i].Hours = reader["Hours"].ToString();
                        }

                        if (reader["TicketPrice"] != DBNull.Value)
                        {
                            try
                            {
                                theater[i].TicketPrice = float.Parse(reader["TicketPrice"].ToString());
                            }
                            catch
                            {
                                theater[i].TicketPrice = 0;
                            }
                        }

                        i++;
                    }
                }
            }
            catch (SqlException ex)
            {
                theater[0].ID = ErrorHandler.SQL(ex);
            }
            finally
            {
                conn.Close();
            }
            return theater;
        }

        public string TruncateString(string str, int maxlength)
        {
            return str.Substring(0, Math.Min(str.Length, maxlength)) + "...";
        }
    }
    
}