using MedicalStoreManagementSystem.DTO;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class formPrint : Form
    {
        private List<DTO.Receipt> list;
        private string TenKhach;
        private string Sdt;
        private string TongTien;
        private string NgayTao;
        private string HinhThuc;
        private string KhuyenMai;
        public formPrint(List<DTO.Receipt> data,string name, string phone, string total, string date, string hinhThuc, string khuyenMai)
        {
            InitializeComponent();
            list = data;
            TenKhach = name;
            Sdt = phone;
            TongTien = total;
            NgayTao = date;
            HinhThuc = hinhThuc;
            KhuyenMai = khuyenMai;
        }

        private void formPrint_Load(object sender, EventArgs e)
        {
            rpvReceipt.LocalReport.ReportPath = "rptReceipt.rdlc";
            ReportDataSource source = new ReportDataSource("dataset",list);
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("TenKhachHang",TenKhach),
                new Microsoft.Reporting.WinForms.ReportParameter("Sdt",Sdt),
                new Microsoft.Reporting.WinForms.ReportParameter("Date",NgayTao),
                new Microsoft.Reporting.WinForms.ReportParameter("TotalPrice",TongTien),
                new Microsoft.Reporting.WinForms.ReportParameter("HinhThuc",HinhThuc),
                new Microsoft.Reporting.WinForms.ReportParameter("KhuyenMai",KhuyenMai)
            };
            rpvReceipt.LocalReport.SetParameters(para);
            rpvReceipt.LocalReport.DataSources.Add(source);
            this.rpvReceipt.RefreshReport();
        }
    }
}
