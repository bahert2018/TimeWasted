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
    public class TimeController : Controller
    {
        // GET: Time
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AllShowsServices(userId);
            var model = service.GetShows();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateShowService();

            if (service.CreateShow(model))
            {

                TempData["SaveResult"] = "Your Show was created.";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "Show could not be created.");

            return View(model);
        }

        private AllShowsServices NewMethod()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AllShowsServices(userId);
            return service;
        }
        [ActionName("Details")]
        public ActionResult Details(int id)
        {
            var svc = CreateShowService();
            var model = svc.GetShowById(id);

            return View(model); 
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateShowService();
            var model = svc.GetShowById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateShowService();

            service.DeleteNote(id);

            TempData["SaveResult"] = "Your Show was deleted";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = CreateShowService();
            var detail = service.GetShowById(id);
            var model = 
                new TimeEdit
                {
                    ShowId = detail.ShowId,
                    Title = detail.Title,
                    Watchedbefore = detail.Watchedbefore,
                    SeasonNumber = detail.SeasonNumber,
                    EpisodesPerSeason = detail.EpisodesPerSeason,
                    EpisodeLength = detail.EpisodeLength,
                    WorthIt = detail.WorthIt,
                };
            return View(model);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TimeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ShowId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateShowService();

            if (service.UpdateShow(model))
            {
                TempData["SaveResult"] = "Your Show was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Show could not be updated.");
            return View(model);
        }

        private AllShowsServices CreateShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AllShowsServices(userId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}