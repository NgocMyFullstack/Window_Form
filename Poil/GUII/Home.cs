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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Đóng Form cũ
            this.Hide();

            // Tạo và hiển thị Form mới
            Product t1 = new Product();
            t1.Closed += (s, args) => this.Close(); // Đóng Form cũ khi Form mới đóng
            t1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Đóng Form cũ
            this.Hide();

            // Tạo và hiển thị Form mới
            Client t2 = new Client();
            t2.Closed += (s, args) => this.Close(); // Đóng Form cũ khi Form mới đóng
            t2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Đóng Form cũ
            this.Hide();

            // Tạo và hiển thị Form mới
            Bill hd = new Bill();
            hd.Closed += (s, args) => this.Close(); // Đóng Form cũ khi Form mới đóng
            hd.Show();
        }


        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            // Đặt đường dẫn đến tệp video bạn muốn phát
            string filePath = @"D:\Video\Video3.mp4";

            // Đảm bảo rằng WMP control đang khả dụng
            if (axWindowsMediaPlayer1 != null)
            {
                // Thiết lập đường dẫn tệp video cho WMP control
                axWindowsMediaPlayer1.URL = filePath;

                // Đăng ký sự kiện PlayStateChange để xử lý sự kiện khi trạng thái phát thay đổi
                axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

                // Phát video
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Khi trạng thái phát thay đổi và trạng thái là MediaEnded (8), chạy lại video
            if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Ẩn Form cũ
            this.Hide();

            // Tạo và hiển thị Form mới
            var form2 = new Home();
            form2.FormClosed += (s, args) =>
            {
                // Khi Form mới đóng, đảm bảo rằng bạn đã dừng video hoặc tài nguyên khác trên Form cũ
                this.Close();
            };
            form2.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
