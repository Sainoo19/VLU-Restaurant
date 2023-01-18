using QLProject.DAO;
using QLProject.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLProject
{
    public partial class fManager : Form
    {
        public fManager()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }

        private void thongTinCaNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLogin f = new fLogin();
            this.Hide();
            f.ShowDialog();
        }
        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<TableDTO> listTable = TableDAO.Instance.GetTable();
            foreach (TableDTO item in listTable)
            {
                Button btn = new Button() { Width = 100, Height = 100 };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Tag = item;
                btn.Click += Btn_Click;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.White;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }
                flpTable.Controls.Add(btn);

            }
            flpTable.BackColor = Color.FromArgb(0, 0, 0, 0);
            panel4.BackColor = Color.FromArgb(0, 0, 0, 0);
        }
        void ShowMenu(int id)
        {
            lsvBill.Items.Clear();
             List<MenuDTO> listMenu = MenuDAO.Instance.GetMenu(id);
             float TotalPrice = 0;
             foreach (MenuDTO item in listMenu)
             {
                 ListViewItem Item = new ListViewItem(item.Name.ToString());
                 Item.SubItems.Add(item.Count.ToString());
                 Item.SubItems.Add(item.Price.ToString());
                 Item.SubItems.Add(item.TotalPrice.ToString());
                 TotalPrice += item.TotalPrice;
                 lsvBill.Items.Add(Item);
             }
             CultureInfo culture = new CultureInfo("vi-VN"); //doi ngon ngu va tien te tren may tinh
             txtbTotalPrice.Text = TotalPrice.ToString("c", culture);
           
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as TableDTO).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowMenu(tableID);
        }

        void LoadCategory()
        {
            List<FoodCategoryDTO> list = FoodCategoryDAO.Instance.GetCategory();
            cbFoodCategory.DataSource = list;
            cbFoodCategory.DisplayMember = "Name";
        }

        void LoadFoodIdCategory(int id)
        {
            List<FoodDTO> list = FoodDAO.Instance.GetFoodIdCategory(id);
            cbFood.DataSource = list;
            cbFood.DisplayMember = "Name";
        }

        private void cbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedItem == null)
            {
                return;
            }
            FoodCategoryDTO select = cb.SelectedItem as FoodCategoryDTO;
            id = select.Id;
            LoadFoodIdCategory(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            TableDTO table = lsvBill.Tag as TableDTO;
            int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
            int idFood = (cbFood.SelectedItem as FoodDTO).Id;
            int amount = (int)nmAmount.Value;
            if(idBill == -1) // Neu ban chua co nguoi thi thuc hien cau lenh INSERT ben duoi
            {
                BillDAO.Instance.InsertBill(table.ID); // them Bill
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxID(), idFood, amount); // them Food
                TableDAO.Instance.CheckInStatus(table.ID); //UPDATE thanh trang thai co nguoi o TableDAO
            }
            else // ban chua co nguoi
            {
                if (BillInfoDAO.Instance.CheckidFoodCount(idBill, idFood) > 0) // mon an da co roi, chi UPDATE lai 
                {
                    BillInfoDAO.Instance.UpdateCount(idBill, idFood, amount);
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, amount);
                }
            }
            ShowMenu(table.ID);
            LoadTable();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TableDTO table = lsvBill.Tag as TableDTO;
            int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
            //int idTable = BillDAO.Instance.GetUncheckBill(table.);
            if (idBill != -1)
            {
                if (MessageBox.Show("Bạn muốn thanh toán bàn thiệt hem " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    TableDAO.Instance.CheckOutStatus(table.ID);
                    BillDAO.Instance.CheckOut(idBill);
                    ShowMenu(idBill);

                }
                //ShowBill(idBill);
                LoadTable();
            }



        
    }

        private void fManager_Load(object sender, EventArgs e)
        {

        }

        private void cbFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbChangeTable_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
