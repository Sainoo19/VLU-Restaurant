using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLProject.DTO
{
    internal class Staff
    {
        private int _ID;
        private string _Name;
        private string _ADDr;
        private string _Phonenum;
        private string _StaffType;
        private string _Gioitinh;
        private float _luong;
        private DateTime _Ngaysinh;

        public Staff(DataRow row)
        {
            this.ID = (int)row["MaNV"];
            this.Name = row["name"].ToString(); ;
            this.ADDr = row["addr"].ToString(); ;
            this.Phonenum = row["Phonenumber"].ToString(); ;
            this.StaffType = row["Status"].ToString(); ;
            this.Gioitinh = row["Gioitinh"].ToString(); ;
            this.Ngaysinh = (DateTime)(DateTime?)row["Ngaysinh"]; ;
            
        }

        public Staff(int ID, string Name, string ADDr, string Phonenum, string StaffType, string Gioitinh, float luong, DateTime Ngaysinh)
        {
            this.ID = ID;
            this.Name = Name;
            this.ADDr = ADDr;
            this.Phonenum = Phonenum;
            this.StaffType = StaffType;
            this.Gioitinh = Gioitinh;
            this.Ngaysinh = Ngaysinh;
            this.Luong = luong;    
        }

        public int ID { get => _ID; set => _ID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string ADDr { get => _ADDr; set => _ADDr = value; }
        public string Phonenum { get => _Phonenum; set => _Phonenum = value; }
        public string StaffType { get => _StaffType; set => _StaffType = value; }
        public string Gioitinh { get => _Gioitinh; set => _Gioitinh = value; }
        public float Luong { get => _luong; set => _luong = value; }
        public DateTime Ngaysinh { get => _Ngaysinh; set => _Ngaysinh = value; }
    }
}
