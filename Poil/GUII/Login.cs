using QLBH.BALL;
using QLBH.MODELL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH.GUII
{
    public partial class Login : Form
    {
        TaiKhoanBAL cusBAL = new TaiKhoanBAL();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TaiKhoanBEL> lstCus = cusBAL.ReadTaiKhoan(); // Đọc danh sách tài khoản từ cơ sở dữ liệu

            bool loginSuccess = false; // Biến để kiểm tra xem đăng nhập có thành công hay không

            foreach (TaiKhoanBEL cus in lstCus)
            {
                if (cus.Username == tbId.Text && cus.Password == tbName.Text) // So sánh tên tài khoản và mật khẩu nhập vào với dữ liệu trong danh sách
                {
                    loginSuccess = true; // Nếu tìm thấy tài khoản phù hợp, đánh dấu đăng nhập thành công
                    break; // Thoát khỏi vòng lặp, không cần kiểm tra tiếp
                }
            }

            if (loginSuccess) // Nếu đăng nhập thành công
            {
                this.Hide(); // Ẩn form hiện tại
                var form2 = new Home(); // Tạo đối tượng form Home
                form2.Closed += (s, args) => this.Close(); // Xử lý sự kiện khi form Home đóng, đóng luôn form hiện tại
                form2.Show(); // Hiển thị form Home
                MessageBox.Show("Bạn Đã Đăng nhập thành công!!!", "Thông Báo Trạng Thái Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information); // Hiển thị thông báo đăng nhập thành công
            }
            else // Nếu đăng nhập không thành công
            {
                MessageBox.Show("Sai Tên Tài Khoản hoặc Mật Khẩu!!!, Vui Lòng Nhập Lại!!!", "Thông Báo Trạng Thái Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error); // Hiển thị thông báo lỗi
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {
            tbName.PasswordChar = '*';
        }
    }
}
