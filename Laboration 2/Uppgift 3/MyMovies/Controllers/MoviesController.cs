using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MyMovies.Models;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesContext context;

        public MoviesController()
        {
            context = new MoviesContext();
        }

        // GET: Movies
        public ActionResult Index(string genreFilter)
        {
            IEnumerable<Movie> movies = context.Movies;

            // Genre filter
            int genreId;
            if (int.TryParse(genreFilter, out genreId))
            {
                movies = movies.Where(movie => movie.GenreId == genreId);
            }

            ViewBag.Genre = GenreSelectListFactory.Create();

            return View(Mapper.Map<IEnumerable<IndexMovieViewModel>>(movies));
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View(Mapper.Map<CreateMovieViewModel>(new Movie()));
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(CreateMovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = Mapper.Map<Movie>(movieViewModel);

                context.Movies.Add(movie);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            movieViewModel.Genre = GenreSelectListFactory.Create();
            return View(movieViewModel);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = context.Movies
                .Include("Genre")
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(Mapper.Map<DetailsMovieViewModel>(movie));
        }

        // GET: Movies/Edit/6
        public ActionResult Edit(int id)
        {
            Movie movie = context.Movies
                .Include("Genre")
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(Mapper.Map<EditMovieViewModel>(movie));
        }

        // POST: Movies/Edit
        [HttpPost]
        public ActionResult Edit(EditMovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = Mapper.Map<Movie>(movieViewModel);
                
                context.Entry(movie).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            movieViewModel.Genre = GenreSelectListFactory.Create();
            return View(movieViewModel);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
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