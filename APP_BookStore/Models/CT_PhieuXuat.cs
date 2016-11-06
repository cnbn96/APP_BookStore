using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class CT_PhieuXuat
    {
         string maPX, maSach;
        int soLuong;


        public CT_PhieuXuat()
        {

        }

        public CT_PhieuXuat(string maPX, string maSach, int sl)
        {
            this.maPX = maPX;
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

        public string MaPX
        {
            get { return maPX; }
            set { maPX = value; }
        }
    }
}
