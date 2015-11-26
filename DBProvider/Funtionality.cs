using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;

namespace DBProvider
{
    public class Funtionality
    {
        SBAEntities db = new SBAEntities();

        public decimal getCurrentBalance(string username)
        {
            throw new NotImplementedException();
        }

        public void depositMoney(decimal money, string username)
        {
            //add value in balance
        }

        public void withdrawMoney(decimal money, string username)
        {
            // substract money from balance
        }

        public void transferBalance(decimal amount, string fromUserName, string toUserName)
        {
            //withdraw amt from fromUserName
            //deposit amt to toUserName
        }

        public List<Transactions> getStatement(string username)
        {
            throw new NotImplementedException();
        }

        public void newAccount(BankAccount ba)
        {
            // Open New Account
        }
    }
}
