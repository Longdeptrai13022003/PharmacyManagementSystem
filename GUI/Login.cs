using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using MedicalStoreManagementSystem.DAO;

namespace MedicalStoreManagementSystem.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void swShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (tbxPassword.PasswordChar == '*')
            {
                tbxPassword.PasswordChar = '\0';
            }
            else if (tbxPassword.PasswordChar == '\0')
            {
                tbxPassword.PasswordChar = '*';
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn thật sự muốn thoát?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void linklblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnForgetPassword.Height = pnContent.Height;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnForgetPassword.Height = 0;
        }
        string randomCode;
        public static string to;
        Random random = new Random();
        private void btnSendCode_Click(object sender, EventArgs e)
        {
            if (tbxEmail.Text == "")
            {
                errorEmail.Visible = true;
                tbxEmail.Focus();
            }
            else
            {
                string from, pass, messageBody;
                Random rand = new Random();
                randomCode = (rand.Next(999999)).ToString();
                MailMessage message = new MailMessage();
                to = tbxEmail.Text;
                from = "emailtest13022003@gmail.com";
                pass = "nugr bvgg gzja poeo";
                messageBody = "your reset code is " + randomCode;
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messageBody;
                message.Subject = "password reseting code";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Code send successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbxCode.Text == "")
            {
                errorCode.Visible = true;
                tbxCode.Focus();
            }
            else
            {
                if (randomCode == tbxCode.Text)
                {
                    to = tbxEmail.Text;
                    pnChangePassword.Height=pnContent.Height;
                    pnForgetPassword.Height = 0;
                }
                else
                {
                    MessageBox.Show("Wrong code", "Error");

                }
            }
        }

        private void tbxChangePassword_Click(object sender, EventArgs e)
        {
            if (tbxNewPassword.Text == tbxReEnterPassword.Text)
            {
                //Update password trong SQL
                string que = "EXEC spChangePass @Username, @Password";
                Dictionary<string, Object> dic = new Dictionary<string, Object>();
                dic.Add("@Username", tbxUsernameChangePassword.Text);
                dic.Add("@Password", tbxNewPassword.Text);
                DAO.Connection.Excute(que, dic);
                MessageBox.Show("Change password successfully");
                pnChangePassword.Height = 0;
            }
            else
            {
                MessageBox.Show("The re-new password is incorrect");
                tbxReEnterPassword.Clear();
                tbxReEnterPassword.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool checkLogin(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = tbxUsername.Text;
            string passWord = tbxPassword.Text;
            if (checkLogin(userName, passWord))
            {

                this.Hide();
                SplashScreen splashScreen = new SplashScreen(userName);
                splashScreen.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nhập sai tên đăng nhập hoặc mật khẩu", "Thông báo");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tbxUsername.Focus();
        }
    }
}
