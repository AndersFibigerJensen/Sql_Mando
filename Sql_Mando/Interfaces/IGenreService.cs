using Sql_Mando.Models;

namespace Sql_Mando.Interfaces
{
    public interface IGenreService
    {
        Task AddGenre(Genre genre);
        Task DeleteGenre(Genre genre);
        Task<List<Genre>> GetGenreFromID(string id);
        Task UpdateGenre(int id,Genre genre);

        Task<Genre> GetGenre(int id);
    }
}