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
    class PhieuNhapService
    {
        ConnectToDB con = new ConnectToDB();
        SqlCommand cmd = new SqlCommand();
        //CT_PhieuNhapService ctpnSer = new CT_PhieuNhapService();
        //SachService sachSer = new SachService();
        public bool AddData(PhieuNhap pn)
        {
            cmd.CommandText = String.Format("Insert into PhieuNhap values('{0}', CONVERT(varchar(25), '{1}', 131), '{2}', '{3}') ", pn.MaPN, pn.NgayLapPN, pn.MaNV, pn.MaNCC);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString(), "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                con.CloseConn();
                cmd.Dispose();
                return false;
            }
        }
    }
}
