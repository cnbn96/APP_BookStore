using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class DangNhap
    {
        string maNV, matKhau;

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        public DangNhap()
        {

        }
        public DangNhap(string MaNV, string MatKhau)
        {
            this.maNV = MaNV;
            this.matKhau = MatKhau;
        }
    }
}
