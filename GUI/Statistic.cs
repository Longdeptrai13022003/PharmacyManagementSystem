using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MedicalStoreManagementSystem.GUI
{
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
        }
        private static SqlConnection con = new SqlConnection("server=MSI\\SQLEXPRESS;database=Demo;integrated security=true;");

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DoanhThuTheoNgay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NgayBatDau", Startdate.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@NgayKetThuc", Enddate.Value.ToString("yyyy-MM-dd"));
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                chartDoanhThu.Series.Clear();
                chartDoanhThu.Series.Add("Doanh Thu Theo Ngày");
                chartDoanhThu.Series["Doanh Thu Theo Ngày"].XValueMember = "NgayTao";
                chartDoanhThu.Series["Doanh Thu Theo Ngày"].YValueMembers = "Tien";
                chartDoanhThu.DataSource = dt;
                chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
                chartDoanhThu.ChartAreas[0].AxisY.Title = "Tiền";
                chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
                chartDoanhThu.Series["Doanh Thu Theo Ngày"].ChartType = SeriesChartType.Column;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DoanhThuTheoNgay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NgayBatDau", DateTime.Today.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@NgayKetThuc", DateTime.Today.ToString("yyyy-MM-dd"));
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                chartDoanhThu.Series.Clear();
                chartDoanhThu.Series.Add("Doanh Thu Theo Ngày");
                chartDoanhThu.Series["Doanh Thu Theo Ngày"].XValueMember = "NgayTao";
                chartDoanhThu.Series["Doanh Thu Theo Ngày"].YValueMembers = "Tien";
                chartDoanhThu.DataSource = dt;
                chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
                chartDoanhThu.ChartAreas[0].AxisY.Title = "Tiền";
                chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
                chartDoanhThu.Series["Doanh Thu Theo Ngày"].ChartType = SeriesChartType.Column;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("DoanhThuTheoThang", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NgayBatDau", Startdate.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@NgayKetThuc", Enddate.Value.ToString("yyyy-MM-dd"));
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                chartDoanhThu.Series.Clear();
                chartDoanhThu.Series.Add("Doanh Thu Theo Tháng");
                chartDoanhThu.Series["Doanh Thu Theo Tháng"].XValueMember = "Thang";
                chartDoanhThu.Series["Doanh Thu Theo Tháng"].YValueMembers = "Tien";
                chartDoanhThu.DataSource = dt;
                chartDoanhThu.ChartAreas[0].AxisX.Title = "Tháng";
                chartDoanhThu.ChartAreas[0].AxisY.Title = "Tiền";
                chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
                chartDoanhThu.Series["Doanh Thu Theo Tháng"].ChartType = SeriesChartType.Column;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DoanhThuTheoNam", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nam1", Startdate.Value.Year.ToString());
                cmd.Parameters.AddWithValue("@Nam2", Enddate.Value.Year.ToString());
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                chartDoanhThu.Series.Clear();
                chartDoanhThu.Series.Add("Doanh Thu Theo Năm");
                chartDoanhThu.Series["Doanh Thu Theo Năm"].XValueMember = "Nam";
                chartDoanhThu.Series["Doanh Thu Theo Năm"].YValueMembers = "Tien";
                chartDoanhThu.DataSource = dt;
                chartDoanhThu.ChartAreas[0].AxisX.Title = "Năm";
                chartDoanhThu.ChartAreas[0].AxisY.Title = "Tiền";
                chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
                chartDoanhThu.Series["Doanh Thu Theo Năm"].ChartType = SeriesChartType.Column;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DoanhThuTheoNgay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NgayBatDau", Startdate.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@NgayKetThuc", Enddate.Value.ToString("yyyy-MM-dd"));
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                chartDoanhThu.Series.Clear();
                chartDoanhThu.Series.Add("Doanh Thu Theo Ngày");
                chartDoanhThu.Series["Doanh Thu Theo Ngày"].XValueMember = "NgayTao";
                chartDoanhThu.Series["Doanh Thu Theo Ngày"].YValueMembers = "Tien";
                chartDoanhThu.DataSource = dt;
                chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
                chartDoanhThu.ChartAreas[0].AxisY.Title = "Tiền";
                chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
                chartDoanhThu.Series["Doanh Thu Theo Ngày"].ChartType = SeriesChartType.Column;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
