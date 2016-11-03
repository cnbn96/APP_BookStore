using APP_BookStore.Services;
using APP_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace APP_BookStore.Controllers
{
    class SachCtrl
    {
        SachService sachSer = new SachService();
        public DataTable GetAllSach()
        {
            return sachSer.GetAllData();
        }
        public Sach GetSach(String ma)
        {
            return sachSer.GetData(ma);
        }
        public bool AddSach(Sach s)
        {
            return sachSer.AddData(s);
        }
        public bool DeleteSach(string ma)
        {
            return sachSer.DeleteData(ma);
        }
        public bool UpdateSach(Sach s)
        {
            return sachSer.UpdateData(s);
        }
        public bool UpdateSLSach(string ma, int sl, string ngay)
        {
            return sachSer.UpdateSL(ma, sl, ngay);
        }
        public List<Sach> GetSachByDK(string dk)
        {
            return sachSer.GetDataByCondition(dk);
        }
    }
}
