
using QLBH.MODELL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DALL
{
    internal class Bill : ConnectionSQL
    {
        public void AddHoaDon(MODELL.Bill cus)
        {
            using (SqlConnection conn = CreateConnection()) // Sử dụng đối tượng kết nối trong một khối using để đảm bảo giải phóng tài nguyên khi hoàn thành
            {
                conn.Open(); // Mở kết nối đến cơ sở dữ liệu

                // Tạo đối tượng SqlCommand với câu truy vấn INSERT và kết nối đã được tạo
                SqlCommand cmd = new SqlCommand("INSERT INTO hoadon (MaKhachHang, TenKhachHang, SoDienThoai, KhuVuc, NgayLapHD, MaSanPham, TenSanPham, SoLuong, Gia, TongTien) VALUES (@MaKhachHang, @TenKhachHang, @SoDienThoai, @KhuVuc, @NgayLapHD, @MaSanPham, @TenSanPham, @SoLuong, @Gia, @TongTien)", conn);

                // Thêm các tham số vào câu truy vấn để tránh tấn công SQL và cung cấp dữ liệu
                cmd.Parameters.Add(new SqlParameter("@MaKhachHang", cus.MaKhachHang));
                cmd.Parameters.Add(new SqlParameter("@TenKhachHang", cus.TenKhachHang));
                cmd.Parameters.Add(new SqlParameter("@SoDienThoai", cus.SoDienThoai));
                cmd.Parameters.Add(new SqlParameter("@KhuVuc", cus.KhuVuc));
                cmd.Parameters.Add(new SqlParameter("@NgayLapHD", cus.NgayLapHD));
                cmd.Parameters.Add(new SqlParameter("@MaSanPham", cus.MaSanPham));
                cmd.Parameters.Add(new SqlParameter("@TenSanPham", cus.TenSanPham));
                cmd.Parameters.Add(new SqlParameter("@SoLuong", cus.Soluong));
                cmd.Parameters.Add(new SqlParameter("@Gia", cus.Gia));
                cmd.Parameters.Add(new SqlParameter("@TongTien", cus.TongTien));

                cmd.ExecuteNonQuery(); // Thực thi truy vấn INSERT vào cơ sở dữ liệu
            } // Tự động giải phóng tài nguyên khi khối using kết thúc (bao gồm việc đóng kết nối)
        }

      
public List<MODELL.Bill> ReadHoaDon()
        {
            using (SqlConnection conn = CreateConnection()) // Sử dụng đối tượng kết nối trong một khối using để đảm bảo giải phóng tài nguyên khi hoàn thành
            {
                conn.Open(); // Mở kết nối đến cơ sở dữ liệu

                // Tạo đối tượng SqlCommand với câu truy vấn SELECT và kết nối đã được tạo
                SqlCommand cmd = new SqlCommand("SELECT * FROM HoaDon", conn);

                SqlDataReader reader = cmd.ExecuteReader(); // Thực thi truy vấn SELECT và lấy dữ liệu trả về

                List<MODELL.Bill> lstCus = new List<MODELL.Bill>(); // Tạo danh sách để chứa thông tin hóa đơn

                while (reader.Read()) // Đọc từng bản ghi trong kết quả truy vấn
                {
                    MODELL.Bill cus = new MODELL.Bill(); // Tạo đối tượng HoaDonBEL để chứa thông tin hóa đơn từ dữ liệu đọc được

                    // Đọc dữ liệu từ bản ghi đang xét và gán vào các thuộc tính của đối tượng HoaDonBEL
                    cus.MaKhachHang = int.Parse(reader["MaKhachHang"].ToString());
                    cus.TenKhachHang = reader["TenKhachHang"].ToString();
                    cus.SoDienThoai = reader["SoDienThoai"].ToString();
                    cus.KhuVuc = reader["KhuVuc"].ToString();
                    cus.NgayLapHD = DateTime.Parse(reader["NgayLapHD"].ToString());
                    cus.MaSanPham = int.Parse(reader["MaSanPham"].ToString());
                    cus.TenSanPham = reader["TenSanPham"].ToString();
                    cus.Soluong = int.Parse(reader["SoLuong"].ToString());
                    cus.Gia = reader["Gia"].ToString();
                    cus.TongTien = decimal.Parse(reader["TongTien"].ToString());

                    lstCus.Add(cus); // Thêm đối tượng HoaDonBEL vào danh sách
                }
                reader.Close(); // Đóng đối tượng SqlDataReader
                conn.Close(); // Đóng kết nối đến cơ sở dữ liệu
                return lstCus; // Trả về danh sách hóa đơn
            }
        }

        public void EditHoaDon(MODELL.Bill cus)
        {
            SqlConnection conn = CreateConnection(); // Tạo đối tượng kết nối SqlConnection
            conn.Open(); // Mở kết nối đến cơ sở dữ liệu

            // Tạo đối tượng SqlCommand với câu truy vấn UPDATE và kết nối đã được mở
            SqlCommand cmd = new SqlCommand("UPDATE HoaDon SET TenKhachHang = @TenKhachHang, SoDienThoai = @SoDienThoai, KhuVuc = @KhuVuc, NgayLapHD = @NgayLapHD, MaSanPham = @MaSanPham, TenSanPham = @TenSanPham, SoLuong = @SoLuong, Gia = @Gia, TongTien = @TongTien WHERE MaKhachHang = @MaKhachHang", conn);

            // Thêm các tham số vào câu truy vấn để cập nhật dữ liệu trong cơ sở dữ liệu
            cmd.Parameters.Add(new SqlParameter("@MaKhachHang", cus.MaKhachHang));
            cmd.Parameters.Add(new SqlParameter("@TenKhachHang", cus.TenKhachHang));
            cmd.Parameters.Add(new SqlParameter("@SoDienThoai", cus.SoDienThoai));
            cmd.Parameters.Add(new SqlParameter("@KhuVuc", cus.KhuVuc));
            cmd.Parameters.Add(new SqlParameter("@NgayLapHD", cus.NgayLapHD));
            cmd.Parameters.Add(new SqlParameter("@MaSanPham", cus.MaSanPham));
            cmd.Parameters.Add(new SqlParameter("@TenSanPham", cus.TenSanPham));
            cmd.Parameters.Add(new SqlParameter("@SoLuong", cus.Soluong));
            cmd.Parameters.Add(new SqlParameter("@Gia", cus.Gia));
            cmd.Parameters.Add(new SqlParameter("@TongTien", cus.TongTien));

            cmd.ExecuteNonQuery(); // Thực thi truy vấn UPDATE để cập nhật dữ liệu trong cơ sở dữ liệu
            conn.Close(); // Đóng kết nối đến cơ sở dữ liệu
        }

        public void DeleteHoaDon(MODELL.Bill cus)
        {
            SqlConnection conn = CreateConnection(); // Tạo đối tượng kết nối SqlConnection
            conn.Open(); // Mở kết nối đến cơ sở dữ liệu

            // Tạo đối tượng SqlCommand với câu truy vấn DELETE và kết nối đã được mở
            SqlCommand cmd = new SqlCommand("DELETE FROM HoaDon WHERE MaKhachHang = @MaKhachHang", conn);

            // Thêm tham số vào câu truy vấn để xác định hóa đơn cần xóa
            cmd.Parameters.Add(new SqlParameter("@MaKhachHang", cus.MaKhachHang));

            cmd.ExecuteNonQuery(); // Thực thi truy vấn DELETE để xóa hóa đơn từ cơ sở dữ liệu
            conn.Close(); // Đóng kết nối đến cơ sở dữ liệu
        }
        }
    }

