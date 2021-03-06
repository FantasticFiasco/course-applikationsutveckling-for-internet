﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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

            ViewBag.Genre = CreateGenreSelectList();

            return View(movies.ToArray());
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var editMovieViewModel = new MovieViewModel
            {
                Genre = CreateGenreSelectList()
            };

            return View(editMovieViewModel);
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Title = movieViewModel.Title,
                    GenreId = movieViewModel.SelectedGenreId,
                    Year = movieViewModel.Year,
                    Rating = movieViewModel.Rating,
                    Cast = movieViewModel.Cast
                };

                context.Movies.Add(movie);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            movieViewModel.Genre = CreateGenreSelectList();
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

            return View(movie);
        }

        // GET: Movies/Edit/6
        public ActionResult Edit(int id)
        {
            Movie movie = context.Movies
                .Include("Genre")
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var editMovieViewModel = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                SelectedGenreId = movie.GenreId,
                Genre = CreateGenreSelectList(),
                Year = movie.Year,
                Rating = movie.Rating,
                Cast = movie.Cast
            };

            return View(editMovieViewModel);
        }

        // POST: Movies/Edit
        [HttpPost]
        public ActionResult Edit(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                Movie movie = context.Movies.Find(movieViewModel.Id);

                if (movie == null)
                    return HttpNotFound();

                movie.Title = movieViewModel.Title;
                movie.GenreId = movieViewModel.SelectedGenreId;
                movie.Year = movieViewModel.Year;
                movie.Rating = movieViewModel.Rating;
                movie.Cast = movieViewModel.Cast;

                context.SaveChanges();

                return RedirectToAction("Index");
            }

            movieViewModel.Genre = CreateGenreSelectList();
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

        private SelectList CreateGenreSelectList()
        {
            IEnumerable<SelectListItem> empty = new[]
            {
                new SelectListItem()
            };

            IEnumerable<SelectListItem> genre = context.Genre.Select(
                g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                });

            return new SelectList(empty.Concat(genre), "Value", "Text");
        }
    }
}