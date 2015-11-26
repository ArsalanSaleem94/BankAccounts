using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi;
using WebApi.Controllers;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //Here we can do dependency injecions to add one more protective layer, but right now avoided intentionally
        BankAccountController bac = new BankAccountController();
       

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult NewAccount()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            bool isLogged = bac.Login(username, password);
            if (isLogged)
            {
                Session["User"] = username;
                return View("Account");
            }
            else return View();
        }

        public ActionResult OpenAccount(string username, string password, decimal AccountBalance)
        {
            
            bac.New(username, password, AccountBalance);

            return RedirectToAction("Index");
        }
    }
}