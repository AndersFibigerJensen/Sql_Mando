using Microsoft.Data.SqlClient;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;
using System.Data;
using System.Reflection.PortableExecutable;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace Sql_Mando.Services

{
    public class MovieService : ConnectionString, IMovieService
    {
        string insertstring = $"EXEC ADDMovie @tconst=@id,@titleType=@Type,@Name=@Title,@Origin=@Original,@isAdult=@Adult,@Start=@StartYear,@End=@EndYear,@Run=@Runtime";
        string updatestring = $"EXEC altermovie @tconst=@ID,@titleType=@Type,@PrimaryTitle=@Title,@originalTitle=@Orgin,@isAdult=@Adult,@StartYear=@Start,@EndYear=@End,@Runtime=@Run";
        string removestring = $"EXEC RemoveMovie @tconst=@ID";
        string searchstring = $"select * from SearchMovie(@name)";
        string findidmovie = $"select * from FindMovie(@ID)";

        public MovieService(IConfiguration configuration) : base(configuration)
        {

        }

        public MovieService(string connection):base(connection)
        {
            
        }

        public async Task InsertMovie(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(insertstring, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        int normallength = "0000001".Length;
                        if (movie.tconst.Length > normallength)
                        {
                            if (FindMovieById(movie.tconst).Result != null)
                                throw new Exception();
                            cmd.Parameters.AddWithValue("@id", movie.tconst);
                        }
                        else
                        {
                            for (int i = 0; normallength < i; i++)
                            {
                                movie.tconst = "0" + movie.tconst;
                            }
                            movie.tconst = "tt" + movie.tconst;
                            if (FindMovieById(movie.tconst).Result != null)
                                throw new Exception();
                            cmd.Parameters.AddWithValue("@ID", movie.tconst);
                        }
                        cmd.Parameters.AddWithValue("@Type", movie.titleType);
                        cmd.Parameters.AddWithValue("@Title", movie.primaryTitle);
                        cmd.Parameters.AddWithValue("@Original", movie.originalTitle);
                        cmd.Parameters.AddWithValue("@Adult", movie.isAdult);
                        cmd.Parameters.AddWithValue("@StartYear", movie.StartYear);
                        cmd.Parameters.AddWithValue("@EndYear", movie.EndYear);
                        cmd.Parameters.AddWithValue("@Runtime", movie.RunTime);
                        cmd.ExecuteNonQuery();
                        await connection.CloseAsync();
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine(cmd.CommandText);
                    }
                    catch (Exception ex)
                    {

                    }

                }

            }
        }

        public async Task<List<Movie>> FindMovie(string title)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(searchstring, connection))
                {
                    List<Movie> movies = new List<Movie>();
                    try
                    {
                        await connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@name", title);
                        SqlDataReader reader = await cmd.ExecuteReaderAsync();
                        while(await reader.ReadAsync())
                        {
                            string idvalue = reader.GetString(0);
                            string type = reader.GetString(1);
                            string primary = reader.GetString(2);
                            string original = reader.GetString(3);
                            bool isadult = reader.GetBoolean(4);
                            int start = reader.GetInt32(5);
                            int end = reader.GetInt32(6);
                            int run = reader.GetInt32(7);
                            Movie movie=new Movie { tconst = idvalue, titleType = type, primaryTitle = primary, originalTitle = original, isAdult = isadult, StartYear = start, EndYear = end, RunTime = run };
                            movies.Add(movie);
                        }
                        await connection.CloseAsync();
                        return movies;
                        
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine(cmd.CommandText);
                        return movies;
                    }
                    catch (Exception ex)
                    {
                        return movies;
                    }
                    
                }

            }
        }

        public async Task DeleteMovie(string id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(removestring, connection))
                {
                    try
                    {
                        connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                        connection.CloseAsync();
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine(cmd.CommandText);
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
        }

        public async Task UpdateMovie(string id,Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(updatestring, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Type", movie.titleType);
                        cmd.Parameters.AddWithValue("@Title", movie.primaryTitle);
                        cmd.Parameters.AddWithValue("@Orgin", movie.originalTitle);
                        cmd.Parameters.AddWithValue("@Adult", movie.isAdult);
                        cmd.Parameters.AddWithValue("@Start", movie.StartYear);
                        cmd.Parameters.AddWithValue("@End", movie.EndYear);
                        cmd.Parameters.AddWithValue("@Run", movie.RunTime);
                        cmd.ExecuteNonQuery();
                        await connection.CloseAsync();
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine(cmd.CommandText);
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
        }

        public async Task<Movie?> FindMovieById(string id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand(findidmovie, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        await command.Connection.OpenAsync();
                        SqlDataReader reader = command.ExecuteReader();
                        if (await reader.ReadAsync())
                        {
                            string idvalue = reader.GetString(0);
                            string type = reader.GetString(1);
                            string primary = reader.GetString(2);
                            string original = reader.GetString(3);
                            bool isadult = reader.GetBoolean(4);
                            int start = reader.GetInt32(5);
                            int end = reader.GetInt32(6);
                            int run = reader.GetInt32(7);
                            return new Movie { tconst = idvalue, titleType = type, primaryTitle = primary, originalTitle = original, isAdult = isadult, StartYear = start, EndYear = end, RunTime = run };
                        }
                    }
                    catch (SqlException sql)
                    {
                        throw sql;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return null;
        }
    }
}
