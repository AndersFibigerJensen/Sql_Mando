using Sql_Mando.Models;

namespace Sql_Mando.Interfaces
{
    public interface IMovieService
    {
        Task DeleteMovie(string id);
        Task<List<Movie>> FindMovie(string title);

        Task<Movie> FindMovieById(string id);

        Task InsertMovie(Movie movie);
        Task UpdateMovie(string id,Movie movie);
    }
}