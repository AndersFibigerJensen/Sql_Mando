using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class GenrePageModel : PageModel
    {
        [BindProperty]
        public List<Genre> Genres { get; set; }

        private IGenreService _genreservice;

        public GenrePageModel(IGenreService genreservice)
        {
            _genreservice = genreservice;
        }

        public async Task OnGet(string movieid)
        {
            Genres = _genreservice.GetGenreFromID(movieid).Result;
        }
    }
}
