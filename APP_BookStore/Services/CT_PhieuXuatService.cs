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
    class CT_PhieuXuatService
    {
        ConnectToDB con = new ConnectToDB();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetAllData(string ma)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = String.Format("select s.MaSach, s.TenSach, s.MaTG, s.MaNXB, s.GiaBan, s.GiaNhap, ct.SoLuong from Sach s, CT_PhieuXuat ct where s.MaSach = ct.MaSach and MaPX = '{0}' ", ma);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString(), "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                con.CloseConn();
                cmd.Dispose();
            }
            return dt;
        }
        public bool AddData(CT_PhieuXuat ctpx)
        {
            cmd.CommandText = String.Format("Insert into CT_PhieuXuat values('{0}','{1}', '{2}') ", ctpx.MaPX, ctpx.MaSach, ctpx.SoLuong);
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
        public bool DeleteData(string ma)
        {
            cmd.CommandText = String.Format("delete CT_PhieuXuat where MaPX='{0}'", ma);
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
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
    }
}
