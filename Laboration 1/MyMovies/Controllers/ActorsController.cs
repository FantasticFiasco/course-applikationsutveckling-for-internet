using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MyMovies.Dal;

namespace MyMovies.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MoviesContext context;

        public ActorsController()
        {
            context = new MoviesContext();
        }

        // GET: Actors
        public ActionResult Index()
        {
            return View(context.Actors.OrderBy(actor => actor.Name).ToArray());
        }

        // GET: Actors/Edit/6
        public ActionResult Edit(int id)
        {
            Actor actor = context.Actors.Find(id);

            if (actor == null)
                return HttpNotFound();

            return View(actor);
        }

        // POST: Actors/Edit
        [HttpPost]
        public ActionResult Edit(Actor actor)
        {
            if (ModelState.IsValid)
            {
                context.Entry(actor).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int id)
        {
            Actor actor = context.Actors.Find(id);
            if (actor == null)
                return HttpNotFound();

            context.Actors.Remove(actor);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}