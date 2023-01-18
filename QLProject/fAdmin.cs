using QLProject.DAO;
using QLProject.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLProject
{
    public partial class fAdmin : Form
    {
        BindingSource accountList = new BindingSource();
        

        public fAdmin()
        {
         
            InitializeComponent();
            loadfood();
            LoadAccount();
            Loadcate();
            LoadTable();
            dgvAccount.DataSource = accountList;
            AccountBiding();
            

        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            label7.BackColor = Color.FromArgb(100, 0, 0, 0);
            label6.BackColor = Color.FromArgb(100, 0, 0, 0);
            label5.BackColor = Color.FromArgb(100, 0, 0, 0);
            label11.BackColor = Color.FromArgb(100, 0, 0, 0);
            label14.BackColor = Color.FromArgb(100, 0, 0, 0);
            label15.BackColor = Color.FromArgb(100, 0, 0, 0);
            label9.BackColor = Color.FromArgb(100, 0, 0, 0);
            label12.BackColor = Color.FromArgb(100, 0, 0, 0);
            label1.BackColor = Color.FromArgb(100, 0, 0, 0);
            label2.BackColor = Color.FromArgb(100, 0, 0, 0);
            label3.BackColor = Color.FromArgb(100, 0, 0, 0);
            label4.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
        void loadfood()
        {
            dgvfood.DataSource = FoodDAO.Instance.GetFood();
        }

        void Loadcate()
        {
            List<FoodCategoryDTO> list = FoodCategoryDAO.Instance.GetCategory();
            cbthucan.DataSource = list;
            cbthucan.DisplayMember = "Name";
            dvgFoodCategory.DataSource = FoodCategoryDAO.Instance.GetCategory();
        }
        void AccountBiding()
        {
            txtusername.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtdisplayname.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadTable()
        {
            dgvTable.DataSource = TableDAO.Instance.GetTable();
        }

        private void dgvfood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*addfood.Enabled = false;*/

            int numrow = e.RowIndex;
            textid.Text = dgvfood.Rows[numrow].Cells[0].Value.ToString();
            textfoodname.Text = dgvfood.Rows[numrow].Cells[1].Value.ToString();
            string ct = dgvfood.Rows[numrow].Cells[2].Value.ToString();
            FoodCategoryDTO category = FoodCategoryDAO.Instance.GetCategoryid(int.Parse(ct));
            cbthucan.Text = category.Name;
            textprice.Text = dgvfood.Rows[numrow].Cells[3].Value.ToString();


        }
        void AddTable(string Name)
        {
          
        }
        void AddCate(string Name)
        {
            if (FoodCategoryDAO.Instance.insertFoodCategory(Name))
            {
                MessageBox.Show("thêm tên thất bại");
            }
            else
            {
                MessageBox.Show("thêm tên thành công");
            }
            Loadcate();
        }
        void EditCate(string Name)
        {
            if (FoodCategoryDAO.Instance.insertFoodCategory(Name))
            {
                MessageBox.Show("thêm tên thất bại");
            }
            else
            {
                MessageBox.Show("thêm tên thành công");
            }
            Loadcate();
        }
        void RemoveCate(string Name)
        {
            if (FoodCategoryDAO.Instance.insertFoodCategory(Name))
            {
                MessageBox.Show("thêm tên thất bại");
            }
            else
            {
                MessageBox.Show("thêm tên thành công");
            }
            Loadcate();
        }
        void ShowCate(string Name)
        {
            if (FoodCategoryDAO.Instance.insertFoodCategory(Name))
            {
                MessageBox.Show("thêm tên thất bại");
            }
            else
            {
                MessageBox.Show("thêm tên thành công");
            }
            Loadcate();
        }
        void AddAccount(string userName, string displayName,int type)
        {
            
            if (AccountDAO.Instance.insertAccount(userName, displayName, type))
            {
                MessageBox.Show("thêm tài khoản thất bại");
            }
            else
            {
                MessageBox.Show("thêm tài khoản thành công");
            }
            LoadAccount();
            
        }

        void EditAccount(string userName, string displayName, int type)
        {
            
            if (AccountDAO.Instance.updateAccount(userName, displayName, type))
            {
                MessageBox.Show("cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("cập nhật tài khoản thất bại");
            }
            LoadAccount();
            
        }
        void DeleteAccount(string userName)
        {
            
            if (AccountDAO.Instance.deleteAccount(userName ))
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
            else
            {
                MessageBox.Show("xóa tài khoản thành công");
            }
            LoadAccount();
            
        }
        void resetpass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Reset password thất bại");
            }
            else
            {
                MessageBox.Show("Reset passwor thành công");
            }
            LoadAccount();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textid.Clear();
            textfoodname.Clear();
            textprice.Clear();
            textfoodname.Focus();
         /*   addfood.Enabled = true;*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textfoodname.Text == "" || textprice.Text == "")
            {
                MessageBox.Show("Tên Món hoặc Giá không được rỗng");
            }
            else
            {
                string foodname = textfoodname.Text;
                float price = float.Parse(textprice.Text);
                FoodCategoryDTO category = FoodCategoryDAO.Instance.GetCategoryName(cbthucan.Text);
                int idcategory = category.Id;

                if (FoodDAO.Instance.GetUncheckFood(foodname) != -1)
                {
                    
                    MessageBox.Show("da co");
                }
                else
                {
                    FoodDAO.Instance.insertfood(foodname, idcategory, price);
                    loadfood();
                }
            }
        }

        private void buttonsua_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textid.Text);
            string foodname = textfoodname.Text;
            float price = float.Parse(textprice.Text);
            FoodCategoryDTO catepgory = FoodCategoryDAO.Instance.GetCategoryName(cbthucan.Text);
            int idcategory = catepgory.Id;
            FoodDAO.Instance.updatefood(foodname, idcategory, price, id);
            loadfood();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textid.Text);
            FoodDAO.Instance.deletefood(id);
            loadfood();
        }

        private void dgvfood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string userName = txtusername.Text;
            string displayName = txtdisplayname.Text;
            int type =(int) numericUpDown1.Value;
            AddAccount(userName, displayName, type);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string userName = txtusername.Text;
            string displayName = txtdisplayname.Text;
            int type = (int)numericUpDown1.Value;
            EditAccount(userName, displayName, type);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string userName = txtusername.Text;
            DeleteAccount(userName);
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string userName= txtusername.Text;

            resetpass(userName);

            // reset passowrd ở đây nó sẽ trả về mật khẩu mặc định của SQL là 0 !!!!
        }
        private void button14_Click(object sender, EventArgs e)
        {
            string Name = textBox11.Text;
            AddCate(Name);
        }


        private void tcDanhMuc_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Loadcate();
        }

        private void button13_Click(object sender, EventArgs e)
        {
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
           
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }
        void Loadlist(DateTime checkin,DateTime checkout)
        {
           dataGridView1.DataSource = BillDAO.Instance.tongsoluong();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Loadlist(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }






        //Nhan vien
        void LoadlistNV()
        {
            dataview.DataSource = StaffDAO.Instance.DSNV();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            LoadlistNV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TB_tennv.Text == "" || TB_MSNV.Text == "")
            {
                MessageBox.Show("Tên Nhan vien hoặc MSNV không được rỗng");
            }
            else
            {
                string tennv = TB_tennv.Text;
                int MSNV =int.Parse( TB_MSNV.Text);
                string diachi = TB_diachi.Text;
                string sdt = TB_sdt.Text;
                string gioitinh = TB_gioitinh.Text;
                string status =TB_chucvu.Text;
                float wage = float.Parse(TB_luong.Text);
                DateTime ngaysinh = dateTimengaysinh.Value;

                if (StaffDAO.Instance.GetUncheckNV(tennv) != -1)
                {

                    MessageBox.Show("da co");
                }
                else
                {
                    StaffDAO.Instance.insertNV(MSNV, tennv, diachi, sdt, gioitinh,status,wage,ngaysinh);
                    loadNV();
                }
            }
            void loadNV()
            {
                dataview.DataSource = StaffDAO.Instance.DSNV();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
