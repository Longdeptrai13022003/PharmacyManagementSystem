using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalStoreManagementSystem.GUI
{
    public partial class BillManagement : Form
    {
        public BillManagement()
        {
            InitializeComponent();
            loadBill();
        }
        void loadBill()
        {
            dgvBills.DataSource = DAO.Connection.Query("Select * from vHoaDon");
        }
        public void loadChiTiet(int BillID)
        {
            string que = "select ThuocID,TenThuoc,SoLuong,GiaBan from vChiTietHoaDon where HoaDonID=" + BillID.ToString();
            dgvBillInfor.DataSource =DAO.Connection.Query(que);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvBills.Rows.Count > 0)
            {
                dgvBills.MultiSelect = true;
                dgvBills.SelectAll();
                DataObject copydata = dgvBills.GetClipboardContent();
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
                dgvBills.MultiSelect = false;
            }
            else
            {
                MessageBox.Show("Không có thông tin để export");
            }
        }

        private void BillManagement_Load(object sender, EventArgs e)
        {
            cbLoaiTim.SelectedIndex = 1;
        }

        private void dgvBills_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int BillID = (int)dgvBills.Rows[e.RowIndex].Cells[0].Value;
            tbxID.Text= BillID.ToString();
            tbxCustomerName.Text= dgvBills.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpNgayTao.Value = (DateTime)dgvBills.Rows[e.RowIndex].Cells[3].Value;
            tbxPhone.Text = dgvBills.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbxTotalPrice.Text = dgvBills.Rows[e.RowIndex].Cells[4].Value.ToString();
            loadChiTiet(BillID);
        }
        private bool IsValidPositiveInteger(string input)
        {
            int parsedValue;
            return int.TryParse(input, out parsedValue) && parsedValue >= 0;
        }
        private void dgvBillInfor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvBillInfor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvBillInfor.Columns["colSoLuong"].Index)
            {
                DataGridViewCell cell = dgvBillInfor.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (!IsValidPositiveInteger(cell.Value.ToString()))
                {
                    cell.Value = 1;
                    MessageBox.Show("Vui lòng nhập số lượng là số nguyên!");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int HoaDonID = Int32.Parse(tbxID.Text);
            string TenKH = tbxCustomerName.Text;
            string Sdt = tbxPhone.Text;
            string que = "exec spSuaHoaDon @HoaDonID,@TenKhachHang,@Sdt";
            Dictionary<string,Object> dic = new Dictionary<string,Object>();
            dic.Add("@HoaDonID",HoaDonID);
            dic.Add("@TenKhachHang",TenKH);
            dic.Add("@Sdt",Sdt);
            DAO.Connection.Excute(que, dic);

            foreach(DataGridViewRow row in dgvBillInfor.Rows)
            {
                int ThuocID = Int32.Parse(row.Cells["colThuocID"].Value.ToString());
                int SoLuong = Int32.Parse(row.Cells["colSoLuong"].Value.ToString());
                que = "exec spSuaChiTietHoaDon @HoaDonID,@ThuocID,@SoLuong";
                dic = new Dictionary<string,Object>();
                dic.Add("@HoaDonID",HoaDonID);
                dic.Add("@ThuocID",ThuocID);
                dic.Add("@SoLuong",SoLuong);
                DAO.Connection.Excute(que, dic);
            }
            loadBill();
            loadChiTiet(HoaDonID);
            MessageBox.Show("Cập nhập hóa đơn thành công");
        }

        private void dgvBillInfor_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvBillInfor.Columns["colSoLuong"].Index)
            {
                string proposedValue = e.FormattedValue.ToString();

                if (!IsValidPositiveInteger(proposedValue))
                {
                    e.Cancel = true;
                    MessageBox.Show("Vui lòng nhập số lượng là số nguyên!");
                }
                else
                {
                    int originalValue;
                    if (int.TryParse(dgvBillInfor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out originalValue))
                    {
                        dgvBillInfor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = originalValue;
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string que = "exec spXoaHoaDon " + tbxID.Text;
            DAO.Connection.Excute(que);
            loadBill();
            MessageBox.Show("Xóa thành công");
            if(dgvBills.Rows.Count == 0)
            {
                tbxCustomerName.Clear();
                tbxID.Clear();
                tbxPhone.Clear();
                tbxTotalPrice.Clear();
                dgvBillInfor.Rows.Clear();
            }
        }

        private void btnTimNgay_Click(object sender, EventArgs e)
        {
            string que = "select * from dbo.fTimHDNgayTao (@NgayBatDau,@NgayKetThuc)";
            Dictionary<string,Object> dic = new Dictionary<string,Object>();
            dic.Add("@NgayBatDau", dtpFromDate.Value);
            dic.Add("NgayKetThuc",dtpToDate.Value);
            dgvBills.DataSource = DAO.Connection.Query(que, dic);
        }

        private void tbxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSearch.Text) && e.KeyChar == '\r')
            {
                eLoi.SetError(tbxSearch, string.Empty);
                loadBill();
                return;
            }
            if (e.KeyChar == '\b')
            {
                eLoi.SetError(tbxSearch, string.Empty);
                return;
            }
            if (e.KeyChar != '\r')
            {
                if (cbLoaiTim.Text == "Hóa đơn ID")
                {
                    if (char.IsDigit(e.KeyChar))
                    {
                        eLoi.SetError(tbxSearch, string.Empty);
                        return;
                    }
                    e.Handled = true;
                    eLoi.SetError(tbxSearch, "Vui lòng chỉ nhập số nguyên");
                    return;
                }
                if (cbLoaiTim.Text == "Số điện thoại")
                {
                    if (tbxSearch.Text.Length >= 10 || !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                        eLoi.SetError(tbxSearch, "Vui lòng chỉ nhập số và tối đa 10 ký tự");
                        return;
                    }
                    eLoi.SetError(tbxSearch, string.Empty);
                    return;
                }
                if (cbLoaiTim.Text == "Tên khách hàng")
                {
                    if (tbxSearch.Text.Length >= 50)
                    {
                        e.Handled = true;
                        eLoi.SetError(tbxSearch, "Vui lòng nhập tên dưới 50 ký tự");
                        return;
                    }
                    if (!char.IsLetter(e.KeyChar))
                    {
                        e.Handled = true;
                        eLoi.SetError(tbxSearch, "Vui lòng nhập tên chỉ chứa chữ");
                        return;
                    }
                    eLoi.SetError(tbxSearch, string.Empty);
                    return;
                }
            }
            else
            {
                string que = "select * from dbo.fTimHoaDon(@HoaDonID,@TenKhachHang,@Sdt)";
                Dictionary<string,Object> dic = new Dictionary<string,Object>();
                if (e.KeyChar == '\r')
                {
                    if (cbLoaiTim.Text == "Hóa đơn ID")
                        dic.Add("@HoaDonID", tbxSearch.Text);
                    else
                        dic.Add("@HoaDonID", DBNull.Value);
                    if (cbLoaiTim.Text == "Tên khách hàng")
                        dic.Add("@TenKhachHang", tbxSearch.Text);
                    else
                        dic.Add("@TenKhachHang", DBNull.Value);
                    if (cbLoaiTim.Text == "Số điện thoại")
                        dic.Add("@Sdt", tbxSearch.Text);
                    else
                        dic.Add("@Sdt", DBNull.Value);
                    dgvBills.DataSource = DAO.Connection.Query(que, dic);
                }
            }    
        }
    }
}
