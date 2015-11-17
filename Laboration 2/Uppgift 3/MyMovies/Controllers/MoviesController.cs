using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyMovies.Models;
using MyMovies.Repositories;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieRepository movieRepository;
        private readonly GenreRepository genreRepository;

        public MoviesController()
        {
            movieRepository = new MovieRepository();
            genreRepository = new GenreRepository();
        }

        // GET: Movies
        public ActionResult Index(string genreFilter)
        {
            IEnumerable<Movie> movies;

            // Genre filter
            int genreId;
            if (int.TryParse(genreFilter, out genreId))
            {
                movies = movieRepository.Get(genreId);
            }
            else
            {
                movies = movieRepository.Get();
            }

            ViewBag.Genre = CreateGenreSelectList();

            return View(ToIndexMovieViewModels(movies));
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var movieViewModel = new CreateMovieViewModel
            {
                Genre = CreateGenreSelectList()
            };

            return View(movieViewModel);
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(CreateMovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                movieRepository.Add(ToMovie(movieViewModel));

                return RedirectToAction("Index");
            }

            movieViewModel.Genre = CreateGenreSelectList();

            return View(movieViewModel);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = movieRepository.Find(id);

            if (movie == null)
                return HttpNotFound();

            return View(DetailsMovieViewModel(movie));
        }

        // GET: Movies/Edit/6
        public ActionResult Edit(int id)
        {
            Movie movie = movieRepository.Find(id);

            if (movie == null)
                return HttpNotFound();

            var movieViewModel = ToEditMovieViewModel(movie);

            return View(movieViewModel);
        }

        // POST: Movies/Edit
        [HttpPost]
        public ActionResult Edit(EditMovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                Movie movie = movieRepository.Find(movieViewModel.Id);

                if (movie == null)
                    return HttpNotFound();

                movie.Title = movieViewModel.Title;
                movie.GenreId = movieViewModel.SelectedGenreId;
                movie.Year = movieViewModel.Year;
                movie.Rating = movieViewModel.Rating;
                movie.Cast = movieViewModel.Cast;

                movieRepository.Edit(movie);

                return RedirectToAction("Index");
            }

            movieViewModel.Genre = CreateGenreSelectList();

            return View(movieViewModel);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movie = movieRepository.Find(id);
            if (movie == null)
                return HttpNotFound();

            movieRepository.Remove(movie);
            
            return RedirectToAction("Index");
        }

        private SelectList CreateGenreSelectList()
        {
            IEnumerable<SelectListItem> empty = new[]
            {
                new SelectListItem()
            };

            IEnumerable<SelectListItem> genre = genreRepository.Get()
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                });

            return new SelectList(empty.Concat(genre), "Value", "Text");
        }

        private static Movie ToMovie(CreateMovieViewModel movieViewModel)
        {
            return new Movie
            {
                Id = movieViewModel.Id,
                Title = movieViewModel.Title,
                GenreId = movieViewModel.SelectedGenreId,
                Year = movieViewModel.Year,
                Rating = movieViewModel.Rating,
                Cast = movieViewModel.Cast
            };
        }

        private IEnumerable<IndexMovieViewModel> ToIndexMovieViewModels(IEnumerable<Movie> movies)
        {
            return movies.Select(movie => new IndexMovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = genreRepository.Find(movie.GenreId).Name,
                Rating = movie.Rating
            });
        }

        private DetailsMovieViewModel DetailsMovieViewModel(Movie movie)
        {
            return new DetailsMovieViewModel
            {
                Title = movie.Title,
                Genre = genreRepository.Find(movie.GenreId).Name,
                Rating = movie.Rating,
                Year = movie.Year,
                Cast = movie.Cast
            };
        }

        private EditMovieViewModel ToEditMovieViewModel(Movie movie)
        {
            return new EditMovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                SelectedGenreId = movie.GenreId,
                Genre = CreateGenreSelectList(),
                Year = movie.Year,
                Rating = movie.Rating,
                Cast = movie.Cast
            };
        }
    }
}