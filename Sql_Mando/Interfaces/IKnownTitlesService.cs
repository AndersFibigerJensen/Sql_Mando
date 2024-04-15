using Sql_Mando.Models;

namespace Sql_Mando.Interfaces
{
    public interface IKnownTitlesService
    {
        Task AddTitles(string id, KnownTitles title);
        Task DeleteKnownTitles(KnownTitles title);
        Task<List<KnownTitles>> GetKnownTitles(string id);
        Task<KnownTitles> UpdateTitles(KnownTitles title);

        Task<KnownTitles> GetKnownTitlesbyid(int id);
    }
}