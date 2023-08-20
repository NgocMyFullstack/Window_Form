using QLBH.DALL;
using QLBH.MODELL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.BALL
{
    public class Product
    {
        // Khởi tạo đối tượng của lớp SanPhamDAL để tương tác với cơ sở dữ liệu
        DALL.Product dal = new DALL.Product();

        // Phương thức đọc danh sách sản phẩm
        public List<MODELL.Product> ReadSanPham()
        {
            // Gọi phương thức ReadSanPham trong lớp SanPhamDAL để lấy danh sách sản phẩm từ cơ sở dữ liệu
            List<MODELL.Product> lstCus = dal.ReadSanPham();
            return lstCus; // Trả về danh sách sản phẩm
        }

        // Phương thức tìm kiếm sản phẩm
        public List<MODELL.Product> Timkiem(MODELL.Product c)
        {
            // Gọi phương thức timkiem trong lớp SanPhamDAL để tìm kiếm sản phẩm dựa trên thông tin được cung cấp
            List<MODELL.Product> lstCus = dal.timkiem(c);
            return lstCus; // Trả về danh sách sản phẩm kết quả tìm kiếm
        }

        // Phương thức thêm sản phẩm
        public void AddSanPham(MODELL.Product cus)
        {
            dal.AddSanPham(cus); // Gọi phương thức AddSanPham trong lớp SanPhamDAL để thêm sản phẩm vào cơ sở dữ liệu
        }

        // Phương thức xóa sản phẩm
        public void DeleteSanPham(MODELL.Product cus)
        {
            dal.DeleteSanPham(cus); // Gọi phương thức DeleteSanPham trong lớp SanPhamDAL để xóa sản phẩm khỏi cơ sở dữ liệu
        }

        // Phương thức chỉnh sửa thông tin sản phẩm
        public void EditSanPham(MODELL.Product cus)
        {
            dal.EditSanPham(cus); // Gọi phương thức EditSanPham trong lớp SanPhamDAL để chỉnh sửa thông tin sản phẩm trong cơ sở dữ liệu
        }
    }

}
