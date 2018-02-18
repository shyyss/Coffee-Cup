using CC.Models;
using CC.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(User model)
        {
            using (var context = new ListOfUsers())
            {
                if (model.UserPassword == model.ConfirmPassword)
                {
                    context.TableOfUsers.Add(model);
                    context.SaveChanges();

                    Session["UserId"] = model.Id.ToString() + model.UserName + model.UserSurname;
                    Session["UserName"] = model.UserName;
                    Session["UserSurname"] = model.UserSurname;
                }

                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(User model)
        {
            using (var context = new ListOfUsers())
            {
                var user = context.TableOfUsers.Single(m => m.UserName == model.UserName && m.UserSurname == model.UserSurname && m.UserPassword == model.UserPassword);

                if (user != null)
                {
                    Session["UserId"] = model.Id.ToString() + model.UserName + model.UserSurname;
                    Session["UserName"] = model.UserName;
                    Session["UserSurname"] = model.UserSurname;
                }
                else
                {
                    ViewBag.ErrorLogin = "Извините, проверьте правильность данных, вы где-то ошиблись";
                }

                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Account/Logout
        public ActionResult Logout(int? id)
        {
            return View();
        }

        // POST: Account/Logout
        [HttpPost]
        public ActionResult Logout(User model)
        {
            if (model.Id != null)
            {
                Session["UserId"] = null;
                Session["UserName"] = null;
                Session["UserSurname"] = null;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}