using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class Sach
    {
        private string maSach, tenSach, maTL, maNSB, maTG, ngayCapNhat;
        private int giaBan, giaNhap, giamGia, slTon;

        public int SlTon
        {
            get { return slTon; }
            set { slTon = value; }
        }

        public int GiamGia
        {
            get { return giamGia; }
            set { giamGia = value; }
        }

        public int GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }

        public int GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }

        public string NgayCapNhat
        {
            get { return ngayCapNhat; }
            set { ngayCapNhat = value; }
        }

        public string MaTG
        {
            get { return maTG; }
            set { maTG = value; }
        }

        public string MaNSB
        {
            get { return maNSB; }
            set { maNSB = value; }
        }

        public string MaTL
        {
            get { return maTL; }
            set { maTL = value; }
        }

        public string TenSach
        {
            get { return tenSach; }
            set { tenSach = value; }
        }

        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }
        public Sach(){}
        public Sach(string maSach, string tenSach, string maTL, string maNSB, string maTG, string ngayCapNhat, int giaBan, int giaNhap, int giamGia, int slTon)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.maTL = maTL;
            this.maNSB = maNSB;
            this.maTG = maTG;
            this.ngayCapNhat = ngayCapNhat;
            this.giaBan = giaBan;
            this.giaNhap = giaNhap;
            this.giamGia = giamGia > 0 ? giamGia : 0;
            this.slTon = slTon;
        }

    }
}
