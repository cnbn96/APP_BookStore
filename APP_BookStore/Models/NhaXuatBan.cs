using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class NhaXuatBan
    {
        string maNXB, tenNXB, diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string TenNXB
        {
            get { return tenNXB; }
            set { tenNXB = value; }
        }

        public string MaNXB
        {
            get { return maNXB; }
            set { maNXB = value; }
        }
        int SDT;

        public int SDT1
        {
            get { return SDT; }
            set { SDT = value; }
        }
        public NhaXuatBan()
        {

        }
        public NhaXuatBan(string MaSXB, string TenNXB, string DiaChi, int SDT)
        {
            this.maNXB = MaSXB;
            this.diaChi = DiaChi;
            this.tenNXB = TenNXB;
            this.SDT = SDT;
        }

    }
}
