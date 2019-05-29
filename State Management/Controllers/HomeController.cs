using State_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace State_Management.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User u)
        {
            if(u.UserName == null || u.UserName == "")
            {
                Session["Error"] = "A User Name must be entered. Field cannot be blank.";
                return RedirectToAction("Index");
            }
            else
            {
                //This wipes everything
                Session.Clear();

                //This wipes just what's at Error
                Session["Error"] = null;
                Session["User"] = u;
            }


            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Secret()
        {
            if(Session["User"] != null)
            {
                return View();
            }
            else
            {
                Session["Error"] = "You must be logged in to view this page.";
                return RedirectToAction("Index");
            }
        
        }
        public ActionResult UserList()
        {
            List<User> users = new List<User>();
            User u = new User();
            u.UserName = "JimmyScrambles";
            u.Password = "PalpatineBlewUpTheDeathStar";

            User u1 = new User();
            u1.UserName = "LukeIsWhiny1975";
            u1.Password = "BlueMilk";

            User u2 = new User();
            u2.UserName = "Bono";
            u2.Password = "R2D2";

            users.Add(u);
            users.Add(u1);
            users.Add(u2);

            ViewBag.UsersList = users;
            return View();

        }
    }
}