using System.Data.Entity;
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
            using (var context = new MoviesContext())
            {
                return View(context.Movies.ToArray());
            }
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            using (var context = new MoviesContext())
            {
                Movie movie = context.Movies
                    .Include(m => m.Actors)
                    .SingleOrDefault(m => m.Id == id);
                    
                if (movie == null)
                    return HttpNotFound();

                return View(movie);
            }
        }

        // GET: Movies/Edit/6
        public ActionResult Edit(int id)
        {
            using (var context = new MoviesContext())
            {
                Movie movie = context.Movies
                    .Include(m => m.Actors)
                    .SingleOrDefault(m => m.Id == id);

                if (movie == null)
                    return HttpNotFound();

                return View(movie);
            }
        }

        // POST: Movies/Edit
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                using (var context = new MoviesContext())
                {
                    context.Entry(movie).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");    
            }

            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            using (var context = new MoviesContext())
            {
                Movie movie = context.Movies.Find(id);
                if (movie == null)
                    return HttpNotFound();

                context.Movies.Remove(movie);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}