using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.DTO
{
    internal class NhanVien
    {
        private int nhanVienID;
        private string hoTen;
        private DateTime ngaySinh;
        private int gioiTinh;
        private string diaChi;
        private string sdt;
        private string email;
        private int chucVuID;
        private DateTime ngayVaoLam;
        private string bangCap;
        private string chuyenNganh;
        private byte[] anh;
        public NhanVien(int NhanVienID,string HoTen,DateTime NgaySinh,int GioiTinh,string DiaChi,string Sdt,string Email,int ChucVuID, DateTime NgayVaoLam,string BangCap,string ChuyenNganh, byte[] Anh)
        {
            this.nhanVienID = NhanVienID;
            this.hoTen = HoTen;
            this.ngaySinh= NgaySinh;
            this.gioiTinh=GioiTinh;
            this.diaChi=DiaChi;
            this.sdt = Sdt;
            this.email = Email;
            this.chucVuID= ChucVuID;
            this.ngayVaoLam=NgayVaoLam;
            this.bangCap= BangCap;
            this.chuyenNganh= ChuyenNganh;
            this.anh=Anh;
        }
        public int NhanVienID { get => nhanVienID; set=> nhanVienID = value; }
        public string HoTen { get => hoTen;set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh;set => ngaySinh = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value;}
        public string DiaChi { get => diaChi; set => diaChi = value;}
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public int ChucVuID { get => chucVuID; set => chucVuID = value; }
        public DateTime NgayVaoLam { get => ngayVaoLam;set=> ngayVaoLam = value;}
        public string BangCap { get => bangCap; set => bangCap = value; }
        public string ChuyenNganh { get => chuyenNganh;set => chuyenNganh = value; }
        public byte[] Anh { get => anh; set => anh = value; }
    }
}
