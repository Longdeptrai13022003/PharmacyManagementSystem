using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Web.UI.WebControls;
using MedicalStoreManagementSystem.DTO;
using System.IO;

namespace MedicalStoreManagementSystem.GUI
{
    public partial class AccountInfor : Form
    {
        public AccountInfor(Account acc)
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
                ChangeAccount(loginAccount.PhanquyenID, loginAccount.NhanvienID);
            }
        }
        void ChangeAccount(int type, int id)
        {
            type = loginAccount.PhanquyenID;
            id = loginAccount.NhanvienID;
            lblDisplayName.Text = LoginAccount.Displayname.ToString();

            lblChucVu.Text = DAO.Connection.GetFieldValue("vChiTietNhanVien", "TenChucVu", "NhanVienID", id).ToString();
            byte[] imageData = DAO.Connection.GetImage("NhanVien", "Anh", "NhanVienID", id);

            if (imageData != null)
            {
                System.Drawing.Image image;
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    image = System.Drawing.Image.FromStream(ms);
                }

                // Đặt hình ảnh vào PictureBox
                pbAvatar.Image = image;
            }
            else
            {
                pbAvatar.Image = null;
            }
            string username = loginAccount.Username;
            string password = DAO.Connection.GetFieldValue("TaiKhoan", "Password", "Username", username).ToString();
            string email = DAO.Connection.GetFieldValue("NhanVien", "Email", "NhanVienID", id).ToString();
            tbxUsername.Text = username;
            tbxPassword.Text = password;
            tbxEmail.Text = email;
        }
        private void pbAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbAvatar.ImageLocation = openFileDialog.FileName;
            }
        }
        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tbxEmail.ReadOnly = false;
            tbxEmail.Focus();
        }
        string randomCode;
        public static string to;
        Random random = new Random();
        private void btnSendCode_Click(object sender, EventArgs e)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (randomCode == tbxOTP.Text)
            {
                to = tbxEmail.Text;
                //Update Email trong account = tbxEmail.Text
                string que = "EXEC spSuaThongTin @NhanVienID, @Email";
                Dictionary<string, Object> dic = new Dictionary<string, Object>();
                dic.Add("@NhanVienID", loginAccount.NhanvienID);
                dic.Add("@Email", to);
                DAO.Connection.Excute(que, dic);
                MessageBox.Show("Update successfully");
                btnSendCode.Visible = false;
                tbxOTP.Visible = false;
                tbxEmail.Enabled = false;
            }
            else
            {
                MessageBox.Show("Wrong code", "Error");

            }
        }

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            if(tbxEmail.Text.Length > 0)
            {
                btnSendCode.Visible = true;
                tbxOTP.Visible = true;
            }
            else
            {
                btnSendCode.Visible = false;
                tbxOTP.Visible = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnChangePassword.Height = 0;
        }
        bool check()
        {
            if (tbxReEnterPassword.Text.Length == 0 || tbxReEnterPassword.Text != tbxNewPassword.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu mới cho đúng");
                tbxReEnterPassword.Clear();
                tbxReEnterPassword.Focus();
                return false;
            }
            if (tbxNewPassword.Text.Length == 0)
            {
                MessageBox.Show("Hãy nhập mật khẩu mới");
                tbxNewPassword.Focus();
                return false;
            }
            return true;
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (tbxReEnterPassword.Text == tbxNewPassword.Text)
            {
                //Update password trong database
                if (check())
                {
                    string que = "EXEC spChangePass @Username, @Password";
                    Dictionary<string, Object> dic = new Dictionary<string, Object>();
                    dic.Add("@Username", loginAccount.Username);
                    dic.Add("@Password", tbxNewPassword.Text);
                    DAO.Connection.Excute(que, dic);
                    MessageBox.Show("Change password successfully");
                    pnChangePassword.Height = 0;
                    this.Close();
                }
            }
        }

        private void linklblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnChangePassword.Height = 705;
            tbxUsernameChange.Text = loginAccount.Username;
            tbxNewPassword.Focus();
        }

        private void AccountInfor_Load(object sender, EventArgs e)
        {
            btnSendCode.Visible = false;
            tbxOTP.Visible = false;
        }
    }
}
