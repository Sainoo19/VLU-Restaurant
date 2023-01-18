using QLProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DAO
{
    internal class StaffDAO
    {
        private static StaffDAO instance;
        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return instance; }
            private set { StaffDAO.instance = value; }
        }

        public object DataProvider { get; private set; }

     
        public StaffDAO()
        { }

        public List<Staff> DSNV()
        {
            string sql = "select * from Staff ";
            List<Staff> liststaff = new List<Staff>();
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                Staff bill = new Staff(item);
                liststaff.Add(bill);
            }
            return liststaff;
        }

        public void insertNV(int ID, string Name, string ADDr, string Phonenum, string StaffType, string Gioitinh,float wage,DateTime ngaysinh)
        {
            string sql = "INSERT INTO staff VALUES ( ' " + ID + " ',N' " + Name + " ', ' " + ADDr + " ' , ' " + Phonenum + " ', ' " + Gioitinh + " ',' " + StaffType + " ',' " + wage + " ',' " + ngaysinh + " ') ";
            ProvideDAO.Instance.ExcuteQuery(sql);
        }
        public void updateNV(int id ,string Name, string ADDr, string Phonenum, string StaffType, string Gioitinh)
        {
            string sql = "update staff set name =  " + Name + " ', Addr= ' " + ADDr + " ' ,PhoneNumber =' " + Phonenum + " ',status =' " + StaffType + " ',Gioitinh =' " + Gioitinh + " ' where id =  " + id;
            ProvideDAO.Instance.ExcuteQuery(sql);
        }

        public int GetUncheckNV(string name)
        {
            string sql = "select * from staff where name ='" + name + "'";
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            if (data.Rows.Count > 0)
            {
                Staff tennv = new Staff(data.Rows[0]);
                return tennv.ID;

            }
            return -1;
        }
    }
}
