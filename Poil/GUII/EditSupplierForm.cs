using System;
using System.Windows.Forms;

namespace QLBH.GUII
{
    internal class EditSupplierForm
    {
        private string ma;
        private string ten;
        private string sdt;
        private string diachi;
        private string email;
        private string khuVuc;

        public EditSupplierForm(string ma, string ten, string sdt, string diachi, string email, string khuVuc)
        {
            this.ma = ma;
            this.ten = ten;
            this.sdt = sdt;
            this.diachi = diachi;
            this.email = email;
            this.khuVuc = khuVuc;
        }

        internal DialogResult ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}