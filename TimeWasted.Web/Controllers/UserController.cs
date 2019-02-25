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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            var model = service.GetUsers();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateUserService();

            if (service.CreateUser(model))
            {
                TempData["SaveResult"] = "Your User was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "User could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);

            return View(model);
        }

        [ActionName("Edit")]
        public ActionResult Edit(int id)
        {
            var service = CreateUserService();
            var detail = service.GetUserById(id);
            var model =
                new UserEdit
                {
                    UserId = detail.UserId,
                    UserName = detail.UserName
                };
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateUserService();

            service.DeleteUser(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.UserId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateUserService();

            if (service.UpdateUser(model))
            {
                TempData["SaveResult"] = "Your User was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your User could not be updated.");
            return View(model);
        }


        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            return service;
        }
    }
}