using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class UpdateGenreModel : PageModel
    {

        [BindProperty]
        public Genre Genre { get; set; }

        private IGenreService _genreservice;

        public UpdateGenreModel(IGenreService genreservice)
        {
            _genreservice = genreservice;
        }

        public async Task OnGet(int id)
        {
            Genre = await _genreservice.GetGenre(id);
        }

        public async Task<IActionResult> OnPost()
        {
            await _genreservice.UpdateGenre(Genre.Index,Genre);
            return RedirectToPage("MoviePage");
        }
    }
}
