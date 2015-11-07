using System.Linq;
using System.Web.Mvc;
using MyMovies.Dal;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            using (MoviesContext context = new MoviesContext())
            {
                var x = context.Movies.ToArray();
                var y = context.Actors.ToArray();
            }

            return View();
        }
    }
}
