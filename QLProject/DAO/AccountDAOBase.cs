using QLProject.DTO;
using System.Data;

namespace QLProject.DAO
{
     class AccountDAOBase
    {

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = ProvideDAO.Instance.ExcuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
    }
}