using Sql_Mando.Models;

namespace Sql_Mando.Interfaces
{
    public interface IProfessionService
    {
        Task<Profession> Addtitle(string id, Profession title);
        Task DeleteKnownTitles(Profession profession);
        Task<List<Profession>> GetKnownTitles(string id);
        Task UpdateTitles(Profession title);

        Task<Profession> GetProfession(int id);
    }
}