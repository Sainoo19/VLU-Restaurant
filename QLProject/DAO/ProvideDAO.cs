using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DAO
{
    class ProvideDAO
    {
        private static ProvideDAO instance;

        string ketnoiDB = "Data Source=MSI\\SAINOO;Initial Catalog=quanlicaphe;Integrated Security=True";

       
        public static ProvideDAO Instance
        {
            get { if (instance == null) instance = new ProvideDAO(); return ProvideDAO.instance; }
            private set { ProvideDAO.instance = value; }
        }
        public ProvideDAO()
        { }
        public DataTable ExcuteQuery(string sql)
        {
            SqlConnection ketnoi = new SqlConnection(ketnoiDB);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand(sql, ketnoi);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            ketnoi.Close();
            return dt;
        }

        public int ExcuteNonQuery(string query, object[] vs)
        {
            int dt = 0;
            SqlConnection ketnoi = new SqlConnection(ketnoiDB);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand(query, ketnoi);
            dt = cmd.ExecuteNonQuery();
            ketnoi.Close();
            return dt;
        }
        public object ExecuteScalarQuery(string query)
        {
            object dt = 0;
            SqlConnection ketnoi = new SqlConnection(ketnoiDB);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand(query, ketnoi);
            dt = cmd.ExecuteScalar();
            ketnoi.Close();
            return dt;
        }
    }
}
