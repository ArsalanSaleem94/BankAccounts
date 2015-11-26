using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBEntities;
using DBProvider;

namespace WebApi.Controllers
{
    public class TransactionController : ApiController
    {
        Funtionality f = new Funtionality();

        public decimal getBalance(string username)
        {
            return f.getCurrentBalance(username);
        }

        public void deposit(decimal money, string username)
        {
            f.depositMoney(money, username);
        }

        public void withdraw(decimal money, string username)
        {
            f.withdrawMoney(money, username);
        }
        public void transfer(decimal amount, string fromUserName, string toUserName)
        {
            f.transferBalance(amount, fromUserName, toUserName);
        }

        public List<Transactions> GetStatement(string username)
        {
            return f.getStatement(username);
        }
    }
}
