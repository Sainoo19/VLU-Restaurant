using QLProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DAO
{
    public class FoodCategoryDAO
    {
        private static FoodCategoryDAO instance;
        private int result;

        public static FoodCategoryDAO Instance
        {
            get { if (instance == null) instance = new FoodCategoryDAO(); return instance; }
            private set { FoodCategoryDAO.instance = value; }
        }

        public object DataProvider { get; private set; }

        private FoodCategoryDAO()
        { }

        public List<FoodCategoryDTO> GetCategory()
        {
            string sql = "SELECT* FROM FoodCategory";
            List<FoodCategoryDTO> listCategory = new List<FoodCategoryDTO>();
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                FoodCategoryDTO category = new FoodCategoryDTO(item);
                listCategory.Add(category);
            }
            return listCategory;
        }
        public FoodCategoryDTO GetCategoryid(int id)
        {
            FoodCategoryDTO category = null;
            string sql = "SELECT* FROM FoodCategory where id = "+ id ;
            List<FoodCategoryDTO> listCategory = new List<FoodCategoryDTO>();
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                category = new FoodCategoryDTO(item);
                return category;
            }
            return category;
        }

        public FoodCategoryDTO GetCategoryName(string name) //Hien thi o tab thuc an
        {
            FoodCategoryDTO categoryfood = null;
            string sqlQuery = "SELECT* FROM FoodCategory WHERE name = N'" + name + " ' ";
            DataTable data = ProvideDAO.Instance.ExcuteQuery(sqlQuery);
            foreach (DataRow item in data.Rows)
            {
                categoryfood = new FoodCategoryDTO(item);
                return categoryfood;
            }
            return categoryfood;
        }
        public bool insertFoodCategory(string name)
        {
            string sql = string.Format("INSERT INTO FoodCategory (name) VALUES ( N'{0}')", name);
            ProvideDAO.Instance.ExcuteQuery(sql);
            return result>0;
        }//thêm cột
    }
}
