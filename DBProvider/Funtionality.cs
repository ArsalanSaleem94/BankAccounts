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
            return (decimal)db.BankAccounts.Where(x => x.Username == username).Select(x => x.AccountBalance).FirstOrDefault();
        }

        public void depositMoney(decimal money, string username)
        {
            //Record Transaction
            Transaction t = new Transaction();
            t.Amount = money;
            t.Username = username;

            db.Transactions.Add(t);
            db.SaveChanges();

            //add value in Account balance
            var account = db.BankAccounts.Where(x => x.Username == username).FirstOrDefault();
            account.AccountBalance += money;
            db.BankAccounts.Attach(account);
            db.Entry(account).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


        }

        public void withdrawMoney(decimal money, string username)
        {
            // substract money from balance
            //Record Transaction
            Transaction t = new Transaction();
            t.Amount = -money;
            t.Username = username;

            db.Transactions.Add(t);
            db.SaveChanges();

            //add value in Account balance
            var account = db.BankAccounts.Where(x => x.Username == username).FirstOrDefault();
            account.AccountBalance -= money;
            db.BankAccounts.Attach(account);
            db.Entry(account).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void transferBalance(decimal amount, string fromUserName, string toUserName)
        {
            //withdraw amt from fromUserName
            withdrawMoney(amount, fromUserName);

            //deposit amt to toUserName
            depositMoney(amount, toUserName);
        }

        public List<Transactions> getStatement(string username)
        {
            var result = db.Transactions.Where(x => x.Username == username);
            if (result != null)
            {
                List<Transactions> list = new List<Transactions>();
                foreach (Transaction item in result)
                {
                    Transactions t = new Transactions();
                    t.Amount = (decimal)item.Amount;
                    t.Username = item.Username;
                }
                return list;
            }
            return null;
        }

        public void newAccount(BankAccount ba)
        {
            // Open New Account
            db.BankAccounts.Add(ba);
            db.SaveChanges();
        }

        public bool Login(string username, string password)
        {
            return db.BankAccounts.Where(x => x.Username == username && x.Password == password).Any();
        }
    }
}
