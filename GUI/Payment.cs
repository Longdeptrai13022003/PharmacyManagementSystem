using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MedicalStoreManagementSystem.GUI
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        //Bịa 1 cái TotalPrice
        double totalPrice = 2000000;
        static string FormatCurrency(double amount)
        {
            // Định dạng số tiền với định dạng tiền tệ của Việt Nam
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            string formattedAmount = string.Format(cultureInfo, "{0:C}", amount);

            return formattedAmount;
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            lblTotalPrice.Text = FormatCurrency(totalPrice);
        }

        private void tbxTienKhachTra_TextChanged(object sender, EventArgs e)
        {
            if (tbxTienKhachTra.Text.Length > 0)
            {
                double tienkhachtra = double.Parse(tbxTienKhachTra.Text);
                double tientrakhach = tienkhachtra - totalPrice;
                tbxTienThua.Text = FormatCurrency(tientrakhach);
            }
            else
            {
                tbxTienThua.Clear();
            }
        }

        private void rdbCash_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbCash.Checked)
            {
                pnBanking.Height = 0;
            }
            else
            {
                pnBanking.Height = pnCash.Height;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Nếu chọn banking thì lấy luôn tiền khách trả bằng total price
        private void btnPrintBill_Click(object sender, EventArgs e)
        {

        }

        private void tbxTienKhachTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)&&!Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
