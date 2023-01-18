using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DTO
{
    class BillInfoDTO
    {
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private int idFood;

        public int IDFood
        {

            get { return idFood; }
            set { idFood = value; }
        }

        private int idBill;
        public int IDBill
        {
            get { return idBill; }
            set { idBill = value; }
        }

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public BillInfoDTO(int id, int idBill, int idFood, int count)
        {
            this.ID = id;
            this.IDBill = idBill;
            this.IDFood = idFood;
            this.Count = count;
        }

        public BillInfoDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDBill = (int)row["idBill"];
            this.IDFood = (int)row["idFood"];
            this.Count = (int)row["count"];
        }
    }
}
