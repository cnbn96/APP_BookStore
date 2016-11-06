using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class PhieuXuat
    {
        string maPX, maNV, ngayLapPN;
        DataTable dtPX;

        public DataTable DtPX
        {
            get { return dtPX; }
            set { dtPX = value; }
        }
        public PhieuXuat()
        {

        }
        public PhieuXuat(string maPX, string maNV, string ngayLapPN)
        {
            this.maNV = maNV;
            this.maPX = maPX;
            this.ngayLapPN = ngayLapPN;
        }
        public string NgayLapPN
        {
            get { return ngayLapPN; }
            set { ngayLapPN = value; }
        }


        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string MaPX
        {
            get { return maPX; }
            set { maPX = value; }
        }
    }
}
