using System.Linq;
using System.Web.Mvc;
using MyMovies.Dal;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            using (var context = new MoviesContext())
            {
                MovieTitle[] movieTitles = context.Movies
                    .Select(movie => new MovieTitle { Title = movie.Title, Rating = movie.Rating })
                    .ToArray();

                return View(movieTitles);
            }
        }
    }
}