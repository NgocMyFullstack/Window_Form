using QLBH.DALL;
using QLBH.MODELL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.BALL
{
    public class TaiKhoanBAL
    {
        // Khởi tạo đối tượng của lớp TaiKhoanDAL để tương tác với cơ sở dữ liệu
        TaiKhoanDAL dal = new TaiKhoanDAL();

        // Phương thức đọc danh sách tài khoản
        public List<TaiKhoanBEL> ReadTaiKhoan()
        {
            // Gọi phương thức ReadTaiKhoan trong lớp TaiKhoanDAL để lấy danh sách tài khoản từ cơ sở dữ liệu
            List<TaiKhoanBEL> lstCus = dal.ReadTaiKhoan();
            return lstCus; // Trả về danh sách tài khoản
        }
    }

}
