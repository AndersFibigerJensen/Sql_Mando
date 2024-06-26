﻿using Microsoft.Data.SqlClient;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Services
{
    public class GenreService : ConnectionString, IGenreService
    {
        string Insertqueary = $"Exec AddGenre(@tconst=@id,@genre=@Genre)";
        string removestring = $"Exec DeleteGenre(@Tid=@id,@genre=@Genre)";
        string searchstring = $"select * from FindAllGenre(@ID)";
        string updatestring = $"Exec UpdateGenre(@id=@ID,@genre=@Genre)";
        string searchbyid = $"Exec FindGenreByid (@id=@ID)";

        public GenreService(IConfiguration configuration) : base(configuration)
        {

        }

        public GenreService(string connection) : base(connection)
        {

        }

        public async Task DeleteGenre(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(removestring, connection))
                {
                    try
                    {
                        connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@id",genre.tconst);
                        cmd.Parameters.AddWithValue("@Genre", genre);
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

        public async Task<List<Genre>> GetGenreFromID(string id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(searchstring, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@ID", id);
                        List<Genre> Genres = new List<Genre>();
                        SqlDataReader reader = await cmd.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            int genreid = reader.GetInt32(0);
                            string nconst = reader.GetString(1);
                            string pro = reader.GetString(2);
                            Genres.Add(new Genre {Index=genreid, tconst = nconst, genre = pro });
                        }
                        await connection.CloseAsync();
                        return Genres;
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
            return null;
        }

        public async Task UpdateGenre(int id,Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(updatestring, connection))
                {
                    try
                    {
                        connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@ID",genre.Index);
                        cmd.Parameters.AddWithValue("@Genre", genre);
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

        public async Task AddGenre(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(Insertqueary, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@id", genre.tconst);
                        cmd.Parameters.AddWithValue("@Genre", genre.genre);
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

        public async Task<Genre> GetGenre(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(searchbyid, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@ID", id);
                        SqlDataReader reader = await cmd.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            int genreid = reader.GetInt32(0);
                            string nconst = reader.GetString(1);
                            string pro = reader.GetString(2);
                            return new Genre { Index = genreid, tconst = nconst, genre = pro };
                        }
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
            return null;
        }

    }
}
