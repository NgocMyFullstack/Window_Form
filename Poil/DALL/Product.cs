using QLBH.MODELL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DALL
{
    internal class Product : ConnectionSQL
    {
        public List<MODELL.Product> ReadSanPham()
        {
            SqlConnection conn = CreateConnection(); // Tạo đối tượng kết nối SqlConnection
            conn.Open(); // Mở kết nối đến cơ sở dữ liệu

            // Tạo đối tượng SqlCommand với câu truy vấn SELECT và kết nối đã được mở
            SqlCommand cmd = new SqlCommand("SELECT * FROM products", conn);

            SqlDataReader reader = cmd.ExecuteReader(); // Thực thi truy vấn SELECT và lấy dữ liệu trả về

            List<MODELL.Product> lstCus = new List<MODELL.Product>(); // Tạo danh sách để chứa thông tin sản phẩm

            while (reader.Read()) // Đọc từng bản ghi trong kết quả truy vấn
            {
                MODELL.Product cus = new MODELL.Product(); // Tạo đối tượng SanPhamBEL để chứa thông tin sản phẩm từ dữ liệu đọc được

                // Đọc dữ liệu từ bản ghi và gán vào các thuộc tính của đối tượng SanPhamBEL
                cus.id = int.Parse(reader["id"].ToString());
                cus.name = reader["name"].ToString();
                cus.price = int.Parse(reader["price"].ToString());
                cus.quantity_in_stock = int.Parse(reader["quantity_in_stock"].ToString());
                cus.Image = reader["Image"].ToString();
                cus.KichCo = reader["KichCo"].ToString();

                lstCus.Add(cus); // Thêm đối tượng SanPhamBEL vào danh sách
            }

            reader.Close(); // Đóng đối tượng SqlDataReader
            conn.Close(); // Đóng kết nối đến cơ sở dữ liệu

            return lstCus; // Trả về danh sách sản phẩm
        }

        public List<MODELL.Product> timkiem(MODELL.Product c)
        {
            SqlConnection conn = CreateConnection(); // Tạo đối tượng kết nối SqlConnection
            conn.Open(); // Mở kết nối đến cơ sở dữ liệu

            // Tạo đối tượng SqlCommand với câu truy vấn SELECT và kết nối đã được mở
            SqlCommand cmd = new SqlCommand("SELECT * FROM products WHERE name LIKE '%' + @name + '%'", conn);

            // Thêm tham số vào câu truy vấn để thực hiện tìm kiếm sản phẩm theo tên
            cmd.Parameters.Add(new SqlParameter("@name", c.name));

            SqlDataReader reader = cmd.ExecuteReader(); // Thực thi truy vấn SELECT và lấy dữ liệu trả về

            List<MODELL.Product> lstCus = new List<MODELL.Product>(); // Tạo danh sách để chứa thông tin sản phẩm tìm kiếm

            while (reader.Read()) // Đọc từng bản ghi trong kết quả truy vấn
            {
                MODELL.Product cus = new MODELL.Product(); // Tạo đối tượng SanPhamBEL để chứa thông tin sản phẩm từ dữ liệu đọc được

                // Đọc dữ liệu từ bản ghi và gán vào các thuộc tính của đối tượng SanPhamBEL
                cus.id = int.Parse(reader["id"].ToString());
                cus.name = reader["name"].ToString();
                cus.price = int.Parse(reader["price"].ToString());
                cus.quantity_in_stock = int.Parse(reader["quantity_in_stock"].ToString());
                cus.Image = reader["Image"].ToString();
                cus.KichCo = reader["KichCo"].ToString();

                lstCus.Add(cus); // Thêm đối tượng SanPhamBEL vào danh sách
            }

            reader.Close(); // Đóng đối tượng SqlDataReader
            conn.Close(); // Đóng kết nối đến cơ sở dữ liệu

            return lstCus; // Trả về danh sách sản phẩm tìm kiếm
        }

        public void EditSanPham(MODELL.Product cus)
        {
            SqlConnection conn = CreateConnection(); // Tạo đối tượng kết nối SqlConnection
            conn.Open(); // Mở kết nối đến cơ sở dữ liệu

            // Tạo đối tượng SqlCommand với câu truy vấn UPDATE và kết nối đã được mở
            SqlCommand cmd = new SqlCommand("UPDATE products SET name = @name, price = @price, quantity_in_stock = @quantity_in_stock, Image = @Image WHERE id = @id", conn);

            // Thêm các tham số vào câu truy vấn để cập nhật dữ liệu sản phẩm trong cơ sở dữ liệu
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.name));
            cmd.Parameters.Add(new SqlParameter("@price", cus.price));
            cmd.Parameters.Add(new SqlParameter("@quantity_in_stock", cus.quantity_in_stock));
            cmd.Parameters.Add(new SqlParameter("@Image", cus.Image));

            cmd.ExecuteNonQuery(); // Thực thi truy vấn UPDATE để cập nhật dữ liệu sản phẩm trong cơ sở dữ liệu
            conn.Close(); // Đóng kết nối đến cơ sở dữ liệu
        }
        public void DeleteSanPham(MODELL.Product cus)
        {
            SqlConnection conn = CreateConnection(); // Tạo đối tượng kết nối SqlConnection
            conn.Open(); // Mở kết nối đến cơ sở dữ liệu

            // Tạo đối tượng SqlCommand với câu truy vấn DELETE và kết nối đã được mở
            SqlCommand cmd = new SqlCommand("DELETE FROM products WHERE id = @id", conn);

            // Thêm tham số vào câu truy vấn để xác định sản phẩm cần xóa
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));

            cmd.ExecuteNonQuery(); // Thực thi truy vấn DELETE để xóa sản phẩm từ cơ sở dữ liệu
            conn.Close(); // Đóng kết nối đến cơ sở dữ liệu
        }
        public void AddSanPham(MODELL.Product cus)
        {
            SqlConnection conn = CreateConnection(); // Tạo đối tượng kết nối SqlConnection
            conn.Open(); // Mở kết nối đến cơ sở dữ liệu

            // Tạo đối tượng SqlCommand với câu truy vấn INSERT và kết nối đã được mở
            SqlCommand cmd = new SqlCommand("INSERT INTO products (id, name, price, quantity_in_stock, Image, KichCo) VALUES (@id, @name, @price, @quantity_in_stock, @Image, @KichCo)", conn);

            // Thêm các tham số vào câu truy vấn để thêm dữ liệu sản phẩm vào cơ sở dữ liệu
            cmd.Parameters.Add(new SqlParameter("@id", cus.id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.name));
            cmd.Parameters.Add(new SqlParameter("@price", cus.price));
            cmd.Parameters.Add(new SqlParameter("@quantity_in_stock", cus.quantity_in_stock));
            cmd.Parameters.Add(new SqlParameter("@Image", cus.Image));
            cmd.Parameters.Add(new SqlParameter("@KichCo", cus.KichCo));

            cmd.ExecuteNonQuery(); // Thực thi truy vấn INSERT để thêm dữ liệu sản phẩm vào cơ sở dữ liệu
            conn.Close(); // Đóng kết nối đến cơ sở dữ liệu
        }

    }
}
