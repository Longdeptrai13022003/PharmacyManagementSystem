using MedicalStoreManagementSystem.DAO;
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
    public partial class SplashScreen : Form
    {
        
        public SplashScreen(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        }
        private string userName;
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pgProgress.Value < 100)
            {
                pgProgress.Value += 2;
                lblProgress.Text = "Loading... " + pgProgress.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                this.Hide();
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                MainScreen mainScreen = new MainScreen(loginAccount);
                mainScreen.Show();
            }
        }
    }
}
