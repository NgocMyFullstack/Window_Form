using QLBH.DALL;
using QLBH.MODELL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.BALL
{
    public class Bill
    {
        // Khởi tạo đối tượng của lớp HoaDonDAL để tương tác với cơ sở dữ liệu
        DALL.Bill dal = new DALL.Bill();

        // Phương thức đọc danh sách hóa đơn
        public List<MODELL.Bill> ReadHoaDon()
        {
            // Gọi phương thức ReadHoaDon trong lớp HoaDonDAL để lấy danh sách hóa đơn từ cơ sở dữ liệu
            List<MODELL.Bill> lstCus = dal.ReadHoaDon();
            return lstCus; // Trả về danh sách hóa đơn
        }

        // Phương thức thêm hóa đơn
        public void AddHoaDon(MODELL.Bill cus)
        {
            dal.AddHoaDon(cus); // Gọi phương thức AddHoaDon trong lớp HoaDonDAL để thêm hóa đơn vào cơ sở dữ liệu
        }

        // Phương thức xóa hóa đơn
        public void DeleteHoaDon(MODELL.Bill cus)
        {
            // TODO: Triển khai phần xóa hóa đơn trong lớp HoaDonDAL
        }

        // Phương thức chỉnh sửa hóa đơn
        public void EditHoaDon(MODELL.Bill cus)
        {
            dal.EditHoaDon(cus); // Gọi phương thức EditHoaDon trong lớp HoaDonDAL để chỉnh sửa thông tin hóa đơn trong cơ sở dữ liệu
        }
    }

}
