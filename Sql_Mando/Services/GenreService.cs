namespace Sql_Mando.Services
{
    public class GenreService:ConnectionString
    {
        string Insertqueary=$"Insert Into Genres Values(@ID,@Genre)";

        public GenreService(IConfiguration configuration):base(configuration)
        {
            
        }
    }
}
