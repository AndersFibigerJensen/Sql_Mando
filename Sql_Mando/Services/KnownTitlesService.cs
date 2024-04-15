using Microsoft.Data.SqlClient;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Services
{
    public class KnownTitlesService : ConnectionString, IKnownTitlesService
    {
        string Insertqueary = $"Exec Addtitle(@nconst=@id,@title=@knowntitle";
        string removestring = $"Exec Deletetitle(@nconst=@id,@title=@knowntitle";
        string searchstring = $"select * from FindAllKnownTitles(@id) ";
        string updatestring = $"Exec UpdateTitle(@id=@ID,@title=@knowntitle)";
        string searchbyid = $"Exec FindTitleByid(@id=@ID)";


        public KnownTitlesService(IConfiguration configuration) : base(configuration)
        {

        }

        public KnownTitlesService(string connection) : base(connection)
        {

        }


        public async Task DeleteKnownTitles(KnownTitles title)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(removestring, connection))
                {
                    try
                    {
                        connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@id",title.nconst);
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

        public async Task<List<KnownTitles>> GetKnownTitles(string id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(searchstring, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@id", id);
                        List<KnownTitles> titles= new List<KnownTitles>();
                        SqlDataReader reader = await cmd.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            long titleid = reader.GetInt64(0);
                            string nconst = reader.GetString(1);
                            string title = reader.GetString(2);
                            titles.Add(new KnownTitles { ID=titleid, nconst = nconst, knownTitle = title });
                        }
                        await connection.CloseAsync();
                        return titles;
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


        public Task<KnownTitles> UpdateTitles(KnownTitles title)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(updatestring, connection))
                {
                    try
                    {
                        connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@ID", title.ID);
                        cmd.Parameters.AddWithValue("@knowntitle", title);
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

        public Task AddTitles(string id, KnownTitles title)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(Insertqueary, connection))
                {
                    try
                    {
                        connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@knowntitle", title.knownTitle);
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
            return null;
        }

        public async Task<KnownTitles> GetKnownTitlesbyid(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(searchbyid, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = await cmd.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            long titleid = reader.GetInt64(0);
                            string nconst = reader.GetString(1);
                            string title = reader.GetString(2);
                            KnownTitles titles =new KnownTitles { ID = titleid, nconst = nconst, knownTitle = title};
                            return titles;
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
