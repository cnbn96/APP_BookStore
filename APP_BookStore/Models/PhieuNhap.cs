using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Models
{
    class PhieuNhap
    {
        string maPN, maNV, maNCC, ngayLapPN;
        DataTable dtPN;

        public DataTable DtPN
        {
            get { return dtPN; }
            set { dtPN = value; }
        }
        public PhieuNhap()
        {

        }
        public PhieuNhap(string maPN, string maNV, string maNCC, string ngayLapPN)
        {
            this.maNCC = maNCC;
            this.maNV = maNV;
            this.maPN = maPN;
            this.ngayLapPN = ngayLapPN;
        }
        public string NgayLapPN
        {
            get { return ngayLapPN; }
            set { ngayLapPN = value; }
        }

        public string MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string MaPN
        {
            get { return maPN; }
            set { maPN = value; }
        }

    }
}
