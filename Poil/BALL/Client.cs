using QLBH.DALL;
using QLBH.MODELL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.BALL
{
    public class Client
    {
        // Khởi tạo đối tượng của lớp NhaCungCapDAL để tương tác với cơ sở dữ liệu
        DALL.Client dal = new DALL.Client();

        // Phương thức đọc danh sách nhà cung cấp
        public List<MODELL.Client> ReadNhaCungCap()
        {
            // Gọi phương thức ReadNhaCungCap trong lớp NhaCungCapDAL để lấy danh sách nhà cung cấp từ cơ sở dữ liệu
            List<MODELL.Client> lstCus = dal.ReadNhaCungCap();
            return lstCus; // Trả về danh sách nhà cung cấp
        }

        // Phương thức thêm nhà cung cấp mới
        public void NewNhaCungCap(MODELL.Client cus)
        {
            dal.NewNhaCungCap(cus); // Gọi phương thức NewNhaCungCap trong lớp NhaCungCapDAL để thêm nhà cung cấp vào cơ sở dữ liệu
        }

        // Phương thức xóa nhà cung cấp
        public void DeleteNhaCungCap(MODELL.Client cus)
        {
            dal.DeleteNhaCungCap(cus); // Gọi phương thức DeleteNhaCungCap trong lớp NhaCungCapDAL để xóa nhà cung cấp khỏi cơ sở dữ liệu
        }

        // Phương thức chỉnh sửa thông tin nhà cung cấp
        public void EditNhaCungCap(MODELL.Client cus)
        {
            dal.EditNhaCungCap(cus); // Gọi phương thức EditNhaCungCap trong lớp NhaCungCapDAL để chỉnh sửa thông tin nhà cung cấp trong cơ sở dữ liệu
        }

        
    }

}
