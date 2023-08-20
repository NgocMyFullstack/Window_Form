using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.MODELL
{
    public class Bill
    {
        public int MaKhachHang{ get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string KhuVuc { get; set; }
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public DateTime NgayLapHD { get; set; }
       
        public string Gia { get; set; }
        public decimal TongTien { get; set; }
        public int Soluong {get;set;}

    }
}
