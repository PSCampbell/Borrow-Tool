using BorrowTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BorrowTools.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        private ActionResult BadRequest(ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Your help page.";

            return View();
        }
    }
}