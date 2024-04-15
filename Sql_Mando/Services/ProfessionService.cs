using Microsoft.Data.SqlClient;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Services
{
    public class ProfessionService : ConnectionString, IProfessionService
    {
        string Insertqueary = $"Exec AddProfession(@nconst=@id,@profession=@Pro)";
        string removestring = $"Exec DeleteTitle(@Nid=@id,@title)";
        string getProfessionsfromid = $"select * from FindAllProfessions(@id)";
        string UpdateString = $"Exec UpdateProfession(@id=@ID,@profession=@pro)";
        string searchbyid = $"select * from FindProfessionByid(@ID)";

        public ProfessionService(IConfiguration configuration) : base(configuration)
        {

        }

        public ProfessionService(string connection) : base(connection)
        {

        }

        public async Task DeleteKnownTitles(Profession pro)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(removestring, connection))
                {
                    try
                    {
                        connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@id",pro.nconst);
                        cmd.Parameters.AddWithValue("@title", pro.profession);
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

        public async Task<List<Profession>> GetKnownTitles(string id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(getProfessionsfromid, connection))
                {
                    try
                    {
                        connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@id", id);
                        List<Profession> professions = new List<Profession>();
                        SqlDataReader reader = await cmd.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            long proid = reader.GetInt64(0);
                            string nconst = reader.GetString(1);
                            string pro = reader.GetString(2);
                            professions.Add(new Profession {ID=proid, nconst = nconst, profession= pro });
                        }
                        await connection.CloseAsync();
                        return professions;
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


        public Task UpdateTitles(Profession pro)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(UpdateString, connection))
                {
                    try
                    {
                        connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@ID", pro.ID);
                        cmd.Parameters.AddWithValue("@pro", pro.profession);
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

        public Task<Profession> Addtitle(string id, Profession pro)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(Insertqueary, connection))
                {
                    try
                    {
                        connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@Pro", pro.profession);
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

        public async Task<Profession> GetProfession(int id)
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
                            long proid = reader.GetInt64(0);
                            string nconst = reader.GetString(1);
                            string pro = reader.GetString(2);
                            Profession profession = new Profession { ID = proid, nconst = nconst, profession = pro };
                            return profession;
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
