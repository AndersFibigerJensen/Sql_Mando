using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class MovieUpdateModel : PageModel
    {
        private IMovieService _movieservice;

        [BindProperty]
        public Movie movie { get; set; }

        public MovieUpdateModel(IMovieService movieservice)
        {
            _movieservice = movieservice;
        }
        public async Task OnGet(string id)
        {
            movie = await _movieservice.FindMovieById(id);
            
        }

        public async Task<IActionResult> OnPost()
        {
            await _movieservice.UpdateMovie(movie.tconst, movie);
            return RedirectToPage("MoviePage");
        }
    }
}
