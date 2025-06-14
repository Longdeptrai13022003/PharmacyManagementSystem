using MedicalStoreManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalStoreManagementSystem.GUI
{
    public partial class EmployeeInfor : Form
    {
        public EmployeeInfor(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        }
        /*
        Khởi tạo có tham số để hiển thị thông tin nhân viên lên form
        */
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
                ChangeAccount(loginAccount.NhanvienID);
            }
        }
        void ChangeAccount(int id)
        {
            id = loginAccount.NhanvienID;
            tbxID.Text = id.ToString();
            tbxName.Text = DAO.Connection.GetFieldValue("vChiTietNhanVien", "HoTen", "NhanVienID", id).ToString();
            cbGioiTinh.Text = DAO.Connection.GetFieldValue("vChiTietNhanVien", "GioiTinh", "NhanVienID", id).ToString();
            dtpBirthday.Value = (DateTime)DAO.Connection.GetFieldValue("vChiTietNhanVien", "NgaySinh", "NhanVienID", id);
            tbxAddress.Text = DAO.Connection.GetFieldValue("vChiTietNhanVien", "DiaChi", "NhanVienID", id).ToString();
            tbxPhone.Text = DAO.Connection.GetFieldValue("vChiTietNhanVien", "Sdt", "NhanVienID", id).ToString();
            tbxEmail.Text = DAO.Connection.GetFieldValue("vChiTietNhanVien", "Email", "NhanVienID", id).ToString();
            tbxTrinhDo.Text = DAO.Connection.GetFieldValue("vChiTietNhanVien", "BangCap", "NhanVienID", id).ToString();
            dtpNgayVaoLam.Value = (DateTime)DAO.Connection.GetFieldValue("vChiTietNhanVien", "NgayVaoLam", "NhanVienID", id);
            tbxChucVu.Text = DAO.Connection.GetFieldValue("vChiTietNhanVien", "TenChucVu", "NhanVienID", id).ToString();
            tbxChuyenKhoa.Text = DAO.Connection.GetFieldValue("vChiTietNhanVien", "ChuyenNganh", "NhanVienID", id).ToString();
            byte[] imageData = DAO.Connection.GetImage("NhanVien", "Anh", "NhanVienID", id);

            if (imageData != null)
            {
                System.Drawing.Image image;
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    image = System.Drawing.Image.FromStream(ms);
                }

                // Đặt hình ảnh vào PictureBox
                pbImage.Image = image;
            }
            else
            {
                pbImage.Image = null;
            }
        }
        private void pbImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = openFileDialog.FileName;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Update thông tin nhân viên
            string que = "exec spSuaNhanVien @NhanVienID,@HoTen,@NgaySinh,@GioiTinh,@DiaChi,@Sdt,@Email,@TenChucVu,@NgayVaoLam,@BangCap,@ChuyenNganh,@Anh";
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            dic.Add("@NhanVienID", tbxID.Text);
            dic.Add("@HoTen", tbxName.Text);
            dic.Add("@NgaySinh", (DateTime)dtpBirthday.Value);
            dic.Add("@GioiTinh", cbGioiTinh.SelectedIndex);
            dic.Add("@DiaChi", tbxAddress.Text);
            dic.Add("@Sdt", tbxPhone.Text);
            dic.Add("@Email", tbxEmail.Text);
            dic.Add("@TenChucVu", tbxChucVu.Text);
            dic.Add("@NgayVaoLam", (DateTime)dtpNgayVaoLam.Value);
            dic.Add("@BangCap", tbxTrinhDo.Text);
            dic.Add("@ChuyenNganh", tbxChuyenKhoa.Text);
            dic.Add("@Anh", DAO.ImageConvert.ImageToByte(pbImage));
            DAO.Connection.Excute(que, dic);
            MessageBox.Show("Sửa thành công", "Thông báo");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
