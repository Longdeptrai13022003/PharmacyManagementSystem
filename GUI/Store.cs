using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalStoreManagementSystem.GUI
{
    public partial class Store : Form
    {
        public Store()
        {
            InitializeComponent();
        }
        private int HoaDonID = 0;
        private double index = 0;
        private int TongTien = 0;
        private bool formloaded = false;
        private Dictionary<string,int> thuoc = new Dictionary<string,int>();
        private Dictionary<string,int> chon = new Dictionary<string, int>();
        public void loadThuoc()
        {
            dgvMedicines.DataSource = DAO.Connection.Query("select ThuocID,Anh,TenThuoc,CongDung,SoLuong,NgayHetHan,GiaBan from vChiTietHanDung");
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            thuoc.Clear();
            chon.Clear();
            HoaDonID = 0;
            tbxCustomerName.Clear();
            tbxPhone.Clear();
            dgvBillInfor.Rows.Clear();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxCustomerName.Text) && !string.IsNullOrWhiteSpace(tbxPhone.Text) && dgvBillInfor.Rows.Count>0)
            {
                string Loi = "Thuoc ";
                foreach (DataGridViewRow row in dgvBillInfor.Rows)
                {
                    string Ten = row.Cells["colTen"].Value.ToString();
                    int Gia = Int32.Parse(row.Cells[4].Value.ToString());
                    int ThuocID = Int32.Parse(row.Cells[0].Value.ToString());
                    int SoLuong = Int32.Parse(row.Cells[3].Value.ToString());
                    string date = row.Cells["colHDung"].Value.ToString();
                    DateTime HanDung = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string str = ThuocID.ToString() + HanDung.ToString("dd/MM/yyyy");
                    chon.Add(str, SoLuong);
                    if (thuoc[str] < chon[str])
                        Loi += ThuocID.ToString() + ", ";
                }
                foreach(string key in thuoc.Keys)
                    if (thuoc[key] < chon[key])
                    {
                        MessageBox.Show(Loi+" vượt quá số lượng tồn kho");
                        thuoc.Clear();
                        chon.Clear();
                        dgvBillInfor.Rows.Clear();
                        return;
                    }
                string TenKH = tbxCustomerName.Text;
                string Sdt = tbxPhone.Text;
                int HinhThucID = (int)cbHinhThucTT.SelectedValue;
                DateTime NgayTao = DateTime.Now;

                // Tạo danh sách tham số SqlParameter
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                new SqlParameter("@TenKhachHang", TenKH),
                new SqlParameter("@Sdt", Sdt),
                new SqlParameter("@NgayTao", NgayTao),
                new SqlParameter("@HinhThucThanhToanID", HinhThucID),
                };

                // Thêm tham số đầu ra vào danh sách
                SqlParameter hoaDonIDParameter = new SqlParameter("@HoaDonID", SqlDbType.Int);
                hoaDonIDParameter.Direction = ParameterDirection.Output;
                parameters.Add(hoaDonIDParameter);

                // Gọi hàm ExcutePara với danh sách tham số mới
                DAO.Connection.ExcutePara("exec spThemHoaDon @TenKhachHang,@Sdt,@Ngaytao,@HinhThucThanhToanID,@HoaDonID output", parameters);

                // Lấy giá trị HoaDonID từ tham số đầu ra
                HoaDonID = Convert.ToInt32(hoaDonIDParameter.Value);
                List<DTO.Receipt> list = new List<DTO.Receipt>();
                foreach (DataGridViewRow row in dgvBillInfor.Rows)
                {
                    string Ten = row.Cells["colTen"].Value.ToString();
                    int Gia = Int32.Parse(row.Cells[4].Value.ToString());
                    int ThuocID = Int32.Parse(row.Cells[0].Value.ToString());
                    int SoLuong = Int32.Parse(row.Cells[3].Value.ToString());
                    string date = row.Cells["colHDung"].Value.ToString();
                    DateTime HanDung = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string que = "exec spChiTietSoLuong @HoaDonID,@ThuocID,@SoLuong,@NgayHetHan";
                    Dictionary<string, Object> dic = new Dictionary<string, Object>();
                    dic.Add("@HoaDonID", HoaDonID);
                    dic.Add("@ThuocID", ThuocID);
                    dic.Add("@SoLuong", SoLuong);
                    dic.Add("@NgayHetHan", HanDung);
                    DAO.Connection.Excute(que, dic);
                    DTO.Receipt receipt = new DTO.Receipt() { TenThuoc = Ten, HanDung = HanDung.ToString("dd/MM/yyyy"), SoLuong = SoLuong, Gia = Gia };
                    list.Add(receipt);
                }
                string HinhThuc = cbHinhThucTT.Text;
                string KhuyenMai = cbHeSoKM.Text;
                index = (100 - (double)(cbHeSoKM.SelectedIndex * 5)) / 100;
                double price = (double)index * (double)TongTien;
                string totalPrice = price.ToString() + " VNĐ";
                formPrint f = new formPrint(list, TenKH, Sdt, totalPrice, DateTime.Now.ToString("dd/MM/yyyy"),HinhThuc,KhuyenMai);
                f.ShowDialog();
                TongTien = 0;
                loadThuoc();
                MessageBox.Show("Tạo hóa đơn thành công");
            }
            else
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi tạo hóa đơn!");
        }
        //Kiểm tra định dạng số lượng người dùng nhập
        private bool IsValidPositiveInteger(string input)
        {
            int parsedValue;
            return int.TryParse(input, out parsedValue) && parsedValue > 0;
        }

        private void tbxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar!=' ')
            {
                e.Handled = true;
            }
        }

        private void dgvMedicines_DoubleClick(object sender, EventArgs e)
        {
            if (formloaded && dgvMedicines.SelectedRows.Count > 0)
            {
                int ThuocID = (int)dgvMedicines.SelectedRows[0].Cells[0].Value;
                string TenThuoc = dgvMedicines.SelectedRows[0].Cells[2].Value.ToString();
                DateTime HanDung = (DateTime)dgvMedicines.SelectedRows[0].Cells[5].Value;
                int Gia = (int)dgvMedicines.SelectedRows[0].Cells[6].Value;
                int TonKho = (int)dgvMedicines.SelectedRows[0].Cells["colTonKho"].Value;
                foreach (string key in thuoc.Keys)
                {
                    if ((ThuocID.ToString() + HanDung.ToString("dd/MM/yyyy")) == key)
                    {
                        MessageBox.Show("Thuốc đã chọn!");
                        return;
                    }
                }
                thuoc.Add(ThuocID.ToString() + HanDung.ToString("dd/MM/yyyy"), TonKho);
                Object[] rowData = { ThuocID, TenThuoc, HanDung.ToString("dd/MM/yyyy"), "1", Gia };
                dgvBillInfor.Rows.Add(rowData);
                TongTien += Gia;
                updatePrice();
            }
        }

        private void Store_Load(object sender, EventArgs e)
        {
            formloaded = true;
            loadThuoc();
            cbHeSoKM.SelectedIndex = 0;
            cbLoaiTim.SelectedIndex = 1;
            cbHinhThucTT.DataSource = DAO.Connection.Query("select * from HinhThucThanhToan");
            DataGridViewImageColumn pict = new DataGridViewImageColumn();
            pict = (DataGridViewImageColumn)dgvMedicines.Columns[1];
            pict.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        public void updatePrice()
        {
            index = (100 - (double)(cbHeSoKM.SelectedIndex * 5)) / 100;
            double price = (double)index * (double)TongTien;
            tbxTotalPrice.Text = price.ToString() + " VNĐ";
        }
        private void dgvBillInfor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvBillInfor.Columns["colXoa"].Index && e.RowIndex != -1)
            {
                DataGridViewCell cellGia = dgvBillInfor.Rows[e.RowIndex].Cells["colGia"];
                DataGridViewCell cellSoLuong = dgvBillInfor.Rows[e.RowIndex].Cells["colSoLuong"];
                int Gia = Convert.ToInt32(cellGia.Value.ToString());
                int SoLuong = Convert.ToInt32(cellSoLuong.Value.ToString());
                string ThuocID = dgvBillInfor.Rows[e.RowIndex].Cells[0].Value.ToString();
                string date = dgvBillInfor.Rows[e.RowIndex].Cells["colHDung"].Value.ToString();
                DateTime HanDung = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string str = ThuocID.ToString() + HanDung.ToString("dd/MM/yyyy");
                chon.Remove(str);
                thuoc.Remove(str);
                TongTien -= Gia * SoLuong;
                dgvBillInfor.Rows.RemoveAt(e.RowIndex);
                updatePrice();
            }
        }

        private void dgvBillInfor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvBillInfor.Columns["colSoLuong"].Index)
            {
                DataGridViewCell cell = dgvBillInfor.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Kiểm tra định dạng số nguyên dương
                if (!IsValidPositiveInteger(cell.Value.ToString()))
                {
                    // Nếu không đúng định dạng, đặt lại giá trị mặc định và hiển thị thông báo
                    cell.Value = 1;
                    MessageBox.Show("Vui lòng nhập số lượng là số nguyên dương!");
                }
                else
                {
                    DataGridViewCell cellGia = dgvBillInfor.Rows[e.RowIndex].Cells[e.ColumnIndex+1];
                    int Gia = Convert.ToInt32(cellGia.Value.ToString());
                    int SoLuong = Convert.ToInt32(cell.Value.ToString());
                    TongTien += Gia * (SoLuong-1);
                    updatePrice();
                }
            }
        }

        private void cbHeSoKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePrice();
        }

        private void tbxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            string que;
            if (string.IsNullOrWhiteSpace(tbxSearch.Text) && e.KeyChar == '\r')
            {
                eLoi.SetError(tbxSearch,string.Empty);
                loadThuoc();
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
                    MessageBox.Show("Vui lòng điền ID thuốc là số nguyên");
                    return;
                }
                if (e.KeyChar == '\r')
                {
                    que = "select ThuocID,Anh,TenThuoc,CongDung,SoLuong,NgayHetHan,GiaBan from dbo.fTimThuoc(" + tbxSearch.Text + ",null,null,null,null)";
                    dgvMedicines.DataSource = DAO.Connection.Query(que);
                    return;
                }
                return;
            }
            que = "select ThuocID,Anh,TenThuoc,CongDung,SoLuong,NgayHetHan,GiaBan from dbo.fTimThuoc(null,@TenThuoc,@TenLoaiThuoc,@CongDung,@TenKho)";
            Dictionary<string,Object> dic = new Dictionary<string,Object>();
            if(!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\r')
            {
                e.Handled = true;
                eLoi.SetError(tbxSearch, "Vui lòng chỉ nhập chữ");
                return;
            }    
            if(tbxSearch.Text.Length>=50 && cbLoaiTim.Text == "Tên thuốc")
            {
                e.Handled= true;
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
            eLoi.SetError(tbxSearch,string.Empty);
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
                dgvMedicines.DataSource = DAO.Connection.Query(que, dic);
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
