using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DTO
{
    public class BillDTO
    {
         /*private int id;
         private DateTime? dateCheckIn;
         private DateTime? dateCheckOut;
         private int idTable;
         private int status;

         public int Id { get => id; set => id = value; }
         public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
         public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
         public int IdTable { get => idTable; set => idTable = value; }
         public int Status { get => status; set => status = value; }

         public BillDTO(int id, DateTime? DateCheckIn, DateTime? DateCheckOut, int idTable, int status)
         {
             this.Id = id;
             this.DateCheckIn = this.DateCheckIn;
             this.DateCheckOut = this.DateCheckOut;
             this.IdTable = idTable;
             this.Status = status;
         }

         public BillDTO(DataRow row)
         {
             this.Id = (int)row["id"];
             this.DateCheckIn = (DateTime?)row["dateCheckIn"];
             this.DateCheckOut = (DateTime?)row["dateCheckOut"];
             this.IdTable = (int)row["idTable"];
             this.Status = (int)row["status"];

         }*/
        
        // Cách viết 2
        public BillDTO(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status,int idtable)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.idtable = idtable;

        }

        public BillDTO(DataRow row)
        {
            this.ID =(int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];

            var dateCheckTemp = row["dateCheckOut"];
            if (dateCheckTemp.ToString() != "")
            {
                this.DateCheckOut = (DateTime?)dateCheckTemp;
            }

            this.Status = (int)row["status"] ;
            this.idtable = (int)row["idtable"];
        }

        private int idtable;
        public int IdTable 
        { get => idtable; set => idtable = value; }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private DateTime? dateCheckIn;

        private DateTime? dateCheckOut;
        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }
        public  DateTime? DateCheckIn 
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
