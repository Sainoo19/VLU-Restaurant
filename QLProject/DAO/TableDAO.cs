using QLProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DAO
{
    class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return instance; }
            private set { TableDAO.instance = value; }
        }

        public object DataProvider { get; private set; }

        private TableDAO()
        { }

        public List<TableDTO> GetTable()
        {
            string sql = "SELECT* FROM TableFood";
            List<TableDTO> listTable = new List<TableDTO>();
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                TableDTO table = new TableDTO(item);
                listTable.Add(table);
            }
            return listTable;
        }

        public void CheckInStatus(int id)
        {
            string sql = "UPDATE TableFood Set status = N'Có người' WHERE id= " + id;
            ProvideDAO.Instance.ExcuteQuery(sql);
        }

        public void CheckOutStatus(int id)
        {
            string sql = "UPDATE TableFood Set status = N'Trống' WHERE id= " + id;
            ProvideDAO.Instance.ExcuteQuery(sql);
        }
    }
}
