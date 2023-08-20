using QLBH.DALL;
using QLBH.MODELL;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH
{
    internal class TaiKhoanDAL : ConnectionSQL
    {
        public List<TaiKhoanBEL> ReadTaiKhoan()
        {
            SqlConnection conn = CreateConnection(); // Tạo đối tượng kết nối SqlConnection
            conn.Open(); // Mở kết nối đến cơ sở dữ liệu

            // Tạo đối tượng SqlCommand với câu truy vấn SELECT và kết nối đã được mở
            SqlCommand cmd = new SqlCommand("SELECT * FROM dangnhap", conn);

            SqlDataReader reader = cmd.ExecuteReader(); // Thực thi truy vấn SELECT và lấy dữ liệu trả về

            List<TaiKhoanBEL> lstCus = new List<TaiKhoanBEL>(); // Tạo danh sách để chứa thông tin tài khoản

            while (reader.Read()) // Đọc từng bản ghi trong kết quả truy vấn
            {
                TaiKhoanBEL cus = new TaiKhoanBEL(); // Tạo đối tượng TaiKhoanBEL để chứa thông tin tài khoản từ dữ liệu đọc được

                // Đọc dữ liệu từ bản ghi và gán vào các thuộc tính của đối tượng TaiKhoanBEL
                cus.Id = int.Parse(reader["id"].ToString());
                cus.Username = reader["TaiKhoan"].ToString();
                cus.Password = reader["MatKhau"].ToString();

                lstCus.Add(cus); // Thêm đối tượng TaiKhoanBEL vào danh sách
            }

            reader.Close(); // Đóng đối tượng SqlDataReader
            conn.Close(); // Đóng kết nối đến cơ sở dữ liệu

            return lstCus; // Trả về danh sách tài khoản
        }


    }
}
