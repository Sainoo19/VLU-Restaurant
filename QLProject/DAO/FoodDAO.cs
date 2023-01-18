using QLProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DAO
{
    public class FoodDAO
    {

        private static FoodDAO instance;
        

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set { FoodDAO.instance = value; }
        }

        public object DataProvider { get; private set; }

        private FoodDAO()
        { }

        public List<FoodDTO> GetFoodIdCategory(int id)
        {
            string sql = "SELECT* FROM Food where idCategory = "+id;
            List<FoodDTO> listCategory = new List<FoodDTO>();
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                FoodDTO category = new FoodDTO(item);
                listCategory.Add(category);
            }
            return listCategory;
        }
        public List<FoodDTO> GetFood()
        {
            string sql = "select * from food";
            List<FoodDTO> foodlist = new List<FoodDTO>();
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                FoodDTO category = new FoodDTO(item);
                foodlist.Add(category);
            }
            return foodlist;

        }
        public void insertfood(string name, int idCategory, float price)
        {
            string sql = "INSERT INTO Food VALUES (N' " + name + " ', ' " + idCategory + " ' , ' " + price + " ') ";
            ProvideDAO.Instance.ExcuteQuery(sql);
        }
        public void updatefood(string name, int idCategory, float price, int id)
        {
            string sql = "update Food set name = N' " + name + " ', idcategory= ' " + idCategory + " ' ,price =' " + price + " ' where id =  " +id;
            ProvideDAO.Instance.ExcuteQuery(sql);
        }
       public int GetUncheckFood(string name )
        {
            string sql = "select * from food where name =N'"+name+"'";
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            if (data.Rows.Count > 0)
            {
                FoodDTO foodname = new FoodDTO(data.Rows[0]);
                return foodname.Id;

            }
            return -1;
        }
        public void deletefood(int id)
        {
            string sql = "delete from Food where id =" + id;
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            ProvideDAO.Instance.ExcuteQuery(sql);
        }

    }
}
