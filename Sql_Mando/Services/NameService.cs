
using Microsoft.Data.SqlClient;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace Sql_Mando.Services
{
    public class NameService : ConnectionString, INameService
    {
        string Insertstring = "EXEC AddName @nconst=@id,@PrimeName=@prime,@birth=@day,@death=@dead";
        string Updatestring = "EXEC UpdateName @nconst=@id,@PrimeName=@prime,@birth=@day,@death=@dead";
        string DeleteString = "EXEC DeleteName @nconst=@id";
        string searchstring = $"select * from SearchName(@name)";
        string searchbyid = $"select * from FindName(@ID)";
        public NameService(IConfiguration configuration) : base(configuration)
        {

        }

        public NameService(string connection):base(connection)
        {
            
        }

        public async Task AddName(Name name)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(Insertstring, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        int normallength = "0000001".Length;

                        if (name.nconst.Length < normallength)
                        {
                            if (GetNameByIdAsync(name.nconst).Result != null)
                                throw new Exception();
                            cmd.Parameters.AddWithValue("@id", name.nconst);
                        }
                        else
                        {
                            for (int i = 0; normallength < i; i++)
                            {
                                name.nconst = "0" + name.nconst;
                            }
                            name.nconst = "nm" + name.nconst;
                            if (GetNameByIdAsync(name.nconst).Result != null)
                                throw new Exception();
                            cmd.Parameters.AddWithValue("@id", name.nconst);
                        }
                        cmd.Parameters.AddWithValue("@prime", name.primaryName);
                        cmd.Parameters.AddWithValue("@day", name.birthyear);
                        cmd.Parameters.AddWithValue("@dead", name.deathyear);
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

        public async Task DeleteName(string id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(DeleteString, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@id", id);
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

        public async Task UpdateName(string id,Name name)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(Updatestring, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@id", name.nconst);
                        cmd.Parameters.AddWithValue("@prime", name.primaryName);
                        cmd.Parameters.AddWithValue("@day", name.birthyear);
                        cmd.Parameters.AddWithValue("@dead", name.deathyear);
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

        public async Task<List<Name>> FindName(string input)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand(searchstring, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        cmd.Parameters.AddWithValue("@name", input);
                        SqlDataReader reader = cmd.ExecuteReader();
                        List<Name> names= new List<Name>();
                        while(await reader.ReadAsync())
                        {
                            string idvalue = reader.GetString(0);
                            string name = reader.GetString(1);
                            int end = reader.GetInt32(2);
                            int run = reader.GetInt32(3);
                            Name newname = new Name { nconst = idvalue, primaryName = name, birthyear = end, deathyear = run };
                            names.Add(newname);
                        }
                        await connection.CloseAsync();
                        return names;
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine(cmd.CommandText);
                    }
                    catch (Exception ex)
                    {

                    }
                    return null;

                }

            }
        }

        public async Task<Name> GetNameByIdAsync(string id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
              using (SqlCommand command = new SqlCommand(searchbyid, connection))
              {
                        try
                        {
                            command.Parameters.AddWithValue("@ID", id);
                            await command.Connection.OpenAsync();
                            SqlDataReader reader = command.ExecuteReader();
                            if (await reader.ReadAsync())
                            {
                                string idvalue = reader.GetString(0);
                                string name = reader.GetString(1);
                                int end = reader.GetInt32(2);
                                int run = reader.GetInt32(3);
                            return new Name { nconst = idvalue, primaryName = name, birthyear = end, deathyear = run };
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
