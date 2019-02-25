using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeWasted.Models;
using TimeWasted.Services;

namespace TimeWasted.Web.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService(userId);
            var model = service.GetMovies();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMovieService();

            if (service.CreateMovie(model))
            {
                TempData["SaveResult"] = "Your movie was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Movie could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMovieService();
            var model = svc.GetMovieById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMovieService();
            var detail = service.GetMovieById(id);
            var model =
                new MovieEdit
                {
                    MovieId = detail.MovieId,
                    WatchedIt = detail.WatchedIt,
                    WatchLater = detail.WatchLater,
                    WorthIt = detail.WorthIt,
                    Title = detail.Title,
                    Sequel = detail.Sequel
                };
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateMovieService();
            var model = svc.GetMovieById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMovieService();

            service.DeleteMovie(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MovieId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMovieService();

            if (service.UpdateMovie(model))
            {
                TempData["SaveResult"] = "Your Movie was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Movie could not be updated.");
            return View(model);
        }


        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService(userId);
            return service;
        }
    }
}