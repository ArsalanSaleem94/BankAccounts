using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Controllers;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        BankAccountController bac = new BankAccountController();
        TransactionController tac = new TransactionController();
        
        // GET: Account
        public ActionResult Index()
        {
           // if (Session["User"] != null)
                return View();
            //else return RedirectToAction("Index", "Home");
        }

        public ActionResult GetBalance()
        {
            ViewBag.Balance = tac.getBalance(Session["User"].ToString());
            //ViewBag.Balance = 1000;
            return View("Index");
        }

        public ActionResult Deposit(string money)
        {            
            tac.deposit(Convert.ToDecimal(money), Session["User"].ToString());
            ViewBag.Status = "Done";
            return View("Index");
        }

        public ActionResult Withdraw(string money)
        {
            tac.withdraw(Convert.ToDecimal(money), Session["User"].ToString());
            ViewBag.Status = "Done";
            return View("Index");
        }
        public ActionResult Transfer(string money, string toUN)
        {
            tac.transfer(Convert.ToDecimal(money), Session["User"].ToString(), toUN);
            ViewBag.TransferStatus = "Done";
            return View("Index");
        }

        public ActionResult getStatement()
        {
            ViewBag.Statement = tac.GetStatement(Session["User"].ToString());
            return View("Index");
        }
    }
}