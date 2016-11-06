using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class CT_PhieuNhap
    {
        string maPN, maSach;
        int soLuong;

        public CT_PhieuNhap()
        {

        }

        public CT_PhieuNhap(string maPN, string maSach, int sl)
        {
            this.maPN = maPN;
            this.maSach = maSach;
            this.soLuong = sl;
        }
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }

        public string MaPN
        {
            get { return maPN; }
            set { maPN = value; }
        }
    }
}
