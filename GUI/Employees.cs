using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalStoreManagementSystem.GUI
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }
        public void loadNhanVien()
        {
            dgvEmployees.DataSource = DAO.Connection.Query("select * from vChiTietNhanVien");
            cbNhanVien.DataSource = DAO.Connection.Query("select * from NhanVien");
        }
        public void loadChucVu()
        {
            dgvChucVu.DataSource = DAO.Connection.Query("select * from ChucVu");
            cbChucVu.DataSource = DAO.Connection.Query("select * from ChucVu");
        }
        public void loadTaiKhoan()
        {
            dgvAccounts.DataSource = DAO.Connection.Query("select * from vChiTietTaiKhoan");
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = openFileDialog.FileName;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.Rows.Count > 0)
            {
                dgvEmployees.MultiSelect = true;
                dgvEmployees.SelectAll();
                DataObject copydata = dgvEmployees.GetClipboardContent();
                if (copydata != null) Clipboard.SetDataObject(copydata);
                Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
                xlapp.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook xlWbook;
                Microsoft.Office.Interop.Excel.Worksheet xlsheet;
                object miseddata = System.Reflection.Missing.Value;
                xlWbook = xlapp.Workbooks.Add(miseddata);

                xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
                xlr.Select();

                xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                dgvEmployees.MultiSelect = false;
            }
            else
            {
                MessageBox.Show("Không có thông tin để export");
            }
        }
        void clearEm()
        {
            pbImage.Image = null;
            tbxIDNhanVIen.Clear();
            tbxTenNhanVien.Clear();
            tbxDiaChi.Clear();
            tbxEmail.Clear();
            tbxBangCap.Clear();
            tbxChuyenKhoa.Clear();
            tbxLuong.Clear();
            tbxPhone.Clear();
            tbxSearch.Clear();
            tbxTenNhanVien.Focus();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearEm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string que = "exec spThemNhanVien @HoTen,@NgaySinh,@GioiTinh,@DiaChi,@Sdt,@Email,@TenChucVu,@NgayVaoLam,@BangCap,@ChuyenNganh,@Anh";
            Dictionary<string,Object> dic = new Dictionary<string,Object>();
            dic.Add("@HoTen",tbxTenNhanVien.Text);
            dic.Add("@NgaySinh",(DateTime)dtpNgaySinh.Value);
            dic.Add("@GioiTinh",cbGioiTinh.SelectedIndex);
            dic.Add("@DiaChi",tbxDiaChi.Text);
            dic.Add("@Sdt",tbxPhone.Text);
            dic.Add("@Email",tbxEmail.Text);
            dic.Add("@TenChucVu",cbChucVu.Text);
            dic.Add("@NgayVaoLam",(DateTime)dtpVaoLam.Value);
            dic.Add("@BangCap",tbxBangCap.Text);
            dic.Add("@ChuyenNganh",tbxChuyenKhoa.Text);
            dic.Add("@Anh",DAO.ImageConvert.ImageToByte(pbImage));
            DAO.Connection.Excute(que,dic);
            loadNhanVien();
            MessageBox.Show("Thêm thành công", "Thông báo");
            clearEm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string que = "exec spSuaNhanVien @NhanVienID,@HoTen,@NgaySinh,@GioiTinh,@DiaChi,@Sdt,@Email,@TenChucVu,@NgayVaoLam,@BangCap,@ChuyenNganh,@Anh";
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            dic.Add("@NhanVienID",tbxIDNhanVIen.Text);
            dic.Add("@HoTen", tbxTenNhanVien.Text);
            dic.Add("@NgaySinh", (DateTime)dtpNgaySinh.Value);
            dic.Add("@GioiTinh", cbGioiTinh.SelectedIndex);
            dic.Add("@DiaChi", tbxDiaChi.Text);
            dic.Add("@Sdt", tbxPhone.Text);
            dic.Add("@Email", tbxEmail.Text);
            dic.Add("@TenChucVu", cbChucVu.Text);
            dic.Add("@NgayVaoLam", (DateTime)dtpVaoLam.Value);
            dic.Add("@BangCap", tbxBangCap.Text);
            dic.Add("@ChuyenNganh", tbxChuyenKhoa.Text);
            dic.Add("@Anh", DAO.ImageConvert.ImageToByte(pbImage));
            DAO.Connection.Excute(que, dic);
            loadNhanVien();
            MessageBox.Show("Sửa thành công", "Thông báo");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string que = "exec spXoaNhanVien @NhanVienID";
                Dictionary<string, Object> dic = new Dictionary<string, Object>();
                dic.Add("@NhanVienID", tbxIDNhanVIen.Text);
                DAO.Connection.Excute(que, dic);
                loadNhanVien();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
        }

        private void btnClearInfor_Click(object sender, EventArgs e)
        {
            tbxUsername.Clear();
            tbxPassword.Clear();
            tbxEmail.Clear();
            tbxSearchAccount.Clear();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string que = "exec spThemTaiKhoan @Username,@Password,@TenPhanQuyen,@HoTen,@Displayname";
            Dictionary<string,Object> dic= new Dictionary<string, Object>();
            dic.Add("@Username",tbxUsername.Text);
            dic.Add("@Password",tbxPassword.Text);
            dic.Add("@HoTen",cbNhanVien.Text);
            dic.Add("@TenPhanQuyen",cbPhanQuyen.Text);
            dic.Add("Displayname",tbxDisplayname.Text);
            DAO.Connection.Excute(que, dic);
            loadTaiKhoan();
            MessageBox.Show("Thêm tài khoản thành công");
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string que = "exec spSuaTaiKhoan @Username,@Password,@TenPhanQuyen,@HoTen,@Displayname";
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            dic.Add("@Username", tbxUsername.Text);
            dic.Add("@Password", tbxPassword.Text);
            dic.Add("@HoTen", cbNhanVien.Text);
            dic.Add("@TenPhanQuyen", cbPhanQuyen.Text);
            dic.Add("Displayname", tbxDisplayname.Text);
            DAO.Connection.Excute(que, dic);
            loadTaiKhoan();
            MessageBox.Show("Sửa tài khoản thành công");
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string que = "exec spXoaTaiKhoan @Username";
                Dictionary<string,Object> dic = new Dictionary<string, Object>();
                dic.Add("@Username", tbxUsername.Text);
                DAO.Connection.Excute(que, dic);
                loadTaiKhoan();
                MessageBox.Show("Xóa tài khoản thành công");
            }    
        }

        private void btnExportAccounts_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.Rows.Count > 0)
            {
                dgvAccounts.MultiSelect = true;
                dgvAccounts.SelectAll();
                DataObject copydata = dgvAccounts.GetClipboardContent();
                if (copydata != null) Clipboard.SetDataObject(copydata);
                Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
                xlapp.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook xlWbook;
                Microsoft.Office.Interop.Excel.Worksheet xlsheet;
                object miseddata = System.Reflection.Missing.Value;
                xlWbook = xlapp.Workbooks.Add(miseddata);

                xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
                xlr.Select();

                xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                dgvAccounts.MultiSelect = false;
            }
            else
            {
                MessageBox.Show("Không có thông tin để export");
            }
        }

        

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openf = new OpenFileDialog();
            openf.Title = "Chọn ảnh";
            openf.Filter = "Image Files(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
            if(openf.ShowDialog()==DialogResult.OK)
            {
                pbImage.ImageLocation = openf.FileName;
            }    
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employees_Load_1(object sender, EventArgs e)
        {
            loadNhanVien();
            loadChucVu();
            loadTaiKhoan();
            cbLoaiTim.SelectedIndex = 1;
            cbTimAcc.SelectedIndex = 0;
            cbPhanQuyen.DataSource = DAO.Connection.Query("select * from PhanQuyen");
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            DataGridViewImageColumn pict = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvEmployees.Columns[10];
            pict = (DataGridViewImageColumn)dgvAccounts.Columns[5];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            pict.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void dgvEmployees_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            tbxIDNhanVIen.Text = dgvEmployees.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxTenNhanVien.Text = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbGioiTinh.Text = dgvEmployees.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtpNgaySinh.Value = (DateTime)dgvEmployees.Rows[e.RowIndex].Cells[2].Value;
            dtpVaoLam.Value = (DateTime)dgvEmployees.Rows[e.RowIndex].Cells[8].Value;
            if (dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString() != "")
            {
                MemoryStream mem = new MemoryStream((byte[])dgvEmployees.Rows[e.RowIndex].Cells[10].Value);
                pbImage.Image = Image.FromStream(mem);
            }
            else
            {
                pbImage.Image = null;
            }
            cbChucVu.Text = dgvEmployees.Rows[e.RowIndex].Cells[7].Value.ToString();
            tbxDiaChi.Text = dgvEmployees.Rows[e.RowIndex].Cells[4].Value.ToString();
            tbxLuong.Text = dgvEmployees.Rows[e.RowIndex].Cells[11].Value.ToString();
            tbxEmail.Text = dgvEmployees.Rows[e.RowIndex].Cells[6].Value.ToString();
            tbxPhone.Text = dgvEmployees.Rows[e.RowIndex].Cells[5].Value.ToString();
            tbxBangCap.Text = dgvEmployees.Rows[e.RowIndex].Cells[9].Value.ToString();
            tbxChuyenKhoa.Text = dgvEmployees.Rows[e.RowIndex].Cells[12].Value.ToString();
        }

        private void tbxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbLoaiTim.Text == "Nhân viên ID")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\r')
                {
                    e.Handled= true;
                    MessageBox.Show("Vui lòng điền mã nhân viên ID là số");
                    return;
                }
                if(e.KeyChar == '\r')
                {
                    if (string.IsNullOrWhiteSpace(tbxSearch.Text))
                    {
                        loadNhanVien();
                        return;
                    }
                    string que = "select * from dbo.fTimNhanVien(" + tbxSearch.Text + ",null,null,null)";
                    dgvEmployees.DataSource = DAO.Connection.Query(que);
                    return;
                }
            }
            if (e.KeyChar == '\r')
            {
                if(string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    loadNhanVien();
                    return;
                }
                string que = null;
                if(cbLoaiTim.Text == "Họ tên")
                    que = "select * from dbo.fTimNhanVien(null,N'" + tbxSearch.Text + "',null,null)";
                if(cbLoaiTim.Text == "Địa chỉ")
                    que = "select * from dbo.fTimNhanVien(null,null,N'" + tbxSearch.Text + "',null)";    
                if(cbLoaiTim.Text == "Chức vụ")
                    que = "select * from dbo.fTimNhanVien(null,null,null,N'" + tbxSearch.Text + "')";
                dgvEmployees.DataSource = DAO.Connection.Query(que);
            }    
        }

        private void tbxTenNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                errLoi.SetError(tbxTenNhanVien, string.Empty);
                return;
            }
            else if(tbxTenNhanVien.Text.Length >= 50)
            {
                e.Handled = true;
                errLoi.SetError(tbxTenNhanVien, "Nhập tên dưới 50 ký tự");
                return;
            }    
            else if(!char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                errLoi.SetError(tbxTenNhanVien, "Vui lòng nhập tên chỉ chứa chữ");
                return;
            }
            else
                errLoi.SetError(tbxTenNhanVien,string.Empty);
        }

        private void tbxDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                errLoi.SetError(tbxDiaChi, string.Empty);
                return;
            }
            else if(tbxDiaChi.Text.Length >= 100)
            {
                e.Handled = true;
                errLoi.SetError(tbxDiaChi, "Nhập địa chỉ dưới 100 ký tự");
            } 
            else
                errLoi.SetError(tbxDiaChi,string.Empty);
        }

        private void tbxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                errLoi.SetError(tbxEmail, string.Empty);
                return;
            }
            else if (tbxEmail.Text.Length >= 50)
            {
                e.Handled = true;
                errLoi.SetError(tbxEmail, "Nhập Email dưới 50 ký tự");
            }
            else if(char.IsDigit(e.KeyChar) || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || 
                (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == '@' || e.KeyChar == '.' || e.KeyChar == '_')
                errLoi.SetError(tbxEmail, string.Empty);
            else
                errLoi.SetError(tbxEmail,"Chỉ nhập các ký tự Email");
        }

        private void tbxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                errLoi.SetError(tbxPhone, string.Empty);
                return;
            }
            else if (tbxPhone.Text.Length > 9)
            {
                e.Handled = true;
                errLoi.SetError(tbxPhone, "Nhập số điện thoại dưới 10 ký tự");
            }
            else if (char.IsDigit(e.KeyChar))
                errLoi.SetError(tbxPhone, string.Empty);
            else
                errLoi.SetError(tbxPhone, "Vui lòng nhập số điện thoại chỉ chứa chữ"); ;
        }

        private void tbxBangCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                errLoi.SetError(tbxBangCap, string.Empty);
                return;
            }
            else if (tbxBangCap.Text.Length >= 40)
            {
                e.Handled = true;
                errLoi.SetError(tbxBangCap, "Nhập bằng cấp dưới 40 ký tự");
            }
            else
                errLoi.SetError(tbxBangCap, string.Empty);
        }

        private void tbxChuyenKhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                errLoi.SetError(tbxChuyenKhoa, string.Empty);
                return;
            }
            else if (tbxChuyenKhoa.Text.Length >= 40)
            {
                e.Handled = true;
                errLoi.SetError(tbxChuyenKhoa, "Nhập chuyên ngành dưới 40 ký tự");
            }
            else
                errLoi.SetError(tbxChuyenKhoa, string.Empty);
        }

        private void dgvAccounts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAccounts.Rows[e.RowIndex].Cells[3].Value.ToString() != "")
            {
                MemoryStream mem = new MemoryStream((byte[])dgvAccounts.Rows[e.RowIndex].Cells[5].Value);
                pbAvatar.Image = Image.FromStream(mem);
            }
            else
            {
                pbAvatar.Image = null;
            }
            cbNhanVien.Text = dgvAccounts.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbxUsername.Text = dgvAccounts.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxPassword.Text = dgvAccounts.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbxDisplayname.Text = dgvAccounts.Rows[e.RowIndex].Cells[6].Value.ToString();
            cbPhanQuyen.Text = dgvAccounts.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void tbxSearchAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                if(string.IsNullOrWhiteSpace(tbxSearchAccount.Text))
                {
                    loadTaiKhoan();
                    return;
                }
                string que = "select * from dbo.fTimTaiKhoan(@Username,@HoTen,@Displayname)";
                Dictionary<string,Object> dic = new Dictionary<string,Object>();
                if (cbTimAcc.Text == "Username")
                    dic.Add("@Username", tbxSearchAccount.Text);
                else
                    dic.Add("@Username",DBNull.Value);
                if (cbTimAcc.Text == "Tên nhân viên")
                    dic.Add("@HoTen", tbxSearchAccount.Text);
                else
                    dic.Add("@HoTen", DBNull.Value);
                if (cbTimAcc.Text == "Displayname")
                    dic.Add("@Displayname", tbxSearchAccount.Text);
                else
                    dic.Add("@Displayname", DBNull.Value);
                dgvAccounts.DataSource = DAO.Connection.Query(que, dic);
            }    
        }

        private void tbxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                errLoi.SetError(tbxUsername, string.Empty);
                return;
            }
            else if (tbxUsername.Text.Length >= 30)
            {
                e.Handled = true;
                errLoi.SetError(tbxUsername, "Nhập Username dưới 30 ký tự");
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == '@' || e.KeyChar == '.' || e.KeyChar == '_')
                errLoi.SetError(tbxUsername, string.Empty);
            else
                errLoi.SetError(tbxUsername, "Chỉ nhập các ký tự không dấu");
        }

        private void tbxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                errLoi.SetError(tbxPassword, string.Empty);
                return;
            }
            else if (tbxPassword.Text.Length >= 30)
            {
                e.Handled = true;
                errLoi.SetError(tbxPassword, "Nhập Password dưới 30 ký tự");
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == '@' || e.KeyChar == '.' || e.KeyChar == '_')
                errLoi.SetError(tbxPassword, string.Empty);
            else
                errLoi.SetError(tbxPassword, "Chỉ nhập các ký tự không dấu");
        }

        private void tbxDisplayname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                errLoi.SetError(tbxDisplayname, string.Empty);
                return;
            }
            else if (tbxDisplayname.Text.Length >= 50)
            {
                e.Handled = true;
                errLoi.SetError(tbxDisplayname, "Nhập Displayname dưới 50 ký tự");
            }
            else
                errLoi.SetError(tbxDisplayname, string.Empty);
        }

        private void cbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte[] imageData = DAO.Connection.GetImage("NhanVien", "Anh", "NhanVienID", cbNhanVien.SelectedValue);

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
    }
}