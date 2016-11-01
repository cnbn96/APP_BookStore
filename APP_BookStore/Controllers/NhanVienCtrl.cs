using APP_BookStore.Models;
using APP_BookStore.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Controllers
{
    class NhanVienCtrl
    {
        NhanVienService nvSer = new NhanVienService();
        public DataTable GetAllNhanVien()
        {
            return nvSer.GetAllData();
        }
        public NhanVien GetNhanVien(String maNV)
        {
            return nvSer.getNhanVien(maNV);
        }
        public bool AddNhanVien(NhanVien nv)
        {
            return nvSer.AddData(nv);
        }
        public bool DeleteNhanVien(string maNV)
        {
            return nvSer.DeleteData(maNV);
        }
        public bool UpdateNhanVien(NhanVien nv)
        {
            return nvSer.UpdateData(nv);
        }
        public bool UpdateMKNhanVien(NhanVien nv)
        {
            return nvSer.UpdateMK(nv);
        }
        public string GetMKNhanVien(string maNV)
        {
            return nvSer.GetDataMK(maNV);
        }

    }
}
