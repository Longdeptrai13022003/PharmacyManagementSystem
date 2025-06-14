using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.DTO
{
    public class Receipt
    {
        public string TenThuoc { get; set; }
        public string HanDung { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public string TongTien { get { return string.Format("{0} VNĐ", SoLuong * Gia); } }
    }
}
