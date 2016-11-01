using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class TheLoaiSach
    {
        string maTL, tenTL;

        public string TenTL
        {
            get { return tenTL; }
            set { tenTL = value; }
        }

        public string MaTL
        {
            get { return maTL; }
            set { maTL = value; }
        }
        public TheLoaiSach()
        {

        }
        public TheLoaiSach(string maTL, string tenTL)
        {
            this.maTL = maTL;
            this.tenTL = tenTL;
        }

    }
}
