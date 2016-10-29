using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class KhachHang
    {
        string maKH, tenKH, diaChi;
        int SDT;
        char gioiTinh;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        public int SDT1
        {
            get { return SDT; }
            set { SDT = value; }
        }

        public char GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        public KhachHang()
        {

        }
        public KhachHang(string MaKH, string TenKH, string DiaChi, char GioiTinh, int SDT)
        {   
            this.maKH = MaKH;
            this.tenKH = TenKH;
            this.diaChi = DiaChi;
            this.gioiTinh = GioiTinh;
            this.SDT = SDT;
        }
    }
}
