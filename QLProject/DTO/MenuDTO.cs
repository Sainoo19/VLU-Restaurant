using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DTO
{
    class MenuDTO
    {
        private string name;
        private float price;
        private int count;
        private float totalPrice;

        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public int Count { get => count; set => count = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }

        public MenuDTO(string name, float price, int count, float totalPrice)
        {
            this.Name = name;
            this.Price = price;
            this.Count = count;
            this.TotalPrice = totalPrice;
        }

        public MenuDTO(DataRow row)
        {
            this.Name = row["name"].ToString();
            this.Price = float.Parse(row["price"].ToString());
            this.Count = (int)row["count"];
            this.TotalPrice = float.Parse(row["totalPrice"].ToString());
        }
    }
}
