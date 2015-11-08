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
                MovieTitleViewModel[] movieTitles = context.Movies
                    .Select(movie => new MovieTitleViewModel { Id = movie.Id, Title = movie.Title, Rating = movie.Rating })
                    .ToArray();

                return View(movieTitles);
            }
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            using (var context = new MoviesContext())
            {
                Movie movie = context.Movies.Find(id);
                if (movie == null)
                    return HttpNotFound();

                return View(new MovieViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    Rating = movie.Rating,
                    Cast = string.Join(", ", movie.Actors.Select(actor => actor.Name))
                });
            }
        }
    }
}