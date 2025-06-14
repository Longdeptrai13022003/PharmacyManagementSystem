using MedicalStoreManagementSystem.DTO;
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
    public partial class Option : Form
    {

        public Option(Account acc)
        {
            InitializeComponent();
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
            }
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            MainScreen mainScreen = Application.OpenForms["MainScreen"] as MainScreen;
            Option option = this;

            if (mainScreen != null)
                mainScreen.Close();

            option.Close();

            // Hiển thị form3
            
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            //hiện thị thông tin account đang đăng nhập
            AccountInfor accountInfor=new AccountInfor(loginAccount);
            accountInfor.Show();
            this.Hide();
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            //hiển thị thông tin nhân viên có account đang đăng nhập
            
            EmployeeInfor employeeInfor=new EmployeeInfor(loginAccount);
            employeeInfor.Show();
            this.Hide();
        }
    }
}
