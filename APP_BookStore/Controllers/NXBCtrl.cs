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
    class NXBCtrl
    {
        NXBService nxbSer = new NXBService();
        public DataTable GetAllNXB()
        {
            return nxbSer.GetAllData();
        }
        public NhaXuatBan GetNXB(String maNXB)
        {
            return nxbSer.GetData(maNXB);
        }
        public bool AddNXB(NhaXuatBan nxb)
        {
            return nxbSer.AddData(nxb);
        }
        public bool DeleteNXB(string maNXB)
        {
            return nxbSer.DeleteData(maNXB);
        }
        public bool UpdateNXB(NhaXuatBan nxb)
        {
            return nxbSer.UpdateData(nxb);
        }
    }
}
