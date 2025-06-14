using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalStoreManagementSystem.GUI
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }
        private bool formloaded = false;
        public void loadThuoc()
        {
            dgvThuoc.DataSource = DAO.Connection.Query("select * from vChiTietThuoc");
            dgvMedicines.DataSource = DAO.Connection.Query("select ThuocID,Anh,TenThuoc,TenLoaiThuoc,TenKho from vChiTietThuoc");
            dgvStock.DataSource = DAO.Connection.Query("select * from vChiTietHanDung");
        }
        public void loadLoaiThuoc()
        {
            cbLoaiThuoc.DataSource = DAO.Connection.Query("select * from LoaiThuoc");
        }  
        public void loadDonViTinh()
        {
            cbDonViTinh.DataSource = DAO.Connection.Query("select * from DonViTinh");
        }
        public void loadChongChiDinh()
        {
            cbChongChiDinh.DataSource = DAO.Connection.Query("select * from ChongChiDinh");
        }
        public void loadKho()
        {
            cbKho.DataSource = DAO.Connection.Query("select KhoID,TenKho from Kho");
        }
        private void btnSearchNgayNhap_Click(object sender, EventArgs e)
        {
            //Tìm kiếm theo ngày nhập
            //Chọn khoảng ngày cần xét
            string que = "Select * from fTimThuocNgayNhap('" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "', '" + dtpToDate.Value.ToString("yyyy-MM-dd") + "')";
            dgvStock.DataSource = DAO.Connection.Query(que);
        }

        private void btnSearchHetHan_Click(object sender, EventArgs e)
        {
            //Lấy ra thuốc đã hết hạn truyền vào datagridview
            string que = "select * from vChiTietHanDung where NgayHetHan<GETDATE()";
            dgvStock.DataSource = DAO.Connection.Query(que);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvStock.Rows.Count > 0)
            {
                dgvStock.MultiSelect = true;
                dgvStock.SelectAll();
                DataObject copydata = dgvStock.GetClipboardContent();
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
                dgvStock.MultiSelect = false;
            }
            else
            {
                MessageBox.Show("Không có thông tin để export");
            }
        }

        //Sự kiện load form
        private void Stock_Load(object sender, EventArgs e)
        {
            formloaded = true;
            loadThuoc();
            loadLoaiThuoc();
            loadDonViTinh();
            loadChongChiDinh();
            loadKho();
            cbLoaiTim.SelectedIndex = 1;
            cbKieuTim.SelectedIndex = 0;
            cbTimNhap.SelectedIndex = 1;

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            DataGridViewImageColumn pict = new DataGridViewImageColumn();
            DataGridViewImageColumn pictu = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvThuoc.Columns[1];
            pict = (DataGridViewImageColumn)dgvMedicines.Columns[1];
            pictu = (DataGridViewImageColumn)dgvStock.Columns[1];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            pict.ImageLayout = DataGridViewImageCellLayout.Zoom;
            pictu.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openf = new OpenFileDialog();
            openf.Title = "Chọn ảnh";
            openf.Filter = "Image Files(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = openf.FileName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string que = "exec spThemThuoc @TenThuoc,@LoaiThuocID,@DonViTinhID,@ChongChiDinhID,@CongDung,@GiaNhap,@GiaBan,@ThanhPhan,@KhoID,@Anh";
            Dictionary<string,Object> dic = new Dictionary<string,Object>();
            dic.Add("@TenThuoc", tbxTenThuoc.Text);
            dic.Add("@LoaiThuocID",(int)cbLoaiThuoc.SelectedValue);
            dic.Add("@DonViTinhID",(int)cbDonViTinh.SelectedValue);
            dic.Add("@ChongChiDinhID",(int)cbChongChiDinh.SelectedValue);
            dic.Add("@CongDung",tbxCongDung.Text);
            dic.Add("@GiaNhap",(int)nudGiaNhap.Value);
            dic.Add("@GiaBan",(int)nudGiaBan.Value);
            dic.Add("@ThanhPhan",tbxThanhPhan.Text);
            dic.Add("@KhoID",(int)cbKho.SelectedValue);
            dic.Add("@Anh",DAO.ImageConvert.ImageToByte(pbImage));
            DAO.Connection.Excute(que, dic);
            loadThuoc();
            MessageBox.Show("Thêm thành công");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxThuocID.Clear();
            tbxTenThuoc.Clear();
            tbxThanhPhan.Clear();
            tbxCongDung.Clear();
            tbxTimThuoc.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string que = "exec spSuaThuoc @ThuocID,@TenThuoc,@LoaiThuocID,@DonViTinhID,@ChongChiDinhID,@CongDung,@GiaNhap,@GiaBan,@ThanhPhan,@KhoID,@Anh";
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            dic.Add("@ThuocID", tbxThuocID.Text);
            dic.Add("@TenThuoc", tbxTenThuoc.Text);
            dic.Add("@LoaiThuocID", (int)cbLoaiThuoc.SelectedValue);
            dic.Add("@DonViTinhID", (int)cbDonViTinh.SelectedValue);
            dic.Add("@ChongChiDinhID", (int)cbChongChiDinh.SelectedValue);
            dic.Add("@CongDung", tbxCongDung.Text);
            dic.Add("@GiaNhap", (int)nudGiaNhap.Value);
            dic.Add("@GiaBan", (int)nudGiaBan.Value);
            dic.Add("@ThanhPhan", tbxThanhPhan.Text);
            dic.Add("@KhoID", (int)cbKho.SelectedValue);
            dic.Add("@Anh", DAO.ImageConvert.ImageToByte(pbImage));
            DAO.Connection.Excute(que, dic);
            loadThuoc();
            MessageBox.Show("Sửa thành công");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string que = "exec spXoaThuoc "+tbxThuocID.Text;
            DAO.Connection.Excute(que);
            loadThuoc();
            MessageBox.Show("Xóa thành công");
        }

        private void dgvThuoc_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            tbxThuocID.Text = dgvThuoc.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxTenThuoc.Text = dgvThuoc.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbLoaiThuoc.Text = dgvThuoc.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbDonViTinh.Text = dgvThuoc.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbChongChiDinh.Text = dgvThuoc.Rows[e.RowIndex].Cells[5].Value.ToString();
            cbKho.Text = dgvThuoc.Rows[e.RowIndex].Cells[10].Value.ToString();
            tbxCongDung.Text = dgvThuoc.Rows[e.RowIndex].Cells[6].Value.ToString();
            tbxThanhPhan.Text = dgvThuoc.Rows[e.RowIndex].Cells[9].Value.ToString();
            nudGiaBan.Value = (int)dgvThuoc.Rows[e.RowIndex].Cells[8].Value;
            nudGiaNhap.Value = (int)dgvThuoc.Rows[e.RowIndex].Cells[7].Value;
            if (dgvThuoc.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                MemoryStream mem = new MemoryStream((byte[])dgvThuoc.Rows[e.RowIndex].Cells[1].Value);
                pbImage.Image = Image.FromStream(mem);
            }
            else
            {
                pbImage.Image = null;
            }
        }
        private void dgvMedicines_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvImportInfor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvImportInfor.Columns["colXoa"].Index && e.RowIndex != -1)
            {
                dgvImportInfor.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dgvMedicines_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2Panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEcellThuoc_Click(object sender, EventArgs e)
        {
            dgvThuoc.MultiSelect = true;
            //export
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxAdress.Text) && !string.IsNullOrWhiteSpace(tbxTenNCC.Text) && !string.IsNullOrWhiteSpace(tbxPhone.Text) && dgvImportInfor.Rows.Count > 0)
            {
                string que = "exec spNhapThuoc @TenNhaCungCap,@DiaChi,@Sdt,@NgayNhap,@NhapThuocID output";
                int NhapThuocID = 0;
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                new SqlParameter("@TenNhaCungCap", tbxTenNCC.Text),
                new SqlParameter("@DiaChi", tbxAdress.Text),
                new SqlParameter("@Sdt", tbxPhone.Text),
                new SqlParameter("@NgayNhap", DateTime.Now),
                };
                SqlParameter nhapThuocIDParameter = new SqlParameter("@NhapThuocID", SqlDbType.Int);
                nhapThuocIDParameter.Direction = ParameterDirection.Output;
                parameters.Add(nhapThuocIDParameter);

                DAO.Connection.ExcutePara(que, parameters);

                NhapThuocID = Convert.ToInt32(nhapThuocIDParameter.Value);

                foreach (DataGridViewRow row in dgvImportInfor.Rows)
                {
                    Dictionary<string, Object> dic = new Dictionary<string, Object>();
                    int ThuocID = Int32.Parse(row.Cells[0].Value.ToString());
                    int SoLuong = Int32.Parse(row.Cells["colSoLuong"].Value.ToString());
                    string date = row.Cells["colHanDung"].Value.ToString();
                    DateTime HanDung = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    que = "exec spThemHanDung @NhapThuocID, @ThuocID,@NgayHetHan, @SoLuong";
                    dic = new Dictionary<string, Object>();
                    dic.Add("@NhapThuocID", NhapThuocID);
                    dic.Add("@ThuocID", ThuocID);
                    dic.Add("@NgayHetHan", HanDung);
                    dic.Add("@SoLuong", SoLuong);
                    DAO.Connection.Excute(que, dic);
                }
                dgvStock.DataSource = DAO.Connection.Query("select * from vChiTietHanDung");
                MessageBox.Show("Thêm thành công");
            }
            else
                MessageBox.Show("Vui lòng nhập đủ dữ liệu");
        }
        //Kiểm tra định dạng số lượng và hạn dùng trong dgvImportInfor
        private bool IsValidDateFormat(string input)
        {
            DateTime parsedDate;
            return DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
        }
        private bool IsValidPositiveInteger(string input)
        {
            int parsedValue;
            return int.TryParse(input, out parsedValue) && parsedValue > 0;
        }
        private void dgvImportInfor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvImportInfor.Columns["colHanDung"].Index)
            {
                DataGridViewCell cell = dgvImportInfor.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Kiểm tra định dạng ngày
                if (!IsValidDateFormat(cell.Value.ToString()))
                {
                    // Nếu không đúng định dạng, đặt lại giá trị mặc định và hiển thị thông báo
                    cell.Value = "01/01/2024";
                    MessageBox.Show("Định dạng ngày tháng phải là 'dd/MM/yyyy'");
                }
            }
            if (e.ColumnIndex == dgvImportInfor.Columns["colSoLuong"].Index)
            {
                DataGridViewCell cell = dgvImportInfor.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Kiểm tra định dạng số nguyên dương
                if (!IsValidPositiveInteger(cell.Value.ToString()))
                {
                    // Nếu không đúng định dạng, đặt lại giá trị mặc định và hiển thị thông báo
                    cell.Value = 1;
                    MessageBox.Show("Vui lòng nhập số lượng là số nguyên dương!");
                }
            }
        }

        private void dgvMedicines_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
        }

        private void dgvMedicines_DoubleClick(object sender, EventArgs e)
        {
            if (formloaded && dgvMedicines.SelectedRows.Count > 0)
            {
                string ThuocID = dgvMedicines.SelectedRows[0].Cells[0].Value.ToString();
                string TenThuoc = dgvMedicines.SelectedRows[0].Cells[2].Value.ToString();
                string Kho = dgvMedicines.SelectedRows[0].Cells[4].Value.ToString();
                Object[] rowData = { ThuocID, TenThuoc, Kho, "1", "01/01/2024" };
                dgvImportInfor.Rows.Add(rowData);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dgvStock.DataSource = DAO.Connection.Query("select * from vChiTietHanDung");
        }

        private void tbxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            string que;
            if (string.IsNullOrWhiteSpace(tbxSearch.Text) && e.KeyChar == '\r')
            {
                eLoi.SetError(tbxSearch, string.Empty);
                dgvStock.DataSource = DAO.Connection.Query("select * from vChiTietHanDung");
                return;
            }
            if (e.KeyChar == '\b')
            {
                eLoi.SetError(tbxSearch, string.Empty);
                return;
            }
            if (cbLoaiTim.Text == "ID thuốc")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\r')
                {
                    e.Handled = true;
                    eLoi.SetError(tbxSearch, "Vui lòng điền ID thuốc là số nguyên");
                    return;
                }
                if (e.KeyChar == '\r')
                {
                    que = "select * from dbo.fTimThuoc(" + tbxSearch.Text + ",null,null,null,null)";
                    dgvStock.DataSource = DAO.Connection.Query(que);
                    return;
                }
                return;
            }
            que = "select* from dbo.fTimThuoc(null,@TenThuoc,@TenLoaiThuoc,@CongDung,@TenKho)";
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\r')
            {
                e.Handled = true;
                eLoi.SetError(tbxSearch, "Vui lòng chỉ nhập chữ");
                return;
            }
            if (tbxSearch.Text.Length >= 50 && cbLoaiTim.Text == "Tên thuốc")
            {
                e.Handled = true;
                eLoi.SetError(tbxSearch, "Vui lòng nhập tên thuốc không vượt quá 50 ký tự");
                return;
            }
            if (tbxSearch.Text.Length >= 30 && cbLoaiTim.Text == "Loại thuốc")
            {
                e.Handled = true;
                eLoi.SetError(tbxSearch, "Vui lòng nhập loại thuốc không vượt quá 30 ký tự");
                return;
            }
            if (tbxSearch.Text.Length >= 100 && cbLoaiTim.Text == "Công dụng")
            {
                e.Handled = true;
                eLoi.SetError(tbxSearch, "Vui lòng nhập công dụng không vượt quá 100 ký tự");
                return;
            }
            if (tbxSearch.Text.Length >= 20 && cbLoaiTim.Text == "Kho")
            {
                e.Handled = true;
                eLoi.SetError(tbxSearch, "Vui lòng nhập kho không vượt quá 20 ký tự");
                return;
            }
            eLoi.SetError(tbxSearch, string.Empty);
            if (e.KeyChar == '\r')
            {
                if (cbLoaiTim.Text == "Tên thuốc")
                    dic.Add("@TenThuoc", tbxSearch.Text);
                else
                    dic.Add("@TenThuoc", DBNull.Value);
                if (cbLoaiTim.Text == "Loại thuốc")
                    dic.Add("@TenLoaiThuoc", tbxSearch.Text);
                else
                    dic.Add("TenLoaiThuoc", DBNull.Value);
                if (cbLoaiTim.Text == "Công dụng")
                    dic.Add("@CongDung", tbxSearch.Text);
                else
                    dic.Add("@CongDung", DBNull.Value);
                if (cbLoaiTim.Text == "Kho")
                    dic.Add("@TenKho", tbxSearch.Text);
                else
                    dic.Add("@TenKho", DBNull.Value);
                dgvStock.DataSource = DAO.Connection.Query(que, dic);
            }
        }

        private void tbxTimThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxTimThuoc.Text) && e.KeyChar == '\r')
            {
                eLoi.SetError(tbxTimThuoc, string.Empty);
                dgvThuoc.DataSource = DAO.Connection.Query("select * from vChiTietThuoc");
                return;
            }
            if (e.KeyChar == '\b')
            {
                eLoi.SetError(tbxTimThuoc, string.Empty);
                return;
            }
            if(char.IsDigit(e.KeyChar))
            {
                if(cbKieuTim.Text=="Đơn vị tính" && tbxTimThuoc.Text.Length>=20)
                {
                    e.Handled= true;
                    eLoi.SetError(tbxTimThuoc, "Nhập đơn vị tính tối đa 20 ký tự");
                    return;
                } 
                if(cbKieuTim.Text=="Thành phần" && tbxTimThuoc.Text.Length>=200)
                {
                    e.Handled = true;
                    eLoi.SetError(tbxTimThuoc, "Nhập thành phần tối đa 200 ký tự");
                    return;
                }
                if(cbKieuTim.Text != "Đơn vị tính" && cbKieuTim.Text!="Thành phần")
                {
                    e.Handled= true;
                    eLoi.SetError(tbxTimThuoc, "Vui lòng chỉ nhập chữ");
                    return;
                }    
                eLoi.SetError(tbxTimThuoc,string.Empty);
                return;
            }
            string que = "select* from dbo.fTimChiTietThuoc(@TenThuoc,@TenLoaiThuoc,@CongDung,@TenChongChiDinh,@TenDonViTinh,@ThanhPhan,@TenKho)";
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\r')
            {
                e.Handled = true;
                eLoi.SetError(tbxTimThuoc, "Vui lòng chỉ nhập chữ");
                return;
            }
            if (tbxTimThuoc.Text.Length >= 50 && cbKieuTim.Text == "Tên thuốc")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimThuoc, "Vui lòng nhập tên thuốc không vượt quá 50 ký tự");
                return;
            }
            if (tbxTimThuoc.Text.Length >= 30 && cbKieuTim.Text == "Loại thuốc")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimThuoc, "Vui lòng nhập loại thuốc không vượt quá 30 ký tự");
                return;
            }
            if (tbxTimThuoc.Text.Length >= 100 && cbKieuTim.Text == "Công dụng")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimThuoc, "Vui lòng nhập công dụng không vượt quá 100 ký tự");
                return;
            }
            if (tbxTimThuoc.Text.Length >= 20 && cbKieuTim.Text == "Kho")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimThuoc, "Vui lòng nhập kho không vượt quá 20 ký tự");
                return;
            }
            if (tbxTimThuoc.Text.Length >= 50 && cbKieuTim.Text == "Chống chỉ định")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimThuoc, "Vui lòng nhập chống chỉ định không vượt quá 50 ký tự");
                return;
            }
            if (tbxTimThuoc.Text.Length >= 20 && cbKieuTim.Text == "Đơn vị tính")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimThuoc, "Vui lòng nhập đơn vị tính không vượt quá 20 ký tự");
                return;
            }
            if (tbxTimThuoc.Text.Length >= 200 && cbKieuTim.Text == "Thành phần")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimThuoc, "Vui lòng nhập thành phần không vượt quá 200 ký tự");
                return;
            }
            eLoi.SetError(tbxTimThuoc, string.Empty);
            if (e.KeyChar == '\r')
            {
                if (cbKieuTim.Text == "Tên thuốc")
                    dic.Add("@TenThuoc", tbxTimThuoc.Text);
                else
                    dic.Add("@TenThuoc", DBNull.Value);
                if (cbKieuTim.Text == "Loại thuốc")
                    dic.Add("@TenLoaiThuoc", tbxTimThuoc.Text);
                else
                    dic.Add("TenLoaiThuoc", DBNull.Value);
                if (cbKieuTim.Text == "Công dụng")
                    dic.Add("@CongDung", tbxTimThuoc.Text);
                else
                    dic.Add("@CongDung", DBNull.Value);
                if (cbKieuTim.Text == "Đơn vị tính")
                    dic.Add("@TenDonViTinh", tbxTimThuoc.Text);
                else
                    dic.Add("@TenDonViTinh", DBNull.Value);
                if (cbKieuTim.Text == "Chống chỉ định")
                    dic.Add("@TenChongChiDinh", tbxTimThuoc.Text);
                else
                    dic.Add("@TenChongChiDinh", DBNull.Value);
                if (cbKieuTim.Text == "Thành phần")
                    dic.Add("@ThanhPhan", tbxTimThuoc.Text);
                else
                    dic.Add("@ThanhPhan", DBNull.Value);
                if (cbKieuTim.Text == "Kho")
                    dic.Add("@TenKho", tbxTimThuoc.Text);
                else
                    dic.Add("@TenKho", DBNull.Value);
                dgvThuoc.DataSource = DAO.Connection.Query(que, dic);
            }
        }

        private void tbxTimNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxTimNhap.Text) && e.KeyChar == '\r')
            {
                eLoi.SetError(tbxTimNhap, string.Empty);
                dgvMedicines.DataSource = DAO.Connection.Query("select ThuocID,Anh,TenThuoc,TenLoaiThuoc,TenKho from vChiTietThuoc");
                return;
            }
            if (e.KeyChar == '\b')
            {
                eLoi.SetError(tbxTimNhap, string.Empty);
                return;
            }
            if (char.IsDigit(e.KeyChar))
            {
                if (cbTimNhap.Text == "Đơn vị tính" && tbxTimNhap.Text.Length >= 20)
                {
                    e.Handled = true;
                    eLoi.SetError(tbxTimNhap, "Nhập đơn vị tính tối đa 20 ký tự");
                    return;
                }
                if (cbTimNhap.Text == "Thành phần" && tbxTimNhap.Text.Length >= 200)
                {
                    e.Handled = true;
                    eLoi.SetError(tbxTimNhap, "Nhập thành phần tối đa 200 ký tự");
                    return;
                }
                if (cbTimNhap.Text != "Đơn vị tính" && cbTimNhap.Text != "Thành phần")
                {
                    e.Handled = true;
                    eLoi.SetError(tbxTimNhap, "Vui lòng chỉ nhập chữ");
                    return;
                }
                eLoi.SetError(tbxTimNhap, string.Empty);
                return;
            }
            string que = "select ThuocID,Anh,TenThuoc,TenLoaiThuoc,TenKho from dbo.fTimChiTietThuoc(@TenThuoc,@TenLoaiThuoc,@CongDung,@TenChongChiDinh,@TenDonViTinh,@ThanhPhan,@TenKho)";
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\r')
            {
                e.Handled = true;
                eLoi.SetError(tbxTimNhap, "Vui lòng chỉ nhập chữ");
                return;
            }
            if (tbxTimNhap.Text.Length >= 50 && cbTimNhap.Text == "Tên thuốc")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimNhap, "Vui lòng nhập tên thuốc không vượt quá 50 ký tự");
                return;
            }
            if (tbxTimNhap.Text.Length >= 30 && cbTimNhap.Text == "Loại thuốc")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimNhap, "Vui lòng nhập loại thuốc không vượt quá 30 ký tự");
                return;
            }
            if (tbxTimNhap.Text.Length >= 100 && cbTimNhap.Text == "Công dụng")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimNhap, "Vui lòng nhập công dụng không vượt quá 100 ký tự");
                return;
            }
            if (tbxTimNhap.Text.Length >= 20 && cbTimNhap.Text == "Kho")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimNhap, "Vui lòng nhập kho không vượt quá 20 ký tự");
                return;
            }
            if (tbxTimNhap.Text.Length >= 50 && cbTimNhap.Text == "Chống chỉ định")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimNhap, "Vui lòng nhập chống chỉ định không vượt quá 50 ký tự");
                return;
            }
            if (tbxTimNhap.Text.Length >= 20 && cbTimNhap.Text == "Đơn vị tính")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimNhap, "Vui lòng nhập đơn vị tính không vượt quá 20 ký tự");
                return;
            }
            if (tbxTimNhap.Text.Length >= 200 && cbTimNhap.Text == "Thành phần")
            {
                e.Handled = true;
                eLoi.SetError(tbxTimNhap, "Vui lòng nhập thành phần không vượt quá 200 ký tự");
                return;
            }
            eLoi.SetError(tbxTimNhap, string.Empty);
            if (e.KeyChar == '\r')
            {
                if (cbTimNhap.Text == "Tên thuốc")
                    dic.Add("@TenThuoc", tbxTimNhap.Text);
                else
                    dic.Add("@TenThuoc", DBNull.Value);
                if (cbTimNhap.Text == "Loại thuốc")
                    dic.Add("@TenLoaiThuoc", tbxTimNhap.Text);
                else
                    dic.Add("TenLoaiThuoc", DBNull.Value);
                if (cbTimNhap.Text == "Công dụng")
                    dic.Add("@CongDung", tbxTimNhap.Text);
                else
                    dic.Add("@CongDung", DBNull.Value);
                if (cbTimNhap.Text == "Đơn vị tính")
                    dic.Add("@TenDonViTinh", tbxTimNhap.Text);
                else
                    dic.Add("@TenDonViTinh", DBNull.Value);
                if (cbTimNhap.Text == "Chống chỉ định")
                    dic.Add("@TenChongChiDinh", tbxTimNhap.Text);
                else
                    dic.Add("@TenChongChiDinh", DBNull.Value);
                if (cbTimNhap.Text == "Thành phần")
                    dic.Add("@ThanhPhan", tbxTimNhap.Text);
                else
                    dic.Add("@ThanhPhan", DBNull.Value);
                if (cbTimNhap.Text == "Kho")
                    dic.Add("@TenKho", tbxTimNhap.Text);
                else
                    dic.Add("@TenKho", DBNull.Value);
                dgvMedicines.DataSource = DAO.Connection.Query(que, dic);
            }
        }
    }
}
