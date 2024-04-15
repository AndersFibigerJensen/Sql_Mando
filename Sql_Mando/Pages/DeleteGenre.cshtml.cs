using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class DeleteGenreModel : PageModel
    {

        [BindProperty]
        public Genre Genre { get; set; }

        private IGenreService _genreservice;

        public DeleteGenreModel(IGenreService genreservice)
        {
            _genreservice = genreservice;
        }

        public async Task OnGet(int movieid)
        {
            Genre = await _genreservice.GetGenre(movieid);
        }

        public async Task OnPost()
        {
            _genreservice.DeleteGenre(Genre);
        }

    }
}
