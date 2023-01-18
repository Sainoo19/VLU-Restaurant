using QLProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DAO
{
    class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            string sql = "INSERT INTO BillInfo VALUES( ' " + idBill + " ' , ' " + idFood + " ' , ' " + count + " ')";
            ProvideDAO.Instance.ExcuteQuery(sql);
            
        }

        public int CheckidFoodCount (int idBill, int idFood)
        {
            string sql = "SELECT * FROM BillInfo WHERE idFood = ' " + idFood + " ' AND idBill = ' " + idBill + " ' "; // select mon an va Bill
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            return data.Rows.Count;
        }

         public void UpdateCount (int idBill, int idFood, int pCount)
        {
            string sql = "UPDATE BillInfo SET count = count + ' " + pCount + " ' WHERE idBill = ' " + idBill + " ' AND idFood = ' " + idFood + " ' ";
            ProvideDAO.Instance.ExcuteQuery(sql);
        }



       /* public List<BillInfoDTO> GetListBillInfo(int id)
        {
            List<BillInfoDTO> listBillInfo = new List<BillInfoDTO>();

            DataTable data = ProvideDAO.Instance.ExcuteQuery("select * from BillInfo WHERE idBill = " + id);

            foreach(DataRow item in data.Rows)
            {
                BillInfoDTO info = new BillInfoDTO(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;

        } */
    }
}
