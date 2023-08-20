using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DALL
{
    public class ConnectionSQL
    {
        public ConnectionSQL()
        {

        }

        // Tạo đối tượng kết nối SqlConnection và cấu hình thông tin kết nối
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();// Khởi tạo đối tượng SqlConnection
            conn.ConnectionString = @"Data Source= DESKTOP-67V9FFC\SQLEXPRESS ;Initial Catalog= TaiKhoan; User Id=sa; Password=123";// Cấu hình chuỗi kết nối
            return conn; // Trả về đối tượng SqlConnection đã được cấu hình
        }

        // Lấy giá trị của một trường từ cơ sở dữ liệu
        public string GetFieldValues(string sql)
        {
            string result = null; // Khởi tạo biến để chứa kết quả truy vấn
            using (SqlConnection connection = CreateConnection()) // Sử dụng đối tượng kết nối được tạo từ phương thức CreateConnection
            {
                try
                {
                    connection.Open(); // Mở kết nối đến cơ sở dữ liệu
                    using (SqlCommand command = new SqlCommand(sql, connection)) // Tạo đối tượng SqlCommand với câu truy vấn và kết nối
                    {
                        object queryResult = command.ExecuteScalar(); // Thực hiện truy vấn và lấy kết quả trả về đầu tiên
                        if (queryResult != null) // Kiểm tra xem kết quả có tồn tại hay không
                        {
                            result = queryResult.ToString(); // Gán kết quả truy vấn vào biến result
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message); // In thông báo lỗi ra màn hình nếu có lỗi xảy ra
                }
            }
            return result; // Trả về kết quả truy vấn (hoặc null nếu có lỗi)
        }

        internal DataTable GetDataTable(string str)
        {
            // TODO: Triển khai phương thức để trả về DataTable từ câu truy vấn str
            throw new NotImplementedException(); // Đang chưa triển khai, nên ném ngoại lệ NotImplementedException
        }

    }
}
