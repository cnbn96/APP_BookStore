using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class NhanVien
    {
        string maNV, tenNV, chucVu, diaChi, matKhau;
        
        char gioiTinh;
        int SDT;
        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string ChucVu
        {
            get { return chucVu; }
            set { chucVu = value; }
        }

        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        
        public char GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        

        public int SDT1
        {
            get { return SDT; }
            set { SDT = value; }
        }
        public NhanVien()
        {

        }
        public NhanVien(string MaNV, string TenNV, string ChucVu, string DiaChi, char GioiTinh, int SDT)
        {
            this.maNV = MaNV;
            this.diaChi = DiaChi;
            this.tenNV = TenNV;
            this.chucVu = ChucVu;
            this.SDT = SDT;
            this.gioiTinh = GioiTinh;
        }
    }
}
