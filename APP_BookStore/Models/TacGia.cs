using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class TacGia
    {
        string maTG, tenTG, diaChi;
        int SDT;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string TenTG
        {
            get { return tenTG; }
            set { tenTG = value; }
        }

        public string MaTG
        {
            get { return maTG; }
            set { maTG = value; }
        }

        public int SDT1
        {
            get { return SDT; }
            set { SDT = value; }
        }
        public TacGia()
        {

        }
        public TacGia(string maTL, string tenTL, string diaChi, string sdt)
        {
            this.maTG = maTG;
            this.tenTG = tenTG;
            this.diaChi = diaChi;
            this.SDT = sdt;
        }


    }
}
