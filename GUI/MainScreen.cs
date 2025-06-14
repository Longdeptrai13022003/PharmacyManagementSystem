using MedicalStoreManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalStoreManagementSystem.GUI
{
    public partial class MainScreen : Form
    {
        public MainScreen(Account acc)
        {
            InitializeComponent();
            container(new GUI.Home());
            showHello();
            this.LoginAccount = acc;
        }
        private Account loginAccount;

        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }
            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount.PhanquyenID);
            }
        }
        void ChangeAccount(int type)
        {
            type = loginAccount.PhanquyenID;
            if (type == 1)
            {
                btnEmployee.Visible = true;
                btnMedicines.Visible = true;
            }
            else
            {
                btnEmployee.Visible = false;
                btnMedicines.Visible = false;
            }
            lblName.Text = LoginAccount.Displayname.ToString();
            lblChucVu.Text = DAO.Connection.GetFieldValue("vChiTietNhanVien", "TenChucVu", "NhanVienID", loginAccount.NhanvienID).ToString();
            byte[] imageData = DAO.Connection.GetImage("NhanVien", "Anh", "NhanVienID", loginAccount.NhanvienID);

            if (imageData != null)
            {
                System.Drawing.Image image;
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    image = System.Drawing.Image.FromStream(ms);
                }

                // Đặt hình ảnh vào PictureBox
                pbAvatar.Image = image;
            }
            else
            {
                pbAvatar.Image = null;
            }
        }
        
        private void MainScreen_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            timer1.Start();
        }
        private void showHello()
        {
            if (DateTime.Now.Hour < 12)
            {
                lblTabName.Text = "Good morning";
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 19)
            {
                lblTabName.Text = "Good afternoon";
            }
            else
            {
                lblTabName.Text = "Good evening";
            }
        }
        private void container(object _form)
        {
            if (pnContainer.Controls.Count > 0)
            {
                pnContainer.Controls.Clear();
            }
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            pnContainer.Controls.Add(fm);
            pnContainer.Tag = fm;
            fm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            lblTabName.Text = "Dashboard";
            pbTab.Image = Properties.Resources.dashboard__2_;
            container(new GUI.Dashboard());
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            showHello();
            pbTab.Image = Properties.Resources.home;
            container(new GUI.Home());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }
        private Option form;
        private void pbAvatar_Click(object sender, EventArgs e)
        {
            if (form == null || form.IsDisposed)
            {
                // Nếu form chưa được mở hoặc đã bị đóng, tạo một instance mới
                form = new Option(loginAccount);
                form.Owner = this;
                form.Location = new Point(99,589);
                form.Show();
            }
            else
            {
                // Nếu form đã được mở, đóng nó
                form.Close();
            }
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            lblTabName.Text = "Store";
            pbTab.Image = Properties.Resources.shopping_cart__1_;
            container(new GUI.Store());
        }

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            lblTabName.Text = "Statistic";
            pbTab.Image = Properties.Resources.statistics__1_;
            container(new GUI.Statistic());
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            lblTabName.Text = "Help";
            pbTab.Image = Properties.Resources.question__1_;
            container(new GUI.Help());
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            lblTabName.Text = "Bills";
            pbTab.Image = Properties.Resources.invoice__1_;
            container(new GUI.BillManagement());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            lblTabName.Text = "Stock";
            pbTab.Image = Properties.Resources.product__1_;
            container(new GUI.Stock());
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            lblTabName.Text = "Employees";
            pbTab.Image = Properties.Resources.doctor__1_;
            container(new GUI.Employees());
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login form = new Login();
            form.Show();
        }

        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
