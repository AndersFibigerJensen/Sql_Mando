using Sql_Mando.Models;

namespace Sql_Mando.Interfaces
{
    public interface INameService
    {
        Task AddName(Name name);
        Task DeleteName(string id);
        Task<List<Name>> FindName(string input);
        Task UpdateName(string id,Name name);

        Task<Name> GetNameByIdAsync(string id);
    }
}