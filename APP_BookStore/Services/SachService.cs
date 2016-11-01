using APP_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Services
{
    class SachService
    {
        ConnectToDB con = new ConnectToDB();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = String.Format("Select * from Sach s, TacGia tg, NhaXuatBan nxb, TheLoai tl where s.MaTL = tl.MaTL AND s.MaTG = tg.MaTG AND s.MaNXB = nxb.MaNXB");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            return dt;
        }
    }
}
