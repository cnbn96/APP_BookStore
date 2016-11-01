using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class NhaCungCap
    {
        string maNCC, tenNCC, diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string TenNCC
        {
            get { return tenNCC; }
            set { tenNCC = value; }
        }

        public string MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }
        int SDT;

        public int SDT1
        {
            get { return SDT; }
            set { SDT = value; }
        }
        public NhaCungCap()
        {

        }
        public NhaCungCap(string MaNCC, string TenNCC, string DiaChi, int SDT)
        {
            this.maNCC = MaNCC;
            this.diaChi = DiaChi;
            this.tenNCC = TenNCC;
            this.SDT = SDT;
        }
    }
}
