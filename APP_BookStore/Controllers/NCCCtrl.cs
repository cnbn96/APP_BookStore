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
    class NCCCtrl
    {
        NCCService nccSer = new NCCService();
        public DataTable GetAllNXB()
        {
            return nccSer.GetAllData();
        }
        public NhaCungCap GetNCC(String maNCC)
        {
            return nccSer.GetData(maNCC);
        }
        public bool AddNCC(NhaCungCap ncc)
        {
            return nccSer.AddData(ncc);
        }
        public bool DeleteNCC(string maNCC)
        {
            return nccSer.DeleteData(maNCC);
        }
        public bool UpdateNCC(NhaCungCap ncc)
        {
            return nccSer.UpdateData(ncc);
        }
    }
}
