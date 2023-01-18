using QLProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DAO
{
   class AccountDAO
    {
        private static AccountDAO instance;
        private int result;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }
        public AccountDAO()
        { }
        public bool Login(string user, string pass)
        {
            string sqlLogin = "select * From Account where UserName ='" + user + "' and PassWord ='" + pass + "';";
            DataTable Result = ProvideDAO.Instance.ExcuteQuery(sqlLogin);
            return Result.Rows.Count > 0;

        }
       

        public DataTable GetListAccount()
        {
            return ProvideDAO.Instance.ExcuteQuery("SELECT UserName, DisplayName, Type FROM Account");
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = ProvideDAO.Instance.ExcuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public bool insertAccount(string name, string displayName, int type)
        {
            string sql = string.Format("INSERT INTO Account (Username , DisplayName, Type ) VALUES ( N'{0}',N'{1}',{2})", name, displayName, type);
            ProvideDAO.Instance.ExcuteQuery(sql);
            return result > 0;
        }

        public bool updateAccount(  string name, string displayName, int type)
        {
            string sql = string.Format( "update Account set DisplayName = N'{1}' , Type = {2} Where Username=N'{0}'" ,name , displayName, type);
            ProvideDAO.Instance.ExcuteQuery(sql);
            return result > 0;
        }
        public bool deleteAccount(string name)
        {
            string sql = string.Format( "delete from Account where Username =N'{0}'" , name);
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            ProvideDAO.Instance.ExcuteQuery(sql);
            return result > 0;
        }
        public bool ResetPassword(string name)
        {
            string sql = string.Format("update Account set password =N'0' where UserName = N'{0}'", name);
            ProvideDAO.Instance.ExcuteQuery(sql);
            return result > 0;
        }

    
    }
}
