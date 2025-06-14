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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        public void load(string que)
        {
            dgvCustomers.DataSource = DAO.Connection.Query(que);
        }
        public void loadColChart()
        {
            string que = "select TenThuoc,sum(SoLuong) as SL from vChiTietHoaDon group by TenThuoc";
            chartMedicinesSold.DataSource= DAO.Connection.Query(que);
            chartMedicinesSold.ChartAreas["ChartArea1"].AxisX.Title = "Thuốc";
            chartMedicinesSold.ChartAreas["ChartArea1"].AxisY.Title = "Lượt mua";
        }
        public void loadCircleChart()
        {
            string que = "select TenThuoc,Sum(TongTien) as Tong from vChiTietHoaDon group by TenThuoc";
            chart10Medicines.DataSource = DAO.Connection.Query(que);
            chart10Medicines.ChartAreas["ChartArea1"].AxisX.Title = "Thuốc";
            chart10Medicines.ChartAreas["ChartArea1"].AxisY.Title = "Tổng lãi";
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            string que = "select * from fGetKhachHangPerTime('day','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
            load(que);
            loadColChart();
            loadCircleChart();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            string que = "select * from fGetKhachHangPerTime('day','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
            load(que);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            string que = "select * from fGetKhachHangPerTime('month','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
            load(que);
        }

        private void btnThisYear_Click(object sender, EventArgs e)
        {
            string que = "select * from fGetKhachHangPerTime('year','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
            load(que);
        }
    }
}
