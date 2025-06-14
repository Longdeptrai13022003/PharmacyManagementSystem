using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.DTO
{
    public class Account
    {
        private string username;
        private string password;
        private string displayname;
        private int phanquyenID;
        private int nhanvienID;

        public Account(string username, string password, string displayname, int phanquyenID, int nhanvienID)
        {
            this.Username = username;
            this.Password = password;
            this.Displayname = displayname;
            this.PhanquyenID = phanquyenID;
            this.NhanvienID = nhanvienID;
        }
        public Account(DataRow row)
        {
            this.Username = row["username"].ToString();
            this.Password = row["password"].ToString();
            this.Displayname = row["displayname"].ToString();
            this.PhanquyenID = (int)row["phanquyenID"];
            this.NhanvienID = (int)row["nhanvienID"];
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Displayname { get => displayname; set => displayname = value; }
        public int PhanquyenID { get => phanquyenID; set => phanquyenID = value; }
        public int NhanvienID { get => nhanvienID; set => nhanvienID = value; }
    }
}
