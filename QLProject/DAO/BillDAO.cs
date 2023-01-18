using QLProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        
        private BillDAO() { }

        // Thành công: BillID
        // Thất bại: -1
        public int GetUnCheckBillIDByTableID(int id)
        {
            string sql = "SELECT * FROM Bill WHERE idTable = ' " + id + " ' AND status = 0";
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            if (data.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public int GetMaxID()
        {
            string sql = "SELECT MAX(id) FROM Bill";
            return (int)ProvideDAO.Instance.ExecuteScalarQuery(sql);
        }

        public void InsertBill(int id)
        {
            string sql = "INSERT INTO BILL(dateCheckIn, idTable, status) VALUES (getdate(), ' " + id + " ', 0)";
            ProvideDAO.Instance.ExcuteQuery(sql);
        }

        public void CheckOut(int id)
        {
            string sql = "UPDATE Bill SET datecheckout = GETDATE(), status = 1 WHERE id = " + id;
            ProvideDAO.Instance.ExcuteQuery(sql);
        }
        public void chuyen(int idNew, int id)
        {
            string sql = "update bill Set idTable = '" + idNew + "' where idTable ='" + id + "' and status =0";
            ProvideDAO.Instance.ExcuteQuery(sql);
        }
       public List<BillDTO> tongsoluong()
        {
            string sql = "select * from bill ";
            List<BillDTO> listbill = new List<BillDTO>();
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                BillDTO bill = new BillDTO(item);
                listbill.Add(bill);
            }
            return listbill;
        }

    }
}

