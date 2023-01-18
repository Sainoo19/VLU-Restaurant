using QLProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DAO
{
    class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }
        public MenuDAO() { }

        public List<MenuDTO> GetMenu(int id)
        {
            string sql = "select F.name, F.price,Bi.count,  F.price*Bi.count as 'totalprice' from Food F, BillInfo Bi, Bill B where F.ID = Bi.idFood and B.status = 0 and Bi.idBill = B.id and idtable =" + id;
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            List<MenuDTO> listTable = new List<MenuDTO>();
            foreach (DataRow item in data.Rows)
            {
                MenuDTO tb = new MenuDTO(item);
                listTable.Add(tb);
            }
            return listTable;
        }
    }
}
