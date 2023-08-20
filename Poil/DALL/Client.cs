using QLBH.MODELL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DALL
{
    internal class Client : ConnectionSQL
    {
        public List<MODELL.Client> ReadNhaCungCap()
        {
            using (SqlConnection conn = CreateConnection()) // Sử dụng đối tượng kết nối trong một khối using để đảm bảo giải phóng tài nguyên khi hoàn thành
            {
                conn.Open(); // Mở kết nối đến cơ sở dữ liệu

                // Tạo đối tượng SqlCommand với câu truy vấn SELECT và kết nối đã được mở
                SqlCommand cmd = new SqlCommand("SELECT * FROM NhaCungCap", conn);

                SqlDataReader reader = cmd.ExecuteReader(); // Thực thi truy vấn SELECT và lấy dữ liệu trả về

                List<MODELL.Client> lstCus = new List<MODELL.Client>(); // Tạo danh sách để chứa thông tin nhà cung cấp

                while (reader.Read()) // Đọc từng bản ghi trong kết quả truy vấn
                {
                    MODELL.Client cus = new MODELL.Client(); // Tạo đối tượng NhaCungCapBEL để chứa thông tin nhà cung cấp từ dữ liệu đọc được

                    // Đọc dữ liệu từ bản ghi và gán vào các thuộc tính của đối tượng NhaCungCapBEL
                    cus.id = int.Parse(reader["id"].ToString());
                    cus.Ten = reader["Ten"].ToString();
                    cus.Diachi = reader["DiaChi"].ToString();
                    cus.sdt = reader["sdt"].ToString();
                    cus.email = reader["email"].ToString();
                    cus.KhuVuc = reader["KhuVuc"].ToString();

                    lstCus.Add(cus); // Thêm đối tượng NhaCungCapBEL vào danh sách
                }

                reader.Close(); // Đóng đối tượng SqlDataReader
                conn.Close(); // Đóng kết nối đến cơ sở dữ liệu

                return lstCus; // Trả về danh sách nhà cung cấp
            }
        }

        public void EditNhaCungCap(MODELL.Client cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update  NhaCungCap set Ten=@Ten ,Diachi=@Diachi,sdt=@sdt,email=@email,KhuVuc=@KhuVuc where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.Parameters.Add(new SqlParameter("@Ten", cus.Ten));
            cmd.Parameters.Add(new SqlParameter("@Diachi", cus.Diachi));
            cmd.Parameters.Add(new SqlParameter("@sdt", cus.sdt));
            cmd.Parameters.Add(new SqlParameter("@email", cus.email));
            cmd.Parameters.Add(new SqlParameter("@KhuVuc", cus.KhuVuc));

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteNhaCungCap(MODELL.Client cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Nhacungcap where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewNhaCungCap(MODELL.Client cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into NhaCungCap (id, Ten, DiaChi, sdt, email, KhuVuc) values (@id, @Ten, @Diachi, @sdt, @email, @KhuVuc)", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.Parameters.Add(new SqlParameter("@Ten", cus.Ten));
            cmd.Parameters.Add(new SqlParameter("@Diachi", cus.Diachi));
            cmd.Parameters.Add(new SqlParameter("@sdt", cus.sdt));
            cmd.Parameters.Add(new SqlParameter("@email", cus.email));
            cmd.Parameters.Add(new SqlParameter("@KhuVuc", cus.KhuVuc));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
