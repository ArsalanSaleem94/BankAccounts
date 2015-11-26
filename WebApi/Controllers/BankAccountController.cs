using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBProvider;
using DBEntities;

namespace WebApi.Controllers
{
    public class BankAccountController : ApiController
    {
        Funtionality func = new Funtionality();
        [HttpPost]
        public void New(string username, string password, decimal openingBalance)
        {
            
            BankAccount ba = new BankAccount();
            ba.AccountBalance = openingBalance;
            ba.Password = password;
            ba.Username = username;
            func.newAccount(ba);
        }


        public bool Login(string username, string password)
        {
            return func.Login(username, password);
        }

        
    }
}
